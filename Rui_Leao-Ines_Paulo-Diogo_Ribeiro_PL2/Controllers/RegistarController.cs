using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    public class RegistarController
    {
        public bool RegistarUtilizador(string nomeUtilizador, string nome, string password, string nif, string email)
        {
            using (var db = new IShopping())
            {
                // Se existir algum utilizador com o username ou o email na base de dados irá apresentar uma messagebox a indicar o erro
                if (db.Utilizadores.Any(u => u.NomeUtilizador == nomeUtilizador || u.Email == email))
                {
                    MessageBox.Show("Username ou Email já estão em uso!", "Erro");
                    return false;
                }

                var NovoUtilizador = new Utilizador
                {
                    Email = email,
                    NomeUtilizador = nomeUtilizador,
                    Nome = nome,
                    Password = password,
                    Nif = nif
                };

                db.Utilizadores.Add(NovoUtilizador);
                db.SaveChanges();
                MessageBox.Show("Conta criada com sucesso");
                return true;
            }
         }
    }
}