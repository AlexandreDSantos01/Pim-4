namespace ProjetoWeb.Models
{
    public class Produto
    {
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
        public Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }
    }
}
