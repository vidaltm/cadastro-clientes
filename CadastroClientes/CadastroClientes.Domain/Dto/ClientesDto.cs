using CadastroClientes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CadastroClientes.Domain.Dto
{
    public class ClientesDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        public static ClientesDto ConverterPataDto(Clientes cliente)
        {
            if (cliente == null) return null;
            return new ClientesDto()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento,
                Sexo = cliente.Sexo,
                Cep = cliente.Cep,
                Endereco = cliente.Endereco,
                Numero = cliente.Numero,
                Complemento = cliente.Complemento,
                Bairro = cliente.Bairro,
                Estado = cliente.Estado,
                Cidade = cliente.Cidade
            };
        }
    }
}
