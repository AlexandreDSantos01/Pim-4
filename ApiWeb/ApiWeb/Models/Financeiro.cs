namespace ApiWeb.Models
{
    public class Financeiro
    {
        public int Id { get; set; }
        public DateTime DRegistro { get; set; }
        public DateTime DiaInicio { get; set; }
        public DateTime DiaFim { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorDespesa { get; set; }
        public decimal ValorLucro { get; set; }
    }
}
