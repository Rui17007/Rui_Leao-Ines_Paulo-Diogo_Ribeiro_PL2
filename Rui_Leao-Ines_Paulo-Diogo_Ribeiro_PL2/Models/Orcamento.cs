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
        public Orcamento()
        {

        }

        public Orcamento(int id, float valorMax,DateTime dataInicio, DateTime dataFim,DateTime dataCriacao, DateTime dataAlteracao,float valorAtual)
        {
            Id = id;
            ValorMax = valorMax;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            ValorAtual = valorAtual;
        }
        public int Id { get; set; }

        public float ValorMax { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }

        public float ValorAtual { get; set; }

        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}
