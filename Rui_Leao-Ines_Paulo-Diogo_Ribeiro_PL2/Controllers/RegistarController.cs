using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System.Linq;
using System.Windows.Forms;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Controllers
{
    public class RegistarController
    {
        private bool ValidarNIF(string nif)
        {
            // Verifica se tem 9 dígitos e se são todos números
            if (string.IsNullOrWhiteSpace(nif) || nif.Length != 9 || !nif.All(char.IsDigit))
            {
                return false;
            }

            int soma = 0;

            for (int i = 0; i < 8; i++)
            {
                soma += (nif[i] - '0') * (9 - i);
            }

            int resto = soma % 11;
            int digitoControlo = resto < 2 ? 0 : 11 - resto;

            return digitoControlo == (nif[8] - '0');
        }

        public bool RegistarUtilizador( string nomeUtilizador,  string nome,  string password, string nif, string email)
        {
            using (var db = new IShopping())
            {
                // Verificar se o NIF é válido
                if (!ValidarNIF(nif))
                {
                    MessageBox.Show(
                        "O NIF introduzido não é válido!",
                        "Erro"
                    );

                    return false;
                }

                // Verificar se username, email ou nif já existem
                if (db.Utilizadores.Any(u =>
                    u.NomeUtilizador == nomeUtilizador ||
                    u.Email == email ||
                    u.Nif == nif))
                {
                    MessageBox.Show(
                        "Username, Email ou NIF já estão em uso!",
                        "Erro"
                    );

                    return false;
                }

                // Criar utilizador
                var NovoUtilizador = new Utilizador
                {
                    Email = email,
                    NomeUtilizador = nomeUtilizador,
                    Nome = nome,
                    Password = password,
                    Nif = nif
                };

                // Guardar utilizador
                db.Utilizadores.Add(NovoUtilizador);
                db.SaveChanges();

                MessageBox.Show("Conta criada com sucesso");

                return true;
            }
        }
    }
}