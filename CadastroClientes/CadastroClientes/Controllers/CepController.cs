using CadastroClientes.Common.Model;
using CadastroClientes.Domain.Dto;
using CadastroClientes.Domain.Interfaces.Services;
using CadastroClientes.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [Route("api/cep")]
    [ApiController]
    public class CepController : BaseController
    {
        private readonly ICepService _cepService;
        public CepController(INotificationHandler<Notifications> notification,
            ICepService cepService) : base(notification)
        {
            _cepService = cepService;
        }
        
        [HttpGet("{cep}")]
        public ActionResult<Cep> CobsultarCep(string cep)
        {
            try
            {
                var result = _cepService.BuscaCep(cep);
                var model = CepDto.ConverterPataDto(result);

                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
