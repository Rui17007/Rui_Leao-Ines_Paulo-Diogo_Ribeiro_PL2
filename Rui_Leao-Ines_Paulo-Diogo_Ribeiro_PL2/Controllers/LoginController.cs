using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    internal class LoginController
    {
<<<<<<< Updated upstream
        public bool login(string nomeUtilizador, string password)
=======
        private RSACryptoServiceProvider rsa;
        public Utilizador login(string nomeUtilizador, string password)
>>>>>>> Stashed changes
        {

            rsa = new RSACryptoServiceProvider();
            string publicKey = rsa.ToXmlString(false);
            string bothKeys = rsa.ToXmlString(true);
            using (var db = new IShopping())
            {
                Utilizador utilizador = db.Utilizadores
                    .Where(cli => cli.NomeUtilizador == nomeUtilizador)
                    .Select(cli => cli)
                    .FirstOrDefault();
<<<<<<< Updated upstream
                if (utilizador != null)
                {
                    return true;
                }
                return false;
=======
                string keySEnc = utilizador.Password;
                byte[] dados = Convert.FromBase64String(keySEnc);
                byte[] dadosDec = rsa.Decrypt(dados, true);
                string pass = Encoding.UTF8.GetString(dadosDec);
                return utilizador;
>>>>>>> Stashed changes
            }
        }
    }
}
