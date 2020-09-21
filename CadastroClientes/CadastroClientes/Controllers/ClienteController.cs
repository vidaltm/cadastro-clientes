using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroClientes.Common.Model;
using CadastroClientes.Domain.Dto;
using CadastroClientes.Domain.Interfaces.Repository;
using CadastroClientes.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CadastroClientes.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IClientesRepository _clientesRepository;
        public ClienteController(INotificationHandler<Notifications> notification, 
            IClientesRepository clientesRepository) : base(notification)
        {
            _clientesRepository = clientesRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            var clientes = _clientesRepository.GetAllClientes();
            return Ok(clientes);
        }        
        
        [HttpPost]
        public async Task<ActionResult<Clientes>> IncluirCliente(Clientes cliente)
        {
            _clientesRepository.AddClientes(cliente);
            if (!OperacaoValida())
                return BadRequestResponse();

            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(int id, Clientes cliente)
        {
            if(id != cliente.Id)
            {
                return BadRequest();
            }

            try
            {
                _clientesRepository.UpdateClientes(cliente);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clientes>> DeleteCliente(int id)
        {
            _clientesRepository.ExcluirClientes(id);
            if (!OperacaoValida())
                return BadRequestResponse();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = _clientesRepository.GetById(id);
            if(cliente == null)
            {
                return NotFound();
            }

            return Ok(ClientesDto.ConverterPataDto(cliente));
        }
    }
}
