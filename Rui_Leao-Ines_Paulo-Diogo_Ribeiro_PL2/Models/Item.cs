using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models
{
    public class Item
    {
        public Item()
        {
        }

        public Item(int id, float preco,
            int quantidadeAdquirida)
        {
            Id = id;
            Preco = preco;
            QuantidadeAdquirida = quantidadeAdquirida;
        }

        public int Id { get; set; }

        public float Preco { get; set; }

        public int QuantidadeAdquirida { get; set; }

        public int CompraId { get; set; }

        public Compra Compra { get; set; }

        public int ArtigoId { get; set; }

        public Artigo Artigo { get; set; }
    }
}
