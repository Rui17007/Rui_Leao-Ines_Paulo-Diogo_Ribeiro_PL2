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
    public partial class TipoArtigo : Form
    {
        private bool modoEdicao = false;
        public TipoArtigo()
        {
            InitializeComponent();

        }
        private void TipoArtigo_Load(object sender, EventArgs e)
        {
            CarregarTabela();

            txtId.Enabled = false;
            txtNome.Enabled = false;
        }
        private void CarregarTabela()
        {
            TipoArtigoController controller = new TipoArtigoController();

            dataGridView1.DataSource = controller.Listar();

            if (dataGridView1.Columns["Artigos"] != null)
            {
                dataGridView1.Columns["Artigos"].Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            modoEdicao = false;

            txtId.Text = "";
            txtNome.Text = "";

            txtNome.Enabled = true;

            txtNome.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                modoEdicao = true;

                txtNome.Enabled = true;

                txtId.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                DialogResult resultado = MessageBox.Show(
                    "Deseja apagar este tipo de artigo?",
                    "Confirmação",
                    MessageBoxButtons.YesNo
                );

                if (resultado == DialogResult.Yes)
                {
                    TipoArtigoController controller = new TipoArtigoController();

                    controller.Apagar(Convert.ToInt32(txtId.Text));

                    CarregarTabela();

                    txtId.Text = "";
                    txtNome.Text = "";

                    MessageBox.Show("Tipo de artigo apagado");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            modoEdicao = false;

            txtId.Text = "";
            txtNome.Text = "";

            txtNome.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TipoArtigoController controller = new TipoArtigoController();

            if (modoEdicao)
            {
                controller.Editar(Convert.ToInt32(txtId.Text),txtNome.Text);

                MessageBox.Show("Tipo de artigo editado com sucesso");
            }
            else
            {
                bool sucesso = controller.Adicionar(txtNome.Text);

                if (sucesso)
                {
                    MessageBox.Show("Tipo de artigo adicionado com sucesso");
                }
                else
                {
                    MessageBox.Show("Já existe um tipo com esse nome");

                    return;
                }
            }

            CarregarTabela();

            txtId.Text = "";
            txtNome.Text = "";

            txtNome.Enabled = false;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTxtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPesquisar_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtId.Text = row.Cells["Id"].Value.ToString();

                txtNome.Text = row.Cells["Nome"].Value.ToString();
            }
        }
    }
}
