using CadastroClientes.Domain.Interfaces.Services;
using CadastroClientes.Domain.Model;
using RestSharp;
using System.Text.Json;

namespace CadastroClientes.Data.Services
{
    public class CepService : ICepService
    {
        private string _urlBase = "https://viacep.com.br/ws/";
        private readonly RestClient _restClient;

        public CepService()
        {
            _restClient = new RestClient(_urlBase);
        }

        public Cep BuscaCep(string cep)
        {
            var url = "{0}/json/";
            var urlConsulta = string.Format(url, cep);
            var request = new RestRequest(urlConsulta, Method.GET);
            var response = _restClient.Execute(request);
            var cepModel = JsonSerializer.Deserialize<Cep>(response.Content);
            return cepModel;
        }
    }
}
