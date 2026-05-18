using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models
{
    public class ItemNaoPrevisto : Item
    {
        public ItemNaoPrevisto()
        {
        }

        public ItemNaoPrevisto(int id, float preco,int quantidadeAdquirida,string observacoes): base(id, preco, quantidadeAdquirida)
        {
            Observacoes = observacoes;
        }

        public string Observacoes { get; set; }
    }
}