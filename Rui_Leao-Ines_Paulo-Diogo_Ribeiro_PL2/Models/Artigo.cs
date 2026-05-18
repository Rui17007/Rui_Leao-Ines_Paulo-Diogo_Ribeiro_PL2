using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models
{
    public class Artigo
    {
        public Artigo()
        {
        }

        public Artigo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public int TipoArtigoId { get; set; }

        public TipoArtigo TipoArtigo { get; set; }
    }
}
