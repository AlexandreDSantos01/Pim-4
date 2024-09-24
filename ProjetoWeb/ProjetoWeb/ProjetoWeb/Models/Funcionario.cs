using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoWeb.Models
{
    // Enum para representar os tipos de funcionário
    public enum TipoFuncionario
    {
        Jardineiro,
        Vendedor,
        Financeiro,
        Master,
        Colaborador
    }

    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O telefone deve ter exatamente 11 dígitos.")]
        public string Telefone { get; set; }

        public string Endereco { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }

        // Novo campo para o tipo de funcionário
        [Required]
        public TipoFuncionario Tipo { get; set; }
    }

    public class Jardineiro : Funcionario
    {
        // Propriedades específicas para Jardineiro (se houver)
    }

    public class Vendedor : Funcionario
    {
        // Propriedades específicas para Vendedor (se houver)
    }

    public class Financeiro : Funcionario
    {
        // Propriedades específicas para Financeiro (se houver)
    }

    public class Master : Funcionario
    {
        // Propriedades específicas para Master (se houver)
    }

    public class Colaborador : Funcionario
    {
        // Propriedades específicas para Colaborador (se houver)
    }
}
