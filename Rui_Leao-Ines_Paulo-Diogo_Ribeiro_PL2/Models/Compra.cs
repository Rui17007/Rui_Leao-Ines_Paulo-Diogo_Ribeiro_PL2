using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models
{
    public class Compra
    {
        public Compra() 
        {
            Itens = new List<Item>();   
        }
        public Compra(int id, string nome, DateTime? dataFecho, DateTime dataCriacao, DateTime dataEdicao)
        {
            Id = id;
            Nome = nome;
            DataFecho = dataFecho;
            DataCriacao = dataCriacao;
            DataEdicao = dataEdicao;
            Itens = new List<Item>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime? DataFecho { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataEdicao { get; set; }

        public int UtilizadorId { get; set; }

        public Utilizador Utilizador { get; set; }

        public List<Item> Itens { get; set; }
    }
}
