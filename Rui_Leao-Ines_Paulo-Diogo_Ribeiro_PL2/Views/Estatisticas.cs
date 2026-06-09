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
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers;
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Views
{
    public partial class Estatisticas : Form
    {
        private readonly EstatisticasController _controller;
        public Estatisticas()
        {
            InitializeComponent();
            _controller = new EstatisticasController();
            this.Load += Estatisticas_Load;
        }

        private void Estatisticas_Load(object sender, EventArgs e)
        {
            txtMediaOrcamento.Text = _controller.MediaOrcamento6Meses().ToString("0.00") + " €";
            txtMediaGastoMes.Text = _controller.MediaGasto6Meses().ToString("0.00") + " €";
            txtMediaGastoMesPercentagem.Text = _controller.PercentagemMedia().ToString("0.0") + "%";
            txtItensPrevistos.Text = _controller.TaxaItensPrevistos().ToString("0.0") + "%";
            txtItensNaoPrevistos.Text = _controller.ValorNaoPrevistos().ToString("0.00") + " €";
            txtItensNaoPrevistosPercentagem.Text = _controller.VariacaoNaoPrevistos().ToString("0.0") + "%";

            // Gráficos
            CarregarGraficoOrcamentos();
            CarregarGraficoGastos();
            CarregarGraficoPrevistosNaoPrevistos();
        }
        private void CarregarGraficoOrcamentos()
        {
            var dados = _controller.ObterOrcamentosUltimos6Meses();

            chartOrcamentoMes.Series.Clear();
            var serie = chartOrcamentoMes.Series.Add("Orçamento");
            serie.ChartType = SeriesChartType.Column;
            serie.Color = System.Drawing.Color.DodgerBlue;

            foreach (var o in dados)
            {
                serie.Points.AddXY(o.MesAno, o.ValorMax);
            }
        }

        private void CarregarGraficoGastos()
        {
            var dados = _controller.ObterGastosUltimos6Meses();

            chartGastoMensal.Series.Clear();
            var serie = chartGastoMensal.Series.Add("Gasto");
            serie.ChartType = SeriesChartType.Column;
            serie.Color = System.Drawing.Color.OrangeRed;

            foreach (var o in dados)
            {
                serie.Points.AddXY(o.MesAno, o.ValorAtual);
            }
        }

        private void CarregarGraficoPrevistosNaoPrevistos()
        {
            var dados = _controller.ObterPrevistosNaoPrevistos();

            chartPrevistoNaoPrevisto.Series.Clear();

            var seriePrevisto = chartPrevistoNaoPrevisto.Series.Add("Previsto");
            seriePrevisto.ChartType = SeriesChartType.Column;
            seriePrevisto.Color = System.Drawing.Color.Green;

            var serieNaoPrevisto = chartPrevistoNaoPrevisto.Series.Add("Não Previsto");
            serieNaoPrevisto.ChartType = SeriesChartType.Column;
            serieNaoPrevisto.Color = System.Drawing.Color.Red;

            foreach (var mes in dados)
            {
                seriePrevisto.Points.AddXY(mes.Mes, mes.Previstos);
                serieNaoPrevisto.Points.AddXY(mes.Mes, mes.NaoPrevistos);
            }
        }

        private void txtMediaGastoMes_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtItensPrevistos_Click(object sender, EventArgs e)
        {

        }

        private void txtItensNaoPrevistos_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chartGastoMensal_Click(object sender, EventArgs e)
        {

        }

        private void btnSugestao_Click(object sender, EventArgs e)
        {
            Sugestoes form = new Sugestoes();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void btnAnalise_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal();
            this.Hide();
            this.Close();
            form.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
