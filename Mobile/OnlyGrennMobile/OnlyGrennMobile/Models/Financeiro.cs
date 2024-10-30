using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyGrennMobile.Models
{
    public class Financeiro
    {
        public int Id { get; set; }
        public DateTime Dregistro { get; set; }
        public DateTime Diainicio { get; set; }
        public DateTime Diafim { get; set; }
        public decimal Valorvenda { get; set; }
        public decimal Valordespesa { get; set; }
        public decimal Valorlucro { get; set; }
    }

}
