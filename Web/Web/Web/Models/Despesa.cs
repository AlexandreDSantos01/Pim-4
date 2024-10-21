namespace Web.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public int FornecedorId { get; set; }  // Foreign Key
        public string Tipo { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DRegistro { get; set; }
        public decimal Valor { get; set; }

        // Relacionamento
        public Fornecedor Fornecedor { get; set; }
    }
}
