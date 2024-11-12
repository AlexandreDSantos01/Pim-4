using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string NRua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string TipoUsuario { get; set; }
        public string Situacao { get; set; }

        [Column("ulogar")] // Mapeia a coluna "ulogar" para "Ulogar"
        public string ulogar { get; set; }

        [Column("senha")] // Mapeia a coluna "senha" para "Senha"
        public string senha { get; set; }
    }
}
