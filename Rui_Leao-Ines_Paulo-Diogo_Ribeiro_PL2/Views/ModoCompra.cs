using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers;
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
        public ModoCompra()
        {
            InitializeComponent();
            compraId = 1;
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

        }

        private void ModoCompra_Load(object sender, EventArgs e)
        {
            CarregarInformacoes();
        }

        private void CarregarInformacoes()
        {
            ItemController controller = new ItemController();
            OrcamentoController orcamento = new OrcamentoController();

            dataGridView1.DataSource = controller.ListarItens(compraId);
            dataGridView1.Columns["Id"].Visible = false;

            txtOrcamentoDinheiro.Text = orcamento.DinheiroMax().ToString() + " €";
            txtOrcamentoData.Text = DateTime.Now.ToString("MMMM yyyy");

            txtTotalDinheiro.Text = controller.DinheiroCompra(compraId).ToString() + " €";
            txtTotalQuantidade.Text = controller.QuantidadeItens(compraId).ToString() + " itens";

            txtGastoDinheiro.Text = orcamento.DinheiroAtual().ToString() + " €";
            txtRestanteDinheiro.Text = (orcamento.DinheiroMax() - orcamento.DinheiroAtual()).ToString() + " €";

            AtualizarBarra((float)orcamento.DinheiroAtual(), (float)orcamento.DinheiroMax());
        }

        private void AtualizarBarra(float gasto, float maximo)
        {
            int percentagem = (int)((gasto / maximo) * 100);

            if (percentagem > 100)
                percentagem = 100;

            progressbar.Value = percentagem;
        }
    }
}
