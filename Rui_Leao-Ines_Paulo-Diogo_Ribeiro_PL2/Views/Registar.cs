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
    public partial class Registar : Form
    {
        public Registar()
        {
            InitializeComponent();
        }

        private void Registar_Load(object sender, EventArgs e)
        {

        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            string nomeUtilizador= txtUsername.Text;
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string nif = txtNif.Text;

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtNif.Text))
            {
                MessageBox.Show("Por favor escreva em todos os campos obrigatorios");
                return;
            }

            RegistarController controller = new RegistarController();
            bool sucesso = controller.RegistarUtilizador(nomeUtilizador, nome, password, nif, email);
            if(sucesso)
            {
                Login form = new Login();
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Dados invalidos");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            this.Hide();
            this.Close();
            form.ShowDialog();
            
        }
    }
}
