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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2;
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;


namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Views
{
    public partial class Orcamento : Form
    {
        private bool modoEdicao = false;

        private int idSelecionado = 0;

        private Models.Orcamento orcamentoOriginal;


        public Orcamento()
        {
            InitializeComponent();
        }


        private void BloquearCampos()
        {
            txtValorMaximo.Enabled = false;

            txtCriadoPor.Enabled = false;

            textAlteradoPor.Enabled = false;

            textDataCriacao.Enabled = false;

            textDataAlteracao.Enabled = false;
        }


        private void CarregarTabela()
        {
            OrcamentoController controller = new OrcamentoController();

            dataGridView1.DataSource = controller.Listar();

            dataGridView1.Columns["Id"].Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelPercentagem_Click(object sender, EventArgs e)
        {

        }

        private void btnVerHistorico_Click(object sender, EventArgs e)
        {
            if (idSelecionado > 0)
            {
                modoEdicao = true;

                txtValorMaximo.Enabled = true;

                txtValorMaximo.Focus();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            modoEdicao = false;

            idSelecionado = 0;

            txtValorMaximo.Text = "";

            txtValorMaximo.Enabled = true;

            txtValorMaximo.Focus();

            textDataCriacao.Text =
                DateTime.Now.ToString(
                    "MMMM yyyy",
                    new System.Globalization.CultureInfo("pt-PT"));

            txtCriadoPor.Text = Sessao.UtilizadorAtual.NomeUtilizador;

            textAlteradoPor.Text = "";

            textDataAlteracao.Text = "";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void Orcamento_Load(object sender, EventArgs e)
        {
            CarregarTabela();

            BloquearCampos();

        }

        private void txtValorMaximo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textDataCriacao_TextChanged(object sender, EventArgs e)
        {

        }

        private void textDataAlteracao_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressbar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            OrcamentoController controller = new OrcamentoController();

            float valor = Convert.ToSingle(txtValorMaximo.Text);

            if (modoEdicao)
            {
                controller.Editar(idSelecionado, valor, Sessao.UtilizadorAtual);  

                MessageBox.Show("Orçamento editado");
            }
            else
            {
                bool sucesso = controller.Adicionar(valor, Sessao.UtilizadorAtual);

                if (sucesso)
                {
                    MessageBox.Show("Orçamento criado");
                }
                else
                {
                    MessageBox.Show("Já existe um orçamento este mês");

                    return;
                }
            }

            CarregarTabela();

            txtValorMaximo.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (orcamentoOriginal != null)
            {
                txtValorMaximo.Text = orcamentoOriginal.ValorMax.ToString("0.00");

                txtCriadoPor.Text = orcamentoOriginal.CriadoPor;

                textDataCriacao.Text = orcamentoOriginal.MesAno;

                textAlteradoPor.Text = orcamentoOriginal.AlteradoPor;

                if (orcamentoOriginal.DataAlteracao != null)
                {
                    textDataAlteracao.Text =
                        Convert.ToDateTime(
                            orcamentoOriginal.DataAlteracao)
                        .ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    textDataAlteracao.Text = "";
                }

                AtualizarBarra(orcamentoOriginal.ValorAtual, orcamentoOriginal.ValorMax);
            }

            txtValorMaximo.Enabled = false;

            modoEdicao = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSelecionado =
                    Convert.ToInt32(
                        dataGridView1.Rows[e.RowIndex]
                        .Cells["Id"].Value);

                OrcamentoController controller = new OrcamentoController();

                orcamentoOriginal = controller.Procurar(idSelecionado);

                txtValorMaximo.Text = orcamentoOriginal.ValorMax.ToString("0.00");

                txtCriadoPor.Text = orcamentoOriginal.CriadoPor;

                textDataCriacao.Text = orcamentoOriginal.MesAno;

                textAlteradoPor.Text = orcamentoOriginal.AlteradoPor;

                if (orcamentoOriginal.DataAlteracao != null)
                {
                    textDataAlteracao.Text =
                        Convert.ToDateTime(
                            orcamentoOriginal.DataAlteracao)
                        .ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    textDataAlteracao.Text = "";
                }

                AtualizarBarra(
                    orcamentoOriginal.ValorAtual,
                    orcamentoOriginal.ValorMax);
            }
        }
        private void AtualizarBarra(float gasto,float maximo)
        {
            int percentagem = (int)((gasto / maximo) * 100);

            if (percentagem > 100)
            {
                percentagem = 100;
            }

            progressbar.Value =
                percentagem;

            float falta = maximo - gasto;

            if (falta < 0)
            {
                falta = 0;
            }

            labelPercentagem.Text = percentagem + "% • " + gasto.ToString("0.00") + " / " + maximo.ToString("0.00") + " €";}

        public float CalcularGastoMesAtual()
        {
            using (var db = new IShopping())
            {
                string mesAtual = DateTime.Now.ToString("MMMM yyyy",new System.Globalization.CultureInfo("pt-PT"));

                Models.Orcamento orcamento =
                    db.Orcamentos.FirstOrDefault(o => o.MesAno == mesAtual);

                if (orcamento != null)
                {
                    return orcamento.ValorAtual;
                }

                return 0;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
