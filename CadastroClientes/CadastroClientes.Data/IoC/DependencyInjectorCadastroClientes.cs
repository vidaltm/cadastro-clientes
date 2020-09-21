using CadastroClientes.Data.Repository;
using CadastroClientes.Data.Services;
using CadastroClientes.Domain.Interfaces.Repository;
using CadastroClientes.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroClientes.Data.IoC
{
    public class DependencyInjectorCadastroClientes
    {
        public static void Registrar(IServiceCollection svcCollection)
        {
            svcCollection.AddScoped<IClientesRepository, ClientesRepository>();
            svcCollection.AddScoped<ICepService, CepService>();
        }
    }
}
