using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyGrennMobile.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public DateTime Dregistro { get; set; }
        public decimal Valor { get; set; }
    }

}
