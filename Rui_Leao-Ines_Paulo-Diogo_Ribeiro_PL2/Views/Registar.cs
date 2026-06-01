using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Converter password para bytes
                byte[] bytes = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(password)
                );

                // Converter bytes para string
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            string nomeUtilizador = txtUsername.Text;
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string nif = txtNif.Text;

            // Verificar campos vazios
            if (string.IsNullOrEmpty(txtUsername.Text) ||
                string.IsNullOrEmpty(txtNome.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtNif.Text))
            {
                MessageBox.Show(
                    "Por favor escreva em todos os campos obrigatorios"
                );

                return;
            }

            // Encriptar password
            string passwordEncriptada = HashPassword(password);

            // Registar utilizador
            RegistarController controller = new RegistarController();

            bool sucesso = controller.RegistarUtilizador(
                nomeUtilizador,
                nome,
                passwordEncriptada,
                nif,
                email
            );

            if (sucesso)
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
