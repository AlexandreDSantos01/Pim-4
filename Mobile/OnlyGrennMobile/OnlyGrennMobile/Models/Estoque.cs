using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyGrennMobile.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime DColheita { get; set; }
        public DateTime DRegistroProducao { get; set; }
        public DateTime EstimativaProducao { get; set; }
        public DateTime Validade { get; set; }
        public int ValorNutritivo { get; set; }
        public decimal Preco { get; set; }
        public string Situacao { get; set; }
    }

}
