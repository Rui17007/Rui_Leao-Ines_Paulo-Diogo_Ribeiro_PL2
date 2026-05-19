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

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            if (utilizadorAtual != null)
            {
                string nome = utilizadorAtual.Nome;

                // Pega só o primeiro nome (melhor experiência)
                if (nome.Contains(" "))
                    nome = nome.Split(' ')[0];

                labelComprimento.Text = $"Bem vindo/a {nome}. Tens 3 compras em aberto este mês. Orçamento disponível: xxx.xx€ de xxx.xx€";
            }
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

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "Deseja terminar a sessão?",
                "Terminar Sessão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

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
    }
}
