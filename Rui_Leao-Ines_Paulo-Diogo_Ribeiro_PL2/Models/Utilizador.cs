namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models
{
    public class Utilizador
    {
        

        public Utilizador()
        {
        }

        public Utilizador(int id, string nomeUtilizador, string nome, string password, string nif, string email)
        {
            Id = id;
            NomeUtilizador = nomeUtilizador;
            Nome = nome;
            Password = password;
            Nif = nif;
            Email = email;
        }

        public int Id { get; set; }
        public string NomeUtilizador {  get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public string Nif { get; set; }
        public string Email { get; set; }
        

        
    }
}
