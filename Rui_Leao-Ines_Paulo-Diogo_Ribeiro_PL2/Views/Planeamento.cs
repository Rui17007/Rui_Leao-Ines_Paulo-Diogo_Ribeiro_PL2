using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers;
using System;
using System.Windows.Forms;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Views
{
    public partial class Planeamento : Form
    {
        private readonly CompraController compraController = new CompraController();

        public Planeamento()
        {
            InitializeComponent();

            this.Load += Planeamento_Load;
            combEstado.SelectedIndexChanged += combEstado_SelectedIndexChanged;
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
        }
        
        private void Planeamento_Load(object sender, EventArgs e)
        {
            ConfigurarComboEstado();
            ConfigurarGrid();
            CarregarCompras();
        }

        private void ConfigurarComboEstado()
        {
            combEstado.Items.Clear();
            combEstado.Items.Add("Todas");
            combEstado.Items.Add("Aberta");
            combEstado.Items.Add("Fechada");
            combEstado.SelectedIndex = 0;
        }

        private void ConfigurarGrid()
        {
            dgvCompra.AutoGenerateColumns = false;
            dgvCompra.Columns.Clear();

            dgvCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompra.MultiSelect = false;
            dgvCompra.ReadOnly = true;
            dgvCompra.AllowUserToAddRows = false;
            dgvCompra.AllowUserToDeleteRows = false;

            DataGridViewTextBoxColumn colunaId = new DataGridViewTextBoxColumn();
            colunaId.Name = "Id";
            colunaId.HeaderText = "Id";
            colunaId.DataPropertyName = "Id";
            colunaId.Width = 50;

            DataGridViewTextBoxColumn colunaNome = new DataGridViewTextBoxColumn();
            colunaNome.Name = "Nome";
            colunaNome.HeaderText = "Nome";
            colunaNome.DataPropertyName = "Nome";
            colunaNome.Width = 180;

            DataGridViewTextBoxColumn colunaEstado = new DataGridViewTextBoxColumn();
            colunaEstado.Name = "Estado";
            colunaEstado.HeaderText = "Estado";
            colunaEstado.DataPropertyName = "Estado";
            colunaEstado.Width = 90;

            DataGridViewTextBoxColumn colunaDataCriacao = new DataGridViewTextBoxColumn();
            colunaDataCriacao.Name = "DataCriacao";
            colunaDataCriacao.HeaderText = "Data criação";
            colunaDataCriacao.DataPropertyName = "DataCriacao";
            colunaDataCriacao.Width = 130;
            colunaDataCriacao.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            DataGridViewTextBoxColumn colunaDataEdicao = new DataGridViewTextBoxColumn();
            colunaDataEdicao.Name = "DataEdicao";
            colunaDataEdicao.HeaderText = "Data edição";
            colunaDataEdicao.DataPropertyName = "DataEdicao";
            colunaDataEdicao.Width = 130;
            colunaDataEdicao.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            DataGridViewTextBoxColumn colunaTotalItens = new DataGridViewTextBoxColumn();
            colunaTotalItens.Name = "TotalItens";
            colunaTotalItens.HeaderText = "Itens";
            colunaTotalItens.DataPropertyName = "TotalItens";
            colunaTotalItens.Width = 60;

            DataGridViewTextBoxColumn colunaCriadaPor = new DataGridViewTextBoxColumn();
            colunaCriadaPor.Name = "CriadaPor";
            colunaCriadaPor.HeaderText = "Criada por";
            colunaCriadaPor.DataPropertyName = "CriadaPor";
            colunaCriadaPor.Width = 100;

            dgvCompra.Columns.Add(colunaId);
            dgvCompra.Columns.Add(colunaNome);
            dgvCompra.Columns.Add(colunaEstado);
            dgvCompra.Columns.Add(colunaDataCriacao);
            dgvCompra.Columns.Add(colunaDataEdicao);
            dgvCompra.Columns.Add(colunaTotalItens);
            dgvCompra.Columns.Add(colunaCriadaPor);
        }

        private void CarregarCompras()
        {
            string estado = combEstado.SelectedItem?.ToString() ?? "";
            if (estado == "Todas") estado = "";

            string pesquisa = txtPesquisa.Text;

            var dados = compraController.ListarCompras(estado, pesquisa);

            

            dgvCompra.DataSource = null;
            dgvCompra.DataSource = dados;
        }




        private int? ObterCompraSelecionadaId()
        {
            if (dgvCompra.CurrentRow == null)
            {
                return null;
            }

            object valor = dgvCompra.CurrentRow.Cells["Id"].Value;

            if (valor == null)
            {
                return null;
            }

            int compraId;

            if (!int.TryParse(valor.ToString(), out compraId))
            {
                return null;
            }

            return compraId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvCompra.DataSource = null; 
            Criar_Editar form = new Criar_Editar();
            form.ShowDialog();
            form.Dispose();
            CarregarCompras(); 
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? compraId = ObterCompraSelecionadaId();

            if (compraId == null)
            {
                MessageBox.Show(
                    "Selecione uma compra para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            CompraController controller = new CompraController();

            bool compraFechada = controller.CompraEstaFechada(compraId.Value);

            dgvCompra.DataSource = null;

            Criar_Editar form = new Criar_Editar(compraId.Value, compraFechada);

            form.ShowDialog();

            CarregarCompras();
        }

        private void btnModoCompra_Click(object sender, EventArgs e)
        {
            int? compraId = ObterCompraSelecionadaId();

            if (compraId == null)
            {
                MessageBox.Show(
                    "Selecione uma compra para entrar em modo compra.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            ModoCompra form = new ModoCompra((int)compraId);
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void combEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCompras();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarCompras();
        }

        private void dgvCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void combEstado_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }
    }
}