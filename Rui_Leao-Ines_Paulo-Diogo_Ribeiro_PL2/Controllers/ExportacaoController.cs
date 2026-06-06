using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    internal class ExportacaoController
    {
        public string GerarCSV()
        {
            StringBuilder sb =
                new StringBuilder();

            sb.AppendLine(
                "NomeCompra;" +
                "DataCriacao;" +
                "DataFechada;" +
                "NomeArtigo;" +
                "ArtigoPrevisto;" +
                "ArtigoNaoPrevisto;" +
                "QuantidadePrevista;" +
                "QuantidadeAdquirida;" +
                "PrecoUnitario");

            return sb.ToString();
        }

    }
}
