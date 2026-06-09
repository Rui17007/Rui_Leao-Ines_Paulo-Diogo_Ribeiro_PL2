using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    public class CompraController
    {
        public List<TipoArtigo> ListarTipos()
        {
            using (IShopping db = new IShopping())
            {
                return db.TipoArtigos
                    .OrderBy(t => t.Nome)
                    .ToList();
            }
        }

        public List<Artigo> ListarArtigos()
        {
            using (IShopping db = new IShopping())
            {
                return db.Artigos
                    .Include(a => a.TipoArtigo)
                    .OrderBy(a => a.Nome)
                    .ToList();
            }
        }

        public List<Artigo> ListarArtigosPorTipo(int tipoArtigoId)
        {
            using (IShopping db = new IShopping())
            {
                return db.Artigos
                    .Include(a => a.TipoArtigo)
                    .Where(a => a.TipoArtigoId == tipoArtigoId)
                    .OrderBy(a => a.Nome)
                    .ToList();
            }
        }
        public bool CompraEstaFechada(int compraId)
        {
            using (IShopping db = new IShopping())
            {
                Compra compra = db.Compras.Find(compraId);

                if (compra == null)
                    return false;

                return compra.DataFecho != null;
            }
        }
        public List<ExportacaoCompraCSV> ListarCompras(string estado, string pesquisa)
        {
            using (IShopping db = new IShopping())
            {
                var query = db.Compras
                    .Include(c => c.Utilizador)
                    .Include(c => c.Itens)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(estado))
                {
                    if (estado == "Aberta")
                        query = query.Where(c => c.DataFecho == null);
                    else if (estado == "Fechada")
                        query = query.Where(c => c.DataFecho != null);
                }

                if (!string.IsNullOrWhiteSpace(pesquisa))
                {
                    string texto = pesquisa.Trim().ToLower();
                    query = query.Where(c => c.Nome.ToLower().Contains(texto));
                }

                return query
                    .OrderByDescending(c => c.DataCriacao)
                    .Select(c => new ExportacaoCompraCSV
                    {
                        Id = c.Id,
                        Nome = c.Nome,
                        Estado = c.DataFecho == null ? "Aberta" : "Fechada",
                        DataCriacao = c.DataCriacao,
                        DataEdicao = c.DataEdicao,
                        DataFecho = c.DataFecho,
                        TotalItens = c.Itens.Count(),
                        CriadaPor = c.Utilizador != null ? c.Utilizador.NomeUtilizador : ""
                    })
                    .ToList();
            }
        }


        public Compra ProcurarCompra(int compraId)
        {
            using (IShopping db = new IShopping())
            {
                return db.Compras
                    .Include(c => c.Utilizador)
                    .Include(c => c.Itens.Select(i => i.Artigo))
                    .Include(c => c.Itens.Select(i => i.Artigo.TipoArtigo))
                    .FirstOrDefault(c => c.Id == compraId);
            }
        }



        public int Adicionar(string nomeCompra, int utilizadorId, List<Item> itens)
        {
            if (string.IsNullOrWhiteSpace(nomeCompra))
            {
                throw new ArgumentException("O nome da compra é obrigatório.");
            }

            if (itens == null || itens.Count == 0)
            {
                throw new ArgumentException("A compra tem de ter pelo menos um item.");
            }

            using (IShopping db = new IShopping())
            {
                DateTime agora = DateTime.Now;

                Compra compra = new Compra
                {
                    Nome = nomeCompra.Trim(),
                    DataCriacao = agora,
                    DataEdicao = agora,
                    DataFecho = null,
                    UtilizadorId = utilizadorId,
                    Itens = new List<Item>()
                };

                foreach (Item item in itens)
                {
                    AdicionarItemNaCompra(compra, item);
                }

                db.Compras.Add(compra);
                db.SaveChanges();

                return compra.Id;
            }
        }

        public bool Editar(int compraId, string nomeCompra, List<Item> itens)
        {
            if (string.IsNullOrWhiteSpace(nomeCompra))
            {
                throw new ArgumentException("O nome da compra é obrigatório.");
            }

            if (itens == null || itens.Count == 0)
            {
                throw new ArgumentException("A compra tem de ter pelo menos um item.");
            }

            using (IShopping db = new IShopping())
            {
                Compra compra = db.Compras
                    .Include(c => c.Itens)
                    .FirstOrDefault(c => c.Id == compraId);

                if (compra == null)
                {
                    return false;
                }

                compra.Nome = nomeCompra.Trim();
                compra.DataEdicao = DateTime.Now;

                List<Item> itensAntigos = compra.Itens.ToList();

                foreach (Item itemAntigo in itensAntigos)
                {
                    db.Itens.Remove(itemAntigo);
                }

                foreach (Item itemNovo in itens)
                {
                    AdicionarItemNaCompra(compra, itemNovo);
                }

                db.SaveChanges();

                return true;
            }
        }

        public bool FecharCompra(int compraId)
        {
            using (IShopping db = new IShopping())
            {
                Compra compra = db.Compras
                    .Include(c => c.Itens)
                    .FirstOrDefault(c => c.Id == compraId);

                if (compra == null)
                    return false;

                if (compra.DataFecho != null)
                    return false;

                bool existemPorPreencher =
                    compra.Itens.Any(i =>
                        i.QuantidadeAdquirida <= 0 ||
                        i.Preco <= 0);

                if (existemPorPreencher)
                {
                    MessageBox.Show(
                        "Existem itens sem quantidade ou preço preenchido.");
                    return false;
                }

                float totalCompra = compra.Itens
                    .Sum(i => i.Preco * i.QuantidadeAdquirida);

                string mesAtual = DateTime.Now.ToString(
                    "MMMM yyyy",
                    new System.Globalization.CultureInfo("pt-PT"));

                Orcamento orcamento = db.Orcamentos
                    .FirstOrDefault(o => o.MesAno == mesAtual);

                if (orcamento != null)
                {
                    orcamento.ValorAtual += totalCompra;
                    orcamento.DataAlteracao = DateTime.Now;
                    orcamento.AlteradoPor =
                        Sessao.UtilizadorAtual.NomeUtilizador;
                }

                compra.DataFecho = DateTime.Now;
                compra.DataEdicao = DateTime.Now;

                db.SaveChanges();

                return true;
            }
        }
        public bool AlterarItemModoCompra(int itemId, string origem, int quantidade, float preco)
        {
            using (var db = new IShopping())
            {
                Item item;

                if (origem == "Previsto")
                {
                    item = db.ItemPrevistos
                        .FirstOrDefault(i => i.Id == itemId);
                }
                else
                {
                    item = db.ItensNaoPrevistos
                        .FirstOrDefault(i => i.Id == itemId);
                }

                if (item == null)
                    return false;

                item.QuantidadeAdquirida = quantidade;
                item.Preco = preco;

                db.SaveChanges();

                return true;
            }
        }
        public bool ReabrirCompra(int compraId)
        {
            using (IShopping db = new IShopping())
            {
                Compra compra = db.Compras.Find(compraId);

                if (compra == null)
                {
                    return false;
                }

                compra.DataFecho = null;
                compra.DataEdicao = DateTime.Now;

                db.SaveChanges();

                return true;
            }
        }

        public void AdicionarItemNaCompra(Compra compra, Item item)
        {
            if (item is ItemPrevisto previsto)
            {
                compra.Itens.Add(new ItemPrevisto
                {
                    ArtigoId = previsto.ArtigoId,
                    QuantidadePrevista = previsto.QuantidadePrevista,
                    QuantidadeAdquirida = previsto.QuantidadeAdquirida,
                    Preco = previsto.Preco
                });
            }
            else if (item is ItemNaoPrevisto naoPrevisto)
            {
                compra.Itens.Add(new ItemNaoPrevisto
                {
                    ArtigoId = naoPrevisto.ArtigoId,
                    QuantidadeAdquirida = naoPrevisto.QuantidadeAdquirida,
                    Preco = naoPrevisto.Preco,
                    Observacoes = naoPrevisto.Observacoes
                });
            }
            else
            {
                compra.Itens.Add(new Item
                {
                    ArtigoId = item.ArtigoId,
                    QuantidadeAdquirida = item.QuantidadeAdquirida,
                    Preco = item.Preco
                });
            }
        }
        public List<ExportacaoCompraCSV> ExportarComprasFechadasCSV()
        {
            using (IShopping db = new IShopping())
            {
                var lista = new List<ExportacaoCompraCSV>();

                var compras = db.Compras
                    .Include(c => c.Itens.Select(i => i.Artigo.TipoArtigo))
                    .Where(c => c.DataFecho != null)
                    .ToList();

                foreach (var compra in compras)
                {
                    foreach (var item in compra.Itens)
                    {
                        string tipoItem = item is ItemPrevisto ? "Previsto" :
                                          item is ItemNaoPrevisto ? "Não Previsto" : "Normal";

                        int? quantidadePrevista = null;
                        if (item is ItemPrevisto previsto)
                        {
                            quantidadePrevista = previsto.QuantidadePrevista;
                        }

                        lista.Add(new ExportacaoCompraCSV
                        {
                            NomeCompra = compra.Nome,
                            DataCriacao = compra.DataCriacao,
                            DataFechada = compra.DataFecho,

                            TipoArtigo = item.Artigo?.TipoArtigo?.Nome ?? "Sem Tipo",
                            TipoItem = tipoItem,

                            NomeArtigo = item.Artigo?.Nome ?? "Artigo Desconhecido",
                            QuantidadePrevista = quantidadePrevista,
                            QuantidadeAdquirida = item.QuantidadeAdquirida,
                            PrecoUnitario = item.Preco
                        });
                    }
                }

                return lista;
            }
        }
        public bool AdicionarItemNaoPrevisto(int compraId, ItemNaoPrevisto item)
        {
            using (IShopping db = new IShopping())
            {
                Compra compra = db.Compras.Find(compraId);

                if (compra == null)
                    return false;

                item.CompraId = compraId;

                db.ItensNaoPrevistos.Add(item);

                compra.DataEdicao = DateTime.Now;

                db.SaveChanges();

                return true;
            }
        }
        public void CriarDadosTeste()
        {
            using (IShopping db = new IShopping())
            {
                if (!db.TipoArtigos.Any())
                {
                    TipoArtigo alimentacao = new TipoArtigo
                    {
                        Nome = "Alimentação"
                    };

                    TipoArtigo higiene = new TipoArtigo
                    {
                        Nome = "Higiene"
                    };

                    TipoArtigo limpeza = new TipoArtigo
                    {
                        Nome = "Limpeza"
                    };

                    TipoArtigo bebidas = new TipoArtigo
                    {
                        Nome = "Bebidas"
                    };

                    db.TipoArtigos.Add(alimentacao);
                    db.TipoArtigos.Add(higiene);
                    db.TipoArtigos.Add(limpeza);
                    db.TipoArtigos.Add(bebidas);

                    db.SaveChanges();

                    db.Artigos.Add(new Artigo
                    {
                        Nome = "Arroz",
                        TipoArtigoId = alimentacao.Id
                    });

                    db.Artigos.Add(new Artigo
                    {
                        Nome = "Massa",
                        TipoArtigoId = alimentacao.Id
                    });

                    db.Artigos.Add(new Artigo
                    {
                        Nome = "Pão",
                        TipoArtigoId = alimentacao.Id
                    });

                    db.Artigos.Add(new Artigo
                    {
                        Nome = "Leite",
                        TipoArtigoId = alimentacao.Id
                    });

                    db.Artigos.Add(new Artigo
                    {
                        Nome = "Champô",
                        TipoArtigoId = higiene.Id
                    });

                    db.Artigos.Add(new Artigo
                    {
                        Nome = "Gel de banho",
                        TipoArtigoId = higiene.Id
                    });

                    db.Artigos.Add(new Artigo
                    {
                        Nome = "Detergente",
                        TipoArtigoId = limpeza.Id
                    });

                    db.Artigos.Add(new Artigo
                    {
                        Nome = "Lixívia",
                        TipoArtigoId = limpeza.Id
                    });

                    db.Artigos.Add(new Artigo
                    {
                        Nome = "Água",
                        TipoArtigoId = bebidas.Id
                    });

                    db.Artigos.Add(new Artigo
                    {
                        Nome = "Sumo",
                        TipoArtigoId = bebidas.Id
                    });

                    db.SaveChanges();
                }
            }
        }
    }
}
