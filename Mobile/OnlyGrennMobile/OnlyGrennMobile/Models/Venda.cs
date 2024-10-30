using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyGrennMobile.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EstoqueId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime Dregistro { get; set; }
        public decimal Valor { get; set; }
    }

}
