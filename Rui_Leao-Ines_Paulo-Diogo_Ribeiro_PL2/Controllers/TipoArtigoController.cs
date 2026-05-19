using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System.Data.Entity;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    internal class TipoArtigoController
    {
        public object Listar()
        {
            using (var db = new IShopping())
            {
                return db.TipoArtigos
                    .Include(t => t.Artigos)
                    .Select(t => new
                    {
                        t.Id,
                        t.Nome,
                        Quantidade = t.Artigos.Count()
                    })
                    .ToList();
            }
        }


        public bool Adicionar(string nome)
        {
            using (var db = new IShopping())
            {
                nome = nome.Trim();

                nome = char.ToUpper(nome[0]) + nome.Substring(1).ToLower();

                bool existe = db.TipoArtigos.Any(t => t.Nome.ToLower() == nome.ToLower());

                if (existe)
                {
                    return false;
                }

                TipoArtigo tipo = new TipoArtigo();

                tipo.Nome = nome;

                db.TipoArtigos.Add(tipo);

                db.SaveChanges();

                return true;
            }
        }

        public void Editar(int id, string nome)
        {
            using (var db = new IShopping())
            {
                TipoArtigo tipo =db.TipoArtigos.Find(id);

                if (tipo != null)
                {
                    tipo.Nome = nome;

                    db.SaveChanges();
                }
            }
        }

        public void Apagar(int id)
        {
            using (var db = new IShopping())
            {
                TipoArtigo tipo =db.TipoArtigos.Find(id);

                if (tipo != null)
                {
                    db.TipoArtigos.Remove(tipo);

                    db.SaveChanges();
                }
            }
        }
    }
}
