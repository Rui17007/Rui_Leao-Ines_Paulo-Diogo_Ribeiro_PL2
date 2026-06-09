using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    internal class ItemController
    {
        
        public object ListarItens(int compraId)
        {
            List<object> lista = new List<object>();
            lista.AddRange((IEnumerable<object>)ListarItensPrevistos(compraId));
            lista.AddRange((IEnumerable<object>)ListarItensNaoPrevistos(compraId));
            return lista;
        }

        public object ListarItensPrevistos(int compraId)
        {
            using (var db = new IShopping())
            {
                return db.ItemPrevistos
                    .Include(i => i.Compra)
                    .Where(i => i.CompraId == compraId)
                    .Select(i => new
                    {
                        i.Id,
                        Nome = i.Artigo.Nome,
                        QtdPrevista = i.QuantidadePrevista,
                        QtdComprada = i.QuantidadeAdquirida,
                        Preco = i.Preco+" €",
                        SubTotal = (i.QuantidadeAdquirida * i.Preco)+" €",
                        Origem = "Previsto"
                    })
                    .ToList();
            }
        }

        public object ListarItensNaoPrevistos(int compraId)
        {
            using (var db = new IShopping())
            {
                return db.ItensNaoPrevistos
                    .Include(i => i.Compra)
                    .Where(i => i.CompraId == compraId)
                    .Select(i => new
                    {
                        i.Id,
                        Nome = i.Artigo.Nome,
                        QtdPrevista = 0,
                        QtdComprada = i.QuantidadeAdquirida,
                        Preco = i.Preco + " €",
                        SubTotal = (i.QuantidadeAdquirida * i.Preco) + " €",
                        Origem = "Não Previsto"
                    })
                    .ToList();
            }
        }

        public float DinheiroCompra(int compraId)
        {
            using (var db = new IShopping())
            {
                return db.Itens
                    .Where(i => i.CompraId == compraId)
                    .Sum(i => i.Preco * i.QuantidadeAdquirida);
            }
        }

        public int QuantidadeItens(int compraId)
        {
            using (var db = new IShopping())
            {
                return db.Itens.Count(i => i.CompraId == compraId);
            }
        }

        public Item CriarItemNaoPrevisto()
        {
            return null;
        }
    }
}
