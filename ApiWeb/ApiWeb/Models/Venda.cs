namespace ApiWeb.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EstoqueId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime DRegistro { get; set; }
        public decimal Valor { get; set; }

        // Relacionamentos
        public Cliente Cliente { get; set; }
        public Estoque Estoque { get; set; }
    }
}
