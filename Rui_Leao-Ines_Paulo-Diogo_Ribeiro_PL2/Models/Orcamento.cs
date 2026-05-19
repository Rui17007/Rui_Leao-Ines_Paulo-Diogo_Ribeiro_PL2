using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models
{
    public class Orcamento
    {
        public int Id { get; set; }

        public string MesAno { get; set; }

        public float ValorMax { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public float ValorAtual { get; set; }

        public string CriadoPor { get; set; }

        public string AlteradoPor { get; set; }

        public int UtilizadorId { get; set; }

        public Utilizador Utilizador { get; set; }
    }
}
