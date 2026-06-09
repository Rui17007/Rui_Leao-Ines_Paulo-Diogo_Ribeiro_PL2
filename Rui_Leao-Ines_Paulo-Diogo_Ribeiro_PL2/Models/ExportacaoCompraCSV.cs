using System;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models
{
    public class ExportacaoCompraCSV
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataEdicao { get; set; }
        public DateTime? DataFecho { get; set; }
        public int TotalItens { get; set; }
        public string CriadaPor { get; set; }

        public string NomeCompra { get; set; }
        public DateTime? DataFechada { get; set; }

        public string TipoArtigo { get; set; }        
        public string TipoItem { get; set; }          

        public string NomeArtigo { get; set; }

        public int? QuantidadePrevista { get; set; }
        public int QuantidadeAdquirida { get; set; }
        public float PrecoUnitario { get; set; }
    }
}
