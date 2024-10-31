using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyGrennMobile.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        // public int FornecedorId { get; set; }
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
