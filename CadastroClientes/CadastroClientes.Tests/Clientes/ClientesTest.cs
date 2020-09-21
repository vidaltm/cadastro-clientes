using CadastroClientes.Common.Handler;
using CadastroClientes.Common.Implementation;
using CadastroClientes.Domain.Interfaces.Repository;
using CadastroClientes.Domain.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroClientes.Tests.Clientes
{
    public class ClientesTest
    {
        private NotifiyHandler _notifiyHandler;
        private Notify _notify;
        private readonly Mock<IClientesRepository> _clienteRepositoryMock;
        public ClientesTest()
        {
            _notifiyHandler = new NotifiyHandler();
            _notify = new Notify(_notifiyHandler);
            _clienteRepositoryMock = new Mock<IClientesRepository>();
        }

        [Fact]
        public async Task BuscarTodosOsClientes()
        {
            var model = ObterListaClientes();
            
        }

        private CadastroClientes.Domain.Model.Clientes ObterListaClientes()
        {
            return new Domain.Model.Clientes()
            {
                Id = 1,
                Nome = "teste",
                DataNascimento = "06/12/1986",
                Endereco = "Rua A",
                Numero = 145,
                Bairro = "Centro",
                Cep = "19970-000",
                Cidade = "Palmital",
                Estado = "São Paulo",
                Complemento = "Casa",
                Sexo = "Masculino"
            };
        }
    }
}
