using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models
{
    public class TipoArtigo
    {
        public TipoArtigo()
        {
            Artigos = new List<Artigo>();
        }

        public TipoArtigo(int id, string nome)
        {
            Id = id;
            Nome = nome;

            Artigos = new List<Artigo>();
        }

        public int QuantidadeArtigos
        {
            get
            {
                return Artigos.Count;
            }
        }


        public int Id { get; set; }

        public string Nome { get; set; }

        public List<Artigo> Artigos { get; set; }
    }
}
