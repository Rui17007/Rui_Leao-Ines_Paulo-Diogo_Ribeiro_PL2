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
    public partial class MenuPrincipal : Form
    {
        private Utilizador utilizadorAtual;

        public MenuPrincipal(Utilizador utilizador)
        {
            InitializeComponent();
            utilizadorAtual = utilizador;
        }
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        private void ConfigurarGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 50
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Compra",
                DataPropertyName = "Nome",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataCriacao",
                HeaderText = "Criada em",
                DataPropertyName = "DataCriacao",
                Width = 120
            });

            DataGridViewButtonColumn btnModoCompra = new DataGridViewButtonColumn();

            btnModoCompra.Name = "ModoCompra";
            btnModoCompra.HeaderText = "";
            btnModoCompra.Text = "Abrir";
            btnModoCompra.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(btnModoCompra);
        }
        private void CarregarComprasAbertas()
        {
            CompraController controller = new CompraController();

            var compras = controller.ListarCompras("Aberta", "");

            dataGridView1.DataSource = compras;
        }
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            if (utilizadorAtual != null)
            {
                string nome = utilizadorAtual.Nome;

                if (nome.Contains(" "))
                    nome = nome.Split(' ')[0];

                CompraController compraController = new CompraController();
                OrcamentoController orcamentoController = new OrcamentoController();

                var comprasAbertas =
                    compraController.ListarCompras("Aberta", "");

                int totalComprasAbertas = comprasAbertas.Count;

                float gasto = (float)orcamentoController.DinheiroAtual();
                float maximo = (float)orcamentoController.DinheiroMax();

                float disponivel = maximo - gasto;

                labelComprimento.Text =
                    $"Bem vindo/a {nome}. " +
                    $"Tens {totalComprasAbertas} compras em aberto este mês. " +
                    $"Orçamento disponível: {disponivel:F2}€ de {maximo:F2}€";
            }

            ConfigurarGrid();
            CarregarComprasAbertas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipoArtigo form = new TipoArtigo();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnArtigo_Click(object sender, EventArgs e)
        {
            Artigo form = new Artigo();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "ModoCompra")
            {
                int compraId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                ModoCompra form = new ModoCompra(compraId);

                this.Hide();
                form.ShowDialog();
                this.Show();

                CarregarComprasAbertas();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja terminar a sessão?","Terminar Sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {

                Login form = new Login();
                this.Hide();
                this.Close();
                form.ShowDialog();
            }
        }

        private void btnOrcamentos_Click(object sender, EventArgs e)
        {
            Orcamento form = new Orcamento();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

<<<<<<< HEAD
        private void chart1_Click(object sender, EventArgs e)
=======
        private void btnPlaneamento_Click(object sender, EventArgs e)
        {
            Planeamento form = new Planeamento();
            form.ShowDialog();
            form.Dispose();
        }

        private void btnModoCompra_Click(object sender, EventArgs e)
        {
            ModoCompra form = new ModoCompra();
            form.ShowDialog();
            form.Dispose();
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            Exportar form = new Exportar();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnEstatisticas_Click(object sender, EventArgs e)
        {
            Estatisticas form = new Estatisticas();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPlaneamento_Click_1(object sender, EventArgs e)
        {
            Planeamento form = new Planeamento();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnTipoArtigos_Click(object sender, EventArgs e)
        {
            TipoArtigo form = new TipoArtigo();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnArtigo_Click_1(object sender, EventArgs e)
        {
            Artigo form = new Artigo();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnOrcamentos_Click_1(object sender, EventArgs e)
        {
            Orcamento form = new Orcamento();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnEstatisticas_Click_1(object sender, EventArgs e)
        {
            Estatisticas form = new Estatisticas();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnCSV_Click_1(object sender, EventArgs e)
        {
            Exportar form = new Exportar();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void labelComprimento_Click(object sender, EventArgs e)
>>>>>>> b7e5c60 (Projeto completo sem Read.Me)
        {

        }
    }
}
