using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    internal class ArtigoController
    {
        public object Listar()
        {
            using (var db = new IShopping())
            {
                return db.Artigos
                    .Include(a => a.TipoArtigo)
                    .Select(a => new
                    {
                        a.Id,
                        a.Nome,
                        Tipo = a.TipoArtigo.Nome,
                        a.TipoArtigoId
                    })
                    .ToList();
            }
        }

        public List<TipoArtigo> ListarTipos()
        {
            using (var db = new IShopping())
            {
                return db.TipoArtigos.ToList();
            }
        }

        public bool Adicionar(
            string nome,
            int tipoArtigoId)
        {
            using (var db = new IShopping())
            {
                nome = nome.Trim();

                nome = char.ToUpper(nome[0]) +
                       nome.Substring(1).ToLower();

                bool existe = db.Artigos.Any(a =>
                    a.Nome.ToLower() == nome.ToLower());

                if (existe)
                {
                    return false;
                }

                Artigo artigo = new Artigo();

                artigo.Nome = nome;

                artigo.TipoArtigoId = tipoArtigoId;

                db.Artigos.Add(artigo);

                db.SaveChanges();

                return true;
            }
        }

        public bool Editar(
            int id,
            string nome,
            int tipoArtigoId)
        {
            using (var db = new IShopping())
            {
                nome = nome.Trim();

                nome = char.ToUpper(nome[0]) +
                       nome.Substring(1).ToLower();

                bool existe = db.Artigos.Any(a =>
                    a.Nome.ToLower() == nome.ToLower()
                    && a.Id != id);

                if (existe)
                {
                    return false;
                }

                Artigo artigo = db.Artigos.Find(id);

                if (artigo != null)
                {
                    artigo.Nome = nome;

                    artigo.TipoArtigoId = tipoArtigoId;

                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public void Apagar(int id)
        {
            using (var db = new IShopping())
            {
                Artigo artigo = db.Artigos.Find(id);

                if (artigo != null)
                {
                    db.Artigos.Remove(artigo);

                    db.SaveChanges();
                }
            }
        }

        public object FiltrarPorTipo(int tipoArtigoId)
        {
            using (var db = new IShopping())
            {
                return db.Artigos
                    .Include(a => a.TipoArtigo)
                    .Where(a => a.TipoArtigoId == tipoArtigoId)
                    .Select(a => new
                    {
                        a.Id,
                        a.Nome,
                        Tipo = a.TipoArtigo.Nome,
                        a.TipoArtigoId
                    })
                    .ToList();
            }
        }
    }
}