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
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Views;
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nome = txtEmailUtilizador.Text;
            string password = txtPassword.Text;

            LoginController loginController = new LoginController();
            Utilizador utilizador = loginController.login(nome, password);
            if (utilizador != null)
            {
                MenuPrincipal form = new MenuPrincipal();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Dados invalidos");

            }
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            Registar form = new Registar();
            this.Hide();
            form.ShowDialog();
            this.Show();
            
        }
    }
}
