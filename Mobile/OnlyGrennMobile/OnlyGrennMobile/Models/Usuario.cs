﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyGrennMobile.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Nrua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Tipousuario { get; set; }
        public string Situacao { get; set; }
        public string Ulogar { get; set; }
        public string Senha { get; set; }
    }

}