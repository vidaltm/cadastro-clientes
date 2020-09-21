using CadastroClientes.Domain.Model;
using System.Collections.Generic;

namespace CadastroClientes.Domain.Interfaces.Repository
{
    public interface IClientesRepository
    {
        Clientes AddClientes(Clientes clientes);
        IEnumerable<Clientes> GetAllClientes();
        void ExcluirClientes(int id);
        void UpdateClientes(Clientes cliente);
        Clientes GetById(int id);
    }
}
