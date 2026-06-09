using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers;
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Views
{
    public partial class Criar_Editar : Form
    {
        private  CompraController compraController = new CompraController();

        private  List<Item> itensTemporarios = new List<Item>();

        private List<ItemGridViewModel> itensGrid = new List<ItemGridViewModel>();

        private List<Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models.TipoArtigo> tipos = new List<Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models.TipoArtigo>();

        private List<Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models.Artigo> artigos = new List<Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models.Artigo>();

        private int utilizadorIdAtual = 1;

        private int? compraIdEdicao = null;

        private bool modoEdicao = false;

        private bool aAtualizarGrid = false;

        private bool compraFechada = false;

        public Criar_Editar(int compraId, bool compraFechada)
        {
            InitializeComponent();

            compraIdEdicao = compraId;
            modoEdicao = true;
            this.compraFechada = compraFechada;

            LigarEventos();
        }
        public Criar_Editar()
        {
            InitializeComponent();
            LigarEventos();
        }
        public Criar_Editar(int compraId)
        {
            InitializeComponent();

            compraIdEdicao = compraId;
            modoEdicao = true;

            LigarEventos();
        }
        private void BloquearEdicao()
        {
            txtNomeCompra.Enabled = false;

            cmbTipo.Enabled = false;
            cmbArtigo.Enabled = false;
            txtQuantidade.Enabled = false;

            btnAdicionarItem.Enabled = false;
            btnApagarSelecionado.Enabled = false;

            dgvItens.ReadOnly = true;

            btnGuardarRascunho.Enabled = false;
        }

        private void LigarEventos()
        {
            this.Load -= Criar_Editar_Load;
            this.Load += Criar_Editar_Load;

            cmbTipo.SelectedIndexChanged -= cmbTipo_SelectedIndexChanged;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;

            btnAdicionarItem.Click -= btnAdicionarItem_Click;
            btnAdicionarItem.Click += btnAdicionarItem_Click;

            btnGuardarRascunho.Click -= btnGuardarRascunho_Click;
            btnGuardarRascunho.Click += btnGuardarRascunho_Click;

            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;

            btnApagarSelecionado.Click -= btnApagarSelecionado_Click;
            btnApagarSelecionado.Click += btnApagarSelecionado_Click;
        }


        private void Criar_Editar_Load(object sender, EventArgs e)
        {
            DefinirUtilizadorAtual();
            ConfigurarCamposAutomaticos();
            ConfigurarGrid();
            CarregarTipos();
            CarregarArtigos();
            if (compraFechada)
            {
                BloquearEdicao();
            }

            if (modoEdicao && compraIdEdicao != null)
            {
                CarregarCompraParaEditar(compraIdEdicao.Value);
            }

            // Adia a atribuição do datasource para depois do Load terminar
            this.BeginInvoke(new Action(() =>
            {
                AtualizarGrid();
                DesselecionarItem();
            }));
        }



        private void DefinirUtilizadorAtual()
        {
            if (Sessao.UtilizadorAtual != null)
            {
                utilizadorIdAtual = Sessao.UtilizadorAtual.Id;
                txtCriadaPor.Text = Sessao.UtilizadorAtual.NomeUtilizador;
            }
            else
            {
                utilizadorIdAtual = 1;
                txtCriadaPor.Text = "Utilizador Atual";
            }
        }

        private void ConfigurarCamposAutomaticos()
        {
            txtDataCriacao.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            txtMesAssociado.Text = DateTime.Now.ToString("MMMM yyyy");

            btnApagarSelecionado.Visible = modoEdicao;

            if (modoEdicao)
            {
                this.Text = "Editar Compra";
                btnGuardarRascunho.Text = "Guardar alterações";
            }
            else
            {
                this.Text = "Criar Compra";
                btnGuardarRascunho.Text = "Guardar como rascunho";
            }
        }

        private void CarregarTipos()
        {
            try
            {
                tipos = compraController.ListarTipos();

                cmbTipo.DataSource = null;
                cmbTipo.DisplayMember = "Nome";
                cmbTipo.ValueMember = "Id";
                cmbTipo.DataSource = tipos;
                cmbTipo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar tipos de artigo.\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CarregarArtigos()
        {
            try
            {
                artigos = compraController.ListarArtigos();

                cmbArtigo.DataSource = null;
                cmbArtigo.DisplayMember = "Nome";
                cmbArtigo.ValueMember = "Id";
                cmbArtigo.DataSource = artigos;
                cmbArtigo.SelectedIndex = -1;
                cmbArtigo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar artigos.\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CarregarCompraParaEditar(int compraId)
        {
            var compra = compraController.ProcurarCompra(compraId);
            if (compra == null) return;

            txtNomeCompra.Text = compra.Nome;
            txtDataCriacao.Text = compra.DataCriacao.ToString("dd/MM/yyyy HH:mm");
            txtCriadaPor.Text = compra.Utilizador != null ? compra.Utilizador.NomeUtilizador : "";
            txtMesAssociado.Text = compra.DataCriacao.ToString("MMMM yyyy");

            itensGrid.Clear();
            itensTemporarios.Clear();

            foreach (var i in compra.Itens)
            {
                itensTemporarios.Add(i);

                itensGrid.Add(new ItemGridViewModel
                {
                    ArtigoId = i.ArtigoId,
                    TipoNome = i.Artigo != null && i.Artigo.TipoArtigo != null ? i.Artigo.TipoArtigo.Nome : "",
                    ArtigoNome = i.Artigo != null ? i.Artigo.Nome : "",
                    QuantidadeAdquirida = i.QuantidadeAdquirida,
                    Preco = i.Preco
                });
            }

            AtualizarGrid();

            if (compra.DataFecho != null)
            {
                BloquearEdicao();

                MessageBox.Show(
                    "Esta compra está fechada e não pode ser editada.",
                    "Compra Fechada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }





        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == -1 || cmbTipo.SelectedValue == null)
            {
                CarregarArtigos();
                return;
            }

            int tipoId;

            if (!int.TryParse(cmbTipo.SelectedValue.ToString(), out tipoId))
            {
                return;
            }

            List<Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models.Artigo> artigosFiltrados =
                artigos
                    .Where(a => a.TipoArtigoId == tipoId)
                    .OrderBy(a => a.Nome)
                    .ToList();

            cmbArtigo.DataSource = null;
            cmbArtigo.DisplayMember = "Nome";
            cmbArtigo.ValueMember = "Id";
            cmbArtigo.DataSource = artigosFiltrados;
            cmbArtigo.SelectedIndex = -1;
            cmbArtigo.Enabled = true;
        }

        private void ConfigurarGrid()
        {
            dgvItens.AutoGenerateColumns = false;
            dgvItens.Columns.Clear();
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.MultiSelect = false;
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToDeleteRows = false;
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTipo",
                HeaderText = "Tipo",
                DataPropertyName = "TipoNome",
                ReadOnly = true
            });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colArtigo",
                HeaderText = "Artigo",
                DataPropertyName = "ArtigoNome",
                ReadOnly = true
            });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQtdPrevista",
                HeaderText = "Qtd. Prevista",
                DataPropertyName = "QuantidadePrevista"
            });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQtdAdquirida",
                HeaderText = "Qtd. Adquirida",
                DataPropertyName = "QuantidadeAdquirida"
            });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPreco",
                HeaderText = "Preco",
                DataPropertyName = "Preco"
            });
            dgvItens.CellEndEdit -= dgvItens_CellEndEdit;
            dgvItens.CellEndEdit += dgvItens_CellEndEdit;
        }


        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            int artigoId = Convert.ToInt32(cmbArtigo.SelectedValue);
            var artigoSelecionado = artigos.FirstOrDefault(a => a.Id == artigoId);
            bool itemJaExiste = itensTemporarios.Any(i => i.ArtigoId == artigoId);
            if (cmbArtigo.SelectedIndex == -1 || cmbArtigo.SelectedValue == null)
            {
                MessageBox.Show(
                    "Selecione um artigo.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int quantidadePrevista;

            if (!int.TryParse(txtQuantidade.Text, out quantidadePrevista) || quantidadePrevista <= 0)
            {
                MessageBox.Show(
                    "Introduza uma quantidade prevista válida.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

           

                artigos.FirstOrDefault(a => a.Id == artigoId);

            if (artigoSelecionado == null)
            {
                MessageBox.Show(
                    "Artigo inválido.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

           

            if (itemJaExiste)
            {
                MessageBox.Show(
                    "Este artigo já foi adicionado à compra.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string tipoNome = "";

            if (artigoSelecionado.TipoArtigo != null)
            {
                tipoNome = artigoSelecionado.TipoArtigo.Nome;
            }
            else
            {
                Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models.TipoArtigo tipo =
                    tipos.FirstOrDefault(t => t.Id == artigoSelecionado.TipoArtigoId);

                if (tipo != null)
                {
                    tipoNome = tipo.Nome;
                }
            }

            ItemPrevisto item = new ItemPrevisto
            {
                ArtigoId = artigoId,
                QuantidadePrevista = quantidadePrevista,
                QuantidadeAdquirida = 0,
                Preco = 0
            };

            itensTemporarios.Add(item);

            itensGrid.Add(new ItemGridViewModel
            {
                ArtigoId = artigoId,
                TipoNome = tipoNome,
                ArtigoNome = artigoSelecionado.Nome,
                QuantidadePrevista = quantidadePrevista,
                QuantidadeAdquirida = 0,
                Preco = 0
            });

            AtualizarGrid();
            DesselecionarItem();

            txtQuantidade.Clear();
            cmbTipo.SelectedIndex = -1;
            cmbArtigo.SelectedIndex = -1;
            txtQuantidade.Focus();
        }

        private void btnApagarSelecionado_Click(object sender, EventArgs e)
        {
            if (!modoEdicao)
            {
                return;
            }

            if (aAtualizarGrid)
            {
                return;
            }

            if (dgvItens.CurrentRow == null || dgvItens.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Selecione um item para apagar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            ItemGridViewModel itemGrid = dgvItens.CurrentRow.DataBoundItem as ItemGridViewModel;

            if (itemGrid == null)
            {
                MessageBox.Show(
                    "Não foi possível obter o item selecionado.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Tem a certeza que deseja apagar o item selecionado?",
                "Confirmar remoção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes)
            {
                return;
            }

            dgvItens.EndEdit();

            Item item = itensTemporarios.FirstOrDefault(i => i.ArtigoId == itemGrid.ArtigoId);

            if (item != null)
            {
                itensTemporarios.Remove(item);
            }

            itensGrid.Remove(itemGrid);

            AtualizarGrid();
            DesselecionarItem();
        }

        private void dgvItens_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (aAtualizarGrid)
            {
                return;
            }

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (e.RowIndex >= dgvItens.Rows.Count)
            {
                return;
            }

            if (e.RowIndex >= itensGrid.Count)
            {
                return;
            }

            DataGridViewRow linha = dgvItens.Rows[e.RowIndex];

            if (linha == null || linha.IsNewRow)
            {
                return;
            }

            ItemGridViewModel itemGrid = linha.DataBoundItem as ItemGridViewModel;

            if (itemGrid == null)
            {
                return;
            }

            Item item = itensTemporarios.FirstOrDefault(i => i.ArtigoId == itemGrid.ArtigoId);

            if (item == null)
            {
                return;
            }

            item.QuantidadeAdquirida = itemGrid.QuantidadeAdquirida;
            item.Preco = itemGrid.Preco;

            if (item is ItemPrevisto previsto)
            {
                previsto.QuantidadePrevista = itemGrid.QuantidadePrevista;
            }
        }

        private void AtualizarGrid()
        {
            try
            {
                aAtualizarGrid = true;
                dgvItens.AutoGenerateColumns = false;
                dgvItens.DataSource = null;
                dgvItens.DataSource = itensGrid;
                dgvItens.ClearSelection();
            }
            finally
            {
                aAtualizarGrid = false;
            }
        }




        private void DesselecionarItem()
        {
            if (dgvItens == null || dgvItens.Rows.Count == 0) return;

            dgvItens.ClearSelection();
            try { dgvItens.CurrentCell = null; }
            catch { }
        }


        private void btnGuardarRascunho_Click(object sender, EventArgs e)
        {
            try
            {
                dgvItens.EndEdit();

                SincronizarItensComGrid();

                if (string.IsNullOrWhiteSpace(txtNomeCompra.Text))
                {
                    MessageBox.Show(
                        "O nome da compra é obrigatório.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                if (itensTemporarios.Count == 0)
                {
                    MessageBox.Show(
                        "Adicione pelo menos um item à compra.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                if (modoEdicao && compraIdEdicao != null)
                {
                    bool editou = compraController.Editar(
                        compraIdEdicao.Value,
                        txtNomeCompra.Text.Trim(),
                        itensTemporarios);

                    if (!editou)
                    {
                        MessageBox.Show(
                            "Não foi possível editar a compra.",
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    MessageBox.Show(
                        "Compra atualizada com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    int compraId = compraController.Adicionar(
                        txtNomeCompra.Text.Trim(),
                        utilizadorIdAtual,
                        itensTemporarios);

                    MessageBox.Show(
                        "Compra guardada como rascunho com sucesso!\nID: " + compraId,
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao guardar a compra.\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SincronizarItensComGrid()
        {
            foreach (ItemGridViewModel itemGrid in itensGrid)
            {
                Item item = itensTemporarios.FirstOrDefault(i => i.ArtigoId == itemGrid.ArtigoId);

                if (item == null)
                {
                    continue;
                }

                item.QuantidadeAdquirida = itemGrid.QuantidadeAdquirida;
                item.Preco = itemGrid.Preco;

                if (item is ItemPrevisto previsto)
                {
                    previsto.QuantidadePrevista = itemGrid.QuantidadePrevista;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "Deseja realmente cancelar?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnIrModoCompra_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Funcionalidade em desenvolvimento.",
                "Informação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnIrModoCompra_Click_1(object sender, EventArgs e)
        {
            ModoCompra form = new ModoCompra((int)compraIdEdicao);
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void txtNomeCompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarRascunho_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dgvItens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtMesAssociado_Click(object sender, EventArgs e)
        {

        }

        private void txtCriadaPor_Click(object sender, EventArgs e)
        {

        }

        private void txtDataCriacao_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class ItemGridViewModel
    {
        public int ArtigoId { get; set; }

        public string TipoNome { get; set; }

        public string ArtigoNome { get; set; }

        public int QuantidadePrevista { get; set; }

        public int QuantidadeAdquirida { get; set; }

        public float Preco { get; set; }
    }
}
