using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers;
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Views
{
    public partial class ModoCompra : Form
    {
        int compraId;
        private int itemSelecionadoId = 0;
        private string origemSelecionada = "";
        public ModoCompra()
        {
            InitializeComponent();
            compraId = 1;
            cbTipoArtigo.Enabled = false;
            txtPrecoAlterar.Enabled = false;

        }
        private void BloquearEdicaoCompra()
        {
            cbTipoArtigo.Enabled = false;
            cbArtigo.Enabled = false;
            txtQuantidade.Enabled = false;
            txtPreco.Enabled = false;
            btnAdicionar.Enabled = false;

            txtQuantidadeAlterar.Enabled = false;
            txtPrecoAlterar.Enabled = false;
            btnalterarPreco.Enabled = false;

            btnGuardar.Enabled = false;

            // opcional: impedir fechar novamente
            btnFechar.Enabled = false;
        }

        public ModoCompra(int compraId)
        {
            InitializeComponent();
            this.compraId = compraId;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                CompraController controller = new CompraController();

                ItemNaoPrevisto item = new ItemNaoPrevisto
                {
                    ArtigoId = Convert.ToInt32(cbArtigo.SelectedValue),
                    QuantidadeAdquirida = Convert.ToInt32(txtQuantidade.Text),
                    Preco = float.Parse(txtPreco.Text)
                };

                bool sucesso = controller.AdicionarItemNaoPrevisto(compraId, item);

                if (sucesso)
                {
                    MessageBox.Show("Artigo não previsto adicionado com sucesso!");

                    CarregarInformacoes(); 

                    txtQuantidade.Clear();
                    txtPreco.Clear();

                    cbTipoArtigo.SelectedIndex = -1;
                    cbArtigo.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void ModoCompra_Load(object sender, EventArgs e)
        {
            CarregarInformacoes();
            cbTipoArtigo.SelectedIndexChanged += cbTipoArtigo_SelectedIndexChanged;
            CompraController controller = new CompraController();

            if (controller.CompraEstaFechada(compraId))
            {
                BloquearEdicaoCompra();
            }
        }

        private void CarregarInformacoes()
        {
            ItemController controller = new ItemController();
            OrcamentoController orcamento = new OrcamentoController();
            CompraController compra = new CompraController();
            List<Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models.TipoArtigo> tipo = new List<Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models.TipoArtigo>();
            List<Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models.Artigo> artigos = new List<Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models.Artigo>();

            dataGridView1.DataSource = controller.ListarItens(compraId);
            dataGridView1.Columns["Id"].Visible = false;

            txtOrcamentoDinheiro.Text = orcamento.DinheiroMax().ToString() + " €";
            txtOrcamentoData.Text = DateTime.Now.ToString("MMMM yyyy");

            txtTotalDinheiro.Text = controller.DinheiroCompra(compraId).ToString() + " €";
            txtTotalQuantidade.Text = controller.QuantidadeItens(compraId).ToString() + " itens";

            txtGastoDinheiro.Text = orcamento.DinheiroAtual().ToString() + " €";
            txtRestanteDinheiro.Text = (orcamento.DinheiroMax() - orcamento.DinheiroAtual()).ToString() + " €";

            AtualizarBarra((float)orcamento.DinheiroAtual(), (float)orcamento.DinheiroMax());

            tipo = compra.ListarTipos();
            cbTipoArtigo.DataSource = null;
            cbTipoArtigo.DisplayMember = "Nome";
            cbTipoArtigo.ValueMember = "Id";
            cbTipoArtigo.DataSource = tipo;
            cbTipoArtigo.SelectedIndex = -1;
            cbTipoArtigo.Enabled = true;

            artigos = compra.ListarArtigos();
            cbArtigo.DataSource = null;
            cbArtigo.DisplayMember = "Nome";
            cbArtigo.ValueMember = "Id";
            cbArtigo.DataSource = artigos;
            cbArtigo.SelectedIndex = -1;
            cbArtigo.Enabled = true;
        }

        private void AtualizarBarra(float gasto, float maximo)
        {
            int percentagem = (int)((gasto / maximo) * 100);

            if (percentagem > 100) percentagem = 100;

            progressbar.Value = percentagem;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            CompraController controller = new CompraController();

            bool fechou = controller.FecharCompra(compraId);

            if (fechou)
            {
                MessageBox.Show(
                    "Compra fechada com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MenuPrincipal form = new MenuPrincipal();
                this.Hide();
                this.Close();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Existem artigos sem preço ou quantidade preenchidos.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }


            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Compra Guardada com Sucesso!", "Compra Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MenuPrincipal form = new MenuPrincipal();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void cbTipoArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoArtigo.SelectedValue == null)
                return;

            int tipoId;

            if (!int.TryParse(cbTipoArtigo.SelectedValue.ToString(), out tipoId))
                return;

            CompraController compra = new CompraController();

            var artigos = compra.ListarArtigosPorTipo(tipoId);

            cbArtigo.DataSource = null;
            cbArtigo.DisplayMember = "Nome";
            cbArtigo.ValueMember = "Id";
            cbArtigo.DataSource = artigos;
            cbArtigo.SelectedIndex = -1;
        }

        private void cbArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            itemSelecionadoId =
                Convert.ToInt32(
                    dataGridView1.Rows[e.RowIndex]
                    .Cells["Id"].Value);

            origemSelecionada =
                dataGridView1.Rows[e.RowIndex]
                .Cells["Origem"].Value.ToString();

            txtQuantidadeAlterar.Text =
                dataGridView1.Rows[e.RowIndex]
                .Cells["QtdComprada"].Value.ToString();

            txtPrecoAlterar.Text =
                dataGridView1.Rows[e.RowIndex]
                .Cells["Preco"].Value
                .ToString()
                .Replace(" €", "");

            txtQuantidadeAlterar.Enabled = true;
            txtPrecoAlterar.Enabled = true;

            btnalterarPreco.Enabled = true;
        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (itemSelecionadoId == 0)
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }

            CompraController controller =
                new CompraController();

            bool sucesso = controller.AlterarItemModoCompra(itemSelecionadoId, origemSelecionada, Convert.ToInt32(txtQuantidadeAlterar.Text),Convert.ToSingle(txtPrecoAlterar.Text));

            if (sucesso)
            {
                MessageBox.Show("Artigo atualizado.");

                CarregarInformacoes();

                txtQuantidadeAlterar.Clear();
                txtPrecoAlterar.Clear();

                txtQuantidadeAlterar.Enabled = false; 
                txtPrecoAlterar.Enabled = false;

                btnalterarPreco.Enabled = false;
            }
        }

        private void cmboxArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantidadeAlterar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecoAlterar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecoAlterar_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnalterarPreco_Click(object sender, EventArgs e)
        {
            if (itemSelecionadoId == 0)
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }

            CompraController controller =
                new CompraController();

            bool sucesso = controller.AlterarItemModoCompra(
                itemSelecionadoId,
                origemSelecionada,
                Convert.ToInt32(txtQuantidadeAlterar.Text),
                Convert.ToSingle(txtPrecoAlterar.Text));

            if (sucesso)
            {
                MessageBox.Show("Artigo atualizado com sucesso!");

                CarregarInformacoes();

                txtQuantidadeAlterar.Clear();
                txtPrecoAlterar.Clear();

                txtQuantidadeAlterar.Enabled = false;
                txtPrecoAlterar.Enabled = false;

                btnalterarPreco.Enabled = false;

                itemSelecionadoId = 0;
            }
        }

        private void txtOrcamentoDinheiro_Click(object sender, EventArgs e)
        {

        }
    }
}
