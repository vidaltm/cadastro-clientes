using CadastroClientes.Domain.Model;

namespace CadastroClientes.Domain.Interfaces.Services
{
    public interface ICepService
    {
        Cep BuscaCep(string cep);
    }
}
