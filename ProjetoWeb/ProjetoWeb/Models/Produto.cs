using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        // Propriedade para calcular o valor total
        public decimal PrecoTotal
        {
            get
            {
                return PrecoUnitario * Quantidade;
            }
        }

        // Chave estrangeira
        public int FornecedorId { get; set; } // Cada produto pertence a um fornecedor

        // Navegação para Fornecedor
        public Fornecedor Fornecedor { get; set; } // Cada produto pertence a um fornecedor
    }
}
