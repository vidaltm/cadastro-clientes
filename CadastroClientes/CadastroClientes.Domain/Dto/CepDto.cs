using CadastroClientes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroClientes.Domain.Dto
{
    public class CepDto
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

        public static CepDto ConverterPataDto(Cep cep)
        {
            if (cep == null) return null;
            return new CepDto()
            {
                cep = cep.cep,
                logradouro = cep.logradouro,
                complemento = cep.complemento,
                bairro = cep.bairro,
                localidade = cep.localidade,
                uf = cep.uf,
                ibge = cep.ibge,
                gia = cep.gia,
                ddd = cep.ddd
            };
        }
    }
}
