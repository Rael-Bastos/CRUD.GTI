using Microsoft.AspNetCore.Mvc;
using Projeto.GTI.Domain.Entities;
using Projeto.GTI.Services.Interfaces;
using System.Threading.Tasks;

namespace Projeto.GTI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        public ClienteController (IClienteService clienteService )
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var clientes = await _clienteService.Listar();

            return Ok (clientes);
        }

        [HttpPut]
        public async Task Editar([FromBody] Cliente cliente)
        {
           await _clienteService.Editar(cliente);
        }

        [HttpPost]
        public async Task Adicionar([FromBody]Cliente cliente)
        {
            await _clienteService.Adicionar(cliente);
        }

        [HttpDelete]
        public async Task Deletar([FromQuery]int idCliente)
        {
            await _clienteService.Deletar(idCliente);            
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarCliente(int idCliente)
        {
           var cliente = await _clienteService.ConsultarCliente(idCliente);
           
            return Ok(cliente);
        }

    }
}
