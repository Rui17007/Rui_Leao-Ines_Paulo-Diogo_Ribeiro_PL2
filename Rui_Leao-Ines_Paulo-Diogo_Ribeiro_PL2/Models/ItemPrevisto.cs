using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models
{
    public class ItemPrevisto : Item
    {
        public ItemPrevisto()
        {
        }

        public ItemPrevisto(int id, float preco,int quantidadeAdquirida,int quantidadePrevista): base(id, preco, quantidadeAdquirida)
        {
            QuantidadePrevista = quantidadePrevista;
        }

        public int QuantidadePrevista { get; set; }
    }
}