using VisionCar.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisionCar.Application.Commands.CreateCliente;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using VisionCar.Application.Commands._Ciente;

namespace VisionCar.API.Controllers
{
    [Route("api/Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/Cliente/3 DELETE
        [HttpDelete("{id}")]
        //[Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCienteCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/Cliente/Empresa/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new Application.Queries.QueriesCliente.GetClienteQueryById(id);

            var cliente = await _mediator.Send(query);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
        // api/Cliente/1
        [HttpGet("empresa/{idEmpresa}")]
        public async Task<IActionResult> GetByIdEmpresa(int idEmpresa)
        {
            var query = new Application.Queries.QueriesCliente.GetClienteQuery(idEmpresa);

            var cliente = await _mediator.Send(query);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
        // api/Cliente
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClienteCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
