using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    internal class LoginController
    {
        public bool login(string nomeUtilizador, string password)
        {
            using (var db = new IShopping())
            {
                Utilizador utilizador = db.Utilizadores
                    .Where(cli => cli.NomeUtilizador == nomeUtilizador && cli.Password == password)
                    .Select(cli => cli)
                    .FirstOrDefault();
                if (utilizador != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
