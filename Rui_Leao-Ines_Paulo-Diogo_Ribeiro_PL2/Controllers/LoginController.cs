using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    internal class LoginController
    {
        // Método para encriptar password
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Converter password para bytes
                byte[] bytes = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(password)
                );

                // Converter bytes para string
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public Utilizador login(
            string nomeUtilizador,
            string password)
        {
            using (var db = new IShopping())
            {
                // Encriptar password introduzida
                string passwordEncriptada = HashPassword(password);

                // Procurar utilizador
                Utilizador utilizador = db.Utilizadores
                    .Where(cli =>
                        cli.NomeUtilizador == nomeUtilizador &&
                        cli.Password == passwordEncriptada)
                    .Select(cli => cli)
                    .FirstOrDefault();

                return utilizador;
            }
        }
    }
}