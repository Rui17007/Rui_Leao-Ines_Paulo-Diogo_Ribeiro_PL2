<<<<<<< HEAD
﻿using System;
=======
﻿using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers;
using System;
>>>>>>> b7e5c60 (Projeto completo sem Read.Me)
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
    public partial class Exportar : Form
    {
        public Exportar()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
=======
        private void Exportar_Load(object sender, EventArgs e)
        {
            CompraController controller = new CompraController();

            dataGridViewComprasSelecionar.DataSource = controller.ListarCompras("", "");

            DataGridViewCheckBoxColumn colunaSelecionar = new DataGridViewCheckBoxColumn();

            colunaSelecionar.Name = "Selecionar";
            colunaSelecionar.HeaderText = "Selecionar";

            dataGridViewComprasSelecionar.Columns.Insert(0, colunaSelecionar);
        }
        private void btnPreVisualizar_Click(object sender, EventArgs e)
        {
            CompraController controller = new CompraController();
            var dados = controller.ExportarComprasFechadasCSV();

            StringBuilder csv = new StringBuilder();

            // Cabeçalho atualizado
            csv.AppendLine(
                "NomeCompra;" +
                "DataCriacao;" +
                "DataFechada;" +
                "TipoArtigo;" +
                "TipoItem;" +
                "NomeArtigo;" +
                "QuantidadePrevista;" +
                "QuantidadeAdquirida;" +
                "PrecoUnitario"
            );

            foreach (var linha in dados)
            {
                csv.AppendLine(
                    linha.NomeCompra + ";" +
                    linha.DataCriacao.ToShortDateString() + ";" +
                    (linha.DataFechada?.ToShortDateString() ?? "") + ";" +
                    linha.TipoArtigo + ";" +
                    linha.TipoItem + ";" +
                    linha.NomeArtigo + ";" +
                    (linha.QuantidadePrevista?.ToString() ?? "") + ";" +
                    linha.QuantidadeAdquirida + ";" +
                    linha.PrecoUnitario
                );
            }

            richTxtPreVisualizacao.Text = csv.ToString();
        }

        private void txtCaminhoFicheiro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNomeFicheiro_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewComprasSelecionar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSelecionarCaminho_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCaminhoFicheiro.Text))
            {
                MessageBox.Show("Indique um caminho.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNomeFicheiro.Text))
            {
                MessageBox.Show("Indique um nome.");
                return;
            }

            string caminhoCompleto = System.IO.Path.Combine(txtCaminhoFicheiro.Text, txtNomeFicheiro.Text + ".csv");

            System.IO.File.WriteAllText(caminhoCompleto, richTxtPreVisualizacao.Text, Encoding.UTF8);

            MessageBox.Show("Ficheiro exportado com sucesso.");

        }

        private void richTxtPreVisualizacao_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSelecionarCaminho_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "CSV (*.csv)|*.csv";

            dlg.Title = "Selecionar local para guardar";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtCaminhoFicheiro.Text = System.IO.Path.GetDirectoryName(dlg.FileName);

                txtNomeFicheiro.Text = System.IO.Path.GetFileNameWithoutExtension(dlg.FileName);
            }

        }

        private void btnSelecionarCaminho_Click_2(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "CSV (*.csv)|*.csv";

            dlg.Title = "Selecionar local para guardar";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtCaminhoFicheiro.Text = System.IO.Path.GetDirectoryName(dlg.FileName);

                txtNomeFicheiro.Text = System.IO.Path.GetFileNameWithoutExtension(dlg.FileName);
            }

        }
>>>>>>> b7e5c60 (Projeto completo sem Read.Me)
    }
}
