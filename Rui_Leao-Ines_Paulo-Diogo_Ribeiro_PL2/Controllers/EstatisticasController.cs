using System;
using System.Collections.Generic;
using System.Linq;
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    public class EstatisticasController
    {

        public float MediaGasto6Meses()
        {
            using (var db = new IShopping())
            {
                DateTime limite = DateTime.Now.AddMonths(-6);
                return db.Orcamentos
                    .Where(o => o.DataCriacao >= limite)
                    .Average(o => o.ValorAtual);
            }
        }

        public float MediaOrcamento6Meses()
        {
            using (var db = new IShopping())
            {
                DateTime limite = DateTime.Now.AddMonths(-6);
                return db.Orcamentos
                    .Where(o => o.DataCriacao >= limite)
                    .Average(o => o.ValorMax);
            }
        }

        public float PercentagemMedia()
        {
            float mediaOrcamento = MediaOrcamento6Meses();
            float mediaGasto = MediaGasto6Meses();

            if (mediaOrcamento == 0) return 0;
            return ((mediaGasto - mediaOrcamento) / mediaOrcamento) * 100;
        }

        public float TaxaItensPrevistos()
        {
            using (var db = new IShopping())
            {
                DateTime limite = DateTime.Now.AddMonths(-6);

                int previstos = db.ItemPrevistos
                    .Count(i => i.Compra.DataCriacao >= limite);

                int naoPrevistos = db.ItensNaoPrevistos
                    .Count(i => i.Compra.DataCriacao >= limite);

                int total = previstos + naoPrevistos;
                return total == 0 ? 0 : (previstos * 100f) / total;
            }
        }

        public float ValorNaoPrevistos()
        {
            using (var db = new IShopping())
            {
                DateTime limite = DateTime.Now.AddMonths(-6);
                return db.ItensNaoPrevistos
                    .Where(i => i.Compra.DataCriacao >= limite)
                    .Sum(i => i.Preco * i.QuantidadeAdquirida);
            }
        }

        public float VariacaoNaoPrevistos()
        {
            using (var db = new IShopping())
            {
                DateTime inicioMesAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime inicioMesAnterior = inicioMesAtual.AddMonths(-1);

                float atual = db.ItensNaoPrevistos
                    .Where(i => i.Compra.DataCriacao >= inicioMesAtual)
                    .Sum(i => (float?)i.Preco * i.QuantidadeAdquirida) ?? 0;

                float anterior = db.ItensNaoPrevistos
                    .Where(i => i.Compra.DataCriacao >= inicioMesAnterior &&
                                i.Compra.DataCriacao < inicioMesAtual)
                    .Sum(i => (float?)i.Preco * i.QuantidadeAdquirida) ?? 0;

                if (anterior == 0) return 0;

                return ((atual - anterior) / anterior) * 100;
            }
        }


        public List<MesValor> ObterOrcamentosUltimos6Meses()
        {
            using (var db = new IShopping())
            {
                DateTime limite = DateTime.Now.AddMonths(-6);

                var dados = db.Orcamentos
                    .Where(o => o.DataCriacao >= limite)
                    .GroupBy(o => new
                    {
                        o.DataCriacao.Year,
                        o.DataCriacao.Month
                    })
                    .Select(g => new
                    {
                        Ano = g.Key.Year,
                        Mes = g.Key.Month,
                        Valor = g.Average(o => o.ValorMax)
                    })
                    .ToList(); // <-- passa para memória

                return dados
                    .Select(x => new MesValor
                    {
                        MesAno = x.Ano + "-" + x.Mes.ToString("D2"),
                        ValorMax = x.Valor
                    })
                    .OrderBy(x => x.MesAno)
                    .ToList();
            }
        }

        public List<MesValor> ObterGastosUltimos6Meses()
        {
            using (var db = new IShopping())
            {
                DateTime limite = DateTime.Now.AddMonths(-6);

                var dados = db.Orcamentos
                    .Where(o => o.DataCriacao >= limite)
                    .GroupBy(o => new
                    {
                        o.DataCriacao.Year,
                        o.DataCriacao.Month
                    })
                    .Select(g => new
                    {
                        Ano = g.Key.Year,
                        Mes = g.Key.Month,
                        Valor = g.Average(o => o.ValorAtual)
                    })
                    .ToList();

                return dados
                    .Select(x => new MesValor
                    {
                        MesAno = x.Ano + "-" + x.Mes.ToString("D2"),
                        ValorAtual = x.Valor
                    })
                    .OrderBy(x => x.MesAno)
                    .ToList();
            }
        }

        public List<MesPrevistoNaoPrevisto> ObterPrevistosNaoPrevistos()
        {
            using (var db = new IShopping())
            {
                DateTime limite = DateTime.Now.AddMonths(-6);

                var dados = db.Orcamentos
    .Where(o => o.DataCriacao >= limite)
    .GroupBy(o => new
    {
        o.DataCriacao.Year,
        o.DataCriacao.Month
    })
    .Select(g => new
    {
        Ano = g.Key.Year,
        MesNumero = g.Key.Month,

        Previstos = db.ItemPrevistos.Count(i =>
            i.Compra.DataCriacao.Year == g.Key.Year &&
            i.Compra.DataCriacao.Month == g.Key.Month),

        NaoPrevistos = db.ItensNaoPrevistos.Count(i =>
            i.Compra.DataCriacao.Year == g.Key.Year &&
            i.Compra.DataCriacao.Month == g.Key.Month)
    })
    .ToList();
                return dados
    .Select(x => new MesPrevistoNaoPrevisto
    {
        Mes = x.Ano + "-" + x.MesNumero.ToString("D2"),
        Previstos = x.Previstos,
        NaoPrevistos = x.NaoPrevistos
    })
    .OrderBy(x => x.Mes)
    .ToList();

            }
        }
    }


    public class MesValor
    {
        public string MesAno { get; set; }
        public float ValorMax { get; set; }
        public float ValorAtual { get; set; }
    }

    public class MesPrevistoNaoPrevisto
    {
        public string Mes { get; set; }
        public int Previstos { get; set; }
        public int NaoPrevistos { get; set; }
    }
}