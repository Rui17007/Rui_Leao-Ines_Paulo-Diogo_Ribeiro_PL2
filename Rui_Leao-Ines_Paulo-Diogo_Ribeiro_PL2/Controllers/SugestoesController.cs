using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    public class SugestoesController
    {
        public float MediaComprasUltimos6Meses()
        {
            using (var db = new IShopping())
            {
                DateTime limite = DateTime.Now.AddMonths(-6);

                var comprasFechadas = db.Compras
                    .Where(c => c.DataFecho != null && c.DataFecho >= limite)
                    .Select(c => c.Itens.Sum(i => i.Preco * i.QuantidadeAdquirida))
                    .ToList();

                if (!comprasFechadas.Any())
                    return 0;

                return comprasFechadas.Average();
            }
        }

        public string ProximoMes()
        {
            DateTime proximoMes = DateTime.Now.AddMonths(1);

            return proximoMes.ToString("MMMM - yyyy");
        }

        public List<SugestaoCompraViewModel> ObterSugestoes()
        {
            using (var db = new IShopping())
            {
                DateTime limite = DateTime.Now.AddMonths(-6);

                var dados = db.Itens
                    .Where(i => i.Compra.DataFecho != null && i.Compra.DataFecho >= limite)
                    .GroupBy(i => new
                    {
                        Artigo = i.Artigo.Nome
                    })
                    .Select(g => new SugestaoCompraViewModel
                    {
                        Artigo = g.Key.Artigo,

                        FrequenciaMes = g.Count() / 6.0,

                        QuantidadePrevista = (int)Math.Round(g.Average(x => x.QuantidadeAdquirida))
                    })
                    .OrderByDescending(x => x.FrequenciaMes)
                    .ToList();

                return dados;
            }
        }
    }

    public class SugestaoCompraViewModel
    {
        public string Artigo { get; set; }

        public double FrequenciaMes { get; set; }

        public int QuantidadePrevista { get; set; }
    }
}