﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime DRegistro { get; set; }
        public decimal Valor { get; set; }
        [ForeignKey("Cliente")]
        public int pk_idCliente { get; set; }
        [ForeignKey("Estoque")]
        public int pk_idEstoque { get; set; }

        // Relacionamentos
        public Cliente Cliente { get; set; }
        public Estoque Estoque { get; set; }
    }
}