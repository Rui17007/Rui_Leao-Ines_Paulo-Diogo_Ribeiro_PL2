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
    public partial class Artigo : Form
    {
        private bool modoEdicao = false;
        public Artigo()
        {
            InitializeComponent();
        }
        private void Artigo_Load(object sender, EventArgs e)
        {
            CarregarTabela();

            CarregarTipos();

            CarregarFiltros();

            txtId.Enabled = false;

            txtNome.Enabled = false;

            comboTipoArtigo.Enabled = false;
        }
        private void CarregarTabela()
        {
            ArtigoController controller =new ArtigoController();

            dataGridView1.DataSource = controller.Listar();

            dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.Columns["TipoArtigoId"].Visible = false;

        }

        private void CarregarTipos()
        {
            ArtigoController controller =new ArtigoController();

            comboTipoArtigo.DataSource =controller.ListarTipos();

            comboTipoArtigo.DisplayMember = "Nome";

            comboTipoArtigo.ValueMember = "Id";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dataGridView1.Rows[e.RowIndex];

                txtId.Text =
                    row.Cells["Id"].Value.ToString();

                txtNome.Text =
                    row.Cells["Nome"].Value.ToString();

                comboTipoArtigo.SelectedValue =
                    row.Cells["TipoArtigoId"].Value;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
                
                    modoEdicao = false;

                    txtId.Text = "";

                    txtNome.Text = "";

                    txtNome.Enabled = true;

                    txtNome.Focus();

                    comboTipoArtigo.Enabled = true;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
                if (txtId.Text != "")
                {
                    modoEdicao = true;

                    txtNome.Enabled = true;

                    comboTipoArtigo.Enabled = true;
                }
            }

        private void btnApagar_Click(object sender, EventArgs e)
        {
                if (txtId.Text != "")
                {
                    DialogResult resultado =
                        MessageBox.Show(
                            "Deseja apagar este artigo?",
                            "Confirmação",
                            MessageBoxButtons.YesNo
                        );

                    if (resultado == DialogResult.Yes)
                    {
                        ArtigoController controller =
                            new ArtigoController();

                        controller.Apagar(
                            Convert.ToInt32(txtId.Text));

                        CarregarTabela();

                        txtId.Text = "";

                        txtNome.Text = "";

                        MessageBox.Show("Artigo apagado");
                    }
                }
            }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";

            txtNome.Text = "";

            txtNome.Enabled = false;

            comboTipoArtigo.Enabled = false;

            modoEdicao = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
                ArtigoController controller =
        new ArtigoController();

                if (modoEdicao)
                {
                    bool sucesso = controller.Editar(
                        Convert.ToInt32(txtId.Text),
                        txtNome.Text,
                        Convert.ToInt32(comboTipoArtigo.SelectedValue)
                    );

                    if (sucesso)
                    {
                        MessageBox.Show("Artigo editado");
                    }
                    else
                    {
                        MessageBox.Show("Já existe um artigo com esse nome");

                        return;
                    }
                }
                else
                {
                    bool sucesso = controller.Adicionar(
                        txtNome.Text,
                        Convert.ToInt32(comboTipoArtigo.SelectedValue)
                    );

                    if (sucesso)
                    {
                        MessageBox.Show("Artigo adicionado");
                    }
                    else
                    {
                        MessageBox.Show("Já existe um artigo com esse nome");

                        return;
                    }
                }

                CarregarTabela();

                txtId.Text = "";

                txtNome.Text = "";

                txtNome.Enabled = false;
                comboTipoArtigo.Enabled = false;    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void CarregarFiltros()
        {
            ArtigoController controller =
                new ArtigoController();

            List<Models.TipoArtigo> lista =
                controller.ListarTipos();

            lista.Insert(0, new Models.TipoArtigo
            {
                Id = 0,
                Nome = "Tudo"
            });

            comboFiltros.DataSource = lista;

            comboFiltros.DisplayMember = "Nome";

            comboFiltros.ValueMember = "Id";

            comboFiltros.SelectedIndex = 0;
        }
        private void comboFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFiltros.SelectedItem != null)
            {
                int tipoId =
                    ((Models.TipoArtigo)comboFiltros.SelectedItem).Id;

                ArtigoController controller =
                    new ArtigoController();

                if (tipoId == 0)
                {
                    dataGridView1.DataSource =
                        controller.Listar();
                }
                else
                {
                    dataGridView1.DataSource =
                        controller.FiltrarPorTipo(tipoId);
                }

                if (dataGridView1.Columns["TipoArtigoId"] != null)
                {
                    dataGridView1.Columns["TipoArtigoId"].Visible = false;
                }
            }
        }
    }
}
