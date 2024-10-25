using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        [ForeignKey("Fornecedor")]
        public int pk_idFornecedor { get; set; }
        //public string Tipo { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DRegistro { get; set; }
        public decimal Valor { get; set; }

        // Relacionamento
        public Fornecedor Fornecedor { get; set; }
    }
}
