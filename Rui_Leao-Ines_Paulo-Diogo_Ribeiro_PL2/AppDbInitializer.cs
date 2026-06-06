using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2
{
    public class IShoppingInitializer : DropCreateDatabaseIfModelChanges<IShopping>
    {
        protected override void Seed(IShopping context)
        {



            var admin = new Utilizador
            {
                NomeUtilizador = "admin",
                Nome = "Administrador",
                Password = HashPassword("admin"),
                Nif = "123456789",
                Email = "admin@ishopping.pt"
            };

            var utilizador = new Utilizador
            {
                NomeUtilizador = "ines",
                Nome = "Inês Duivenvoorden",
                Password = HashPassword("ines"),
                Nif = "987654321",
                Email = "ines@email.com"
            };

            context.Utilizadores.Add(admin);
            context.Utilizadores.Add(utilizador);

            context.SaveChanges();




            var alimentacao = new TipoArtigo
            {
                Nome = "Alimentação"
            };

            var higiene = new TipoArtigo
            {
                Nome = "Higiene"
            };

            var transporte = new TipoArtigo
            {
                Nome = "Transporte"
            };

            context.TipoArtigos.Add(alimentacao);
            context.TipoArtigos.Add(higiene);
            context.TipoArtigos.Add(transporte);

            context.SaveChanges();





            var arroz = new Artigo
            {
                Nome = "Arroz",
                TipoArtigoId = alimentacao.Id
            };

            var leite = new Artigo
            {
                Nome = "Leite",
                TipoArtigoId = alimentacao.Id
            };

            var sabonete = new Artigo
            {
                Nome = "Sabonete",
                TipoArtigoId = higiene.Id
            };

            var metro = new Artigo
            {
                Nome = "Bilhete Metro",
                TipoArtigoId = transporte.Id
            };

            context.Artigos.Add(arroz);
            context.Artigos.Add(leite);
            context.Artigos.Add(sabonete);
            context.Artigos.Add(metro);

            context.SaveChanges();





            int anoAlvo = DateTime.Now.Year;
            DateTime dataFevereiro = new DateTime(anoAlvo, 2, 1);

            var orcamento = new Orcamento
            {
                MesAno = dataFevereiro.ToString("MMMM yyyy", new System.Globalization.CultureInfo("pt-PT")),
                ValorMax = 500,
                ValorAtual = 120,
                DataCriacao = dataFevereiro, 
                CriadoPor = admin.NomeUtilizador,
                UtilizadorId = admin.Id
            };

            context.Orcamentos.Add(orcamento);

            context.SaveChanges();





            var compra = new Compra
            {
                Nome = "Compras do Mês",
                DataCriacao = DateTime.Now,
                DataEdicao = DateTime.Now,
                UtilizadorId = admin.Id
            };

            context.Compras.Add(compra);

            context.SaveChanges();





            var item1 = new ItemPrevisto
            {
                Preco = 1.50f,
                QuantidadeAdquirida = 2,
                QuantidadePrevista = 3,
                ArtigoId = arroz.Id,
                CompraId = compra.Id
            };

            var item2 = new ItemNaoPrevisto
            {
                Preco = 0.99f,
                QuantidadeAdquirida = 1,
                Observacoes = "Promoção",
                ArtigoId = leite.Id,
                CompraId = compra.Id
            };

            context.Itens.Add(item1);
            context.Itens.Add(item2);

            context.SaveChanges();

            base.Seed(context);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes =sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder =new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}