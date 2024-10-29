namespace ApiWeb.Models
{
    public class Producao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime DRegistro { get; set; }
        public DateTime Estimativa { get; set; }
    }
}
