using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Views
{
    public partial class Sugestoes : Form
    {
        public Sugestoes()
        {
            InitializeComponent();
            this.Load += Sugestoes_Load;
        }
        private void Sugestoes_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }
        private void CarregarDados()
        {
            SugestoesController controller =new SugestoesController();

            txtMediaValor.Text =controller.MediaComprasUltimos6Meses().ToString("0.00") + " €";

            txtSugestaoMes.Text =controller.ProximoMes();

            dataGridViewSugestaoCompras.DataSource =controller.ObterSugestoes();
        }
        private void richTextMediaDosUltimos6Meses_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewSugestaoCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void txtMediaValor_Click(object sender, EventArgs e)
        {

        }

        private void txtSugestaoMes_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAnalise_Click(object sender, EventArgs e)
        {
            Estatisticas form = new Estatisticas();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
