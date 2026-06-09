using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2
{
    public class IShopping : DbContext
    {
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<TipoArtigo> TipoArtigos { get; set; } 
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<ItemNaoPrevisto> ItensNaoPrevistos { get; set; }
        public DbSet<ItemPrevisto> ItemPrevistos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }

    }
}
