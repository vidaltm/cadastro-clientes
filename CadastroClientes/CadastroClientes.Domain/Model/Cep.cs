using CadastroClientes.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroClientes.Domain.Model
{
    public class Cep
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }        
    }
}
