using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System.Data.Entity;
using System.Globalization;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    internal class OrcamentoController
    {
        public object Listar()
        {
            using (var db = new IShopping())
            {
                return db.Orcamentos
                    .OrderByDescending(o => o.MesAno)  
                    .Select(o => new
                    {
                        o.Id,

                        Mês = o.MesAno,

                        Valor = o.ValorMax,

                        Gasto = o.ValorAtual,

                        Estado =
                            o.ValorAtual >= o.ValorMax
                            ? "Excedido"
                            : o.ValorAtual >= (o.ValorMax * 0.9f)
                            ? "Perto do limite"
                            : "OK"
                    })
                    .ToList();
            }
        }


        public bool Adicionar(
    float valorMax,
    Utilizador utilizador)
        {
            using (var db = new IShopping())
            {
                string mesAno =
    DateTime.Now.ToString(
        "MMMM yyyy",
        new System.Globalization.CultureInfo("pt-PT"));

                bool existe =
                    db.Orcamentos.Any(o =>
                        o.MesAno == mesAno);

                if (existe)
                {
                    return false;
                }

                Orcamento orcamento =
                    new Orcamento();

                orcamento.MesAno = mesAno;

                orcamento.ValorMax = valorMax;

                orcamento.ValorAtual = 0;

                orcamento.DataCriacao =
                    DateTime.Now;

                orcamento.CriadoPor =
                    utilizador.NomeUtilizador;

                orcamento.UtilizadorId =
                    utilizador.Id;

                db.Orcamentos.Add(orcamento);

                db.SaveChanges();

                return true;
            }
        }

        public void Editar(
            int id,
            float valorMax,
            Utilizador utilizador)
        {
            using (var db = new IShopping())
            {
                Orcamento orcamento =
                    db.Orcamentos.Find(id);

                if (orcamento != null)
                {
                    orcamento.ValorMax =
                        valorMax;

                    orcamento.DataAlteracao =
                        DateTime.Now;

                    orcamento.AlteradoPor =
                        utilizador.NomeUtilizador;

                    db.SaveChanges();
                }
            }
        }

        public Orcamento Procurar(int id)
        {
            using (var db = new IShopping())
            {
                return db.Orcamentos
                    .FirstOrDefault(o => o.Id == id);
            }
        }

        public float DinheiroMax()
        {
            string mesAno = DateTime.Now.ToString(
                "MMMM yyyy",
                new CultureInfo("pt-PT"));

            using (var db = new IShopping())
            {
                return db.Orcamentos
                    .FirstOrDefault(o => o.MesAno == mesAno)?
                    .ValorMax ?? 0;
            }
        }

        public float DinheiroAtual()
        {
            string mesAno = DateTime.Now.ToString(
                "MMMM yyyy",
                new CultureInfo("pt-PT"));

            using (var db = new IShopping())
            {
                return db.Orcamentos
                    .FirstOrDefault(o => o.MesAno == mesAno)?
                    .ValorAtual ?? 0;
            }
        }
    }
}
