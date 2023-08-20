using VisionCar.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisionCar.Application.Commands.User;
using VisionCar.Application.Queries.QueriesServico;
using VisionCar.Application.Commands._Servico;
using VisionCar.Application.Commands._User;
using VisionCar.Application.Commands._Produto;

namespace VisionCar.API.Controllers
{
    [Route("api/servico")]
    public class ServicoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServicoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteServicoCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        //api/servico/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetServicoQueryById(id);

            var servico = await _mediator.Send(query);

            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);
        }
        //api/servico
       [HttpGet("Empresa/{idEmpresa}")]
        public async Task<IActionResult> GetByIdEmpresa(int idEmpresa)
        {
            var query = new GetServicoQuery(idEmpresa);

            var servico = await _mediator.Send(query);

            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);
        }

        // api/servico
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateServicoCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/user/2
        [HttpPut()]
        public async Task<IActionResult> Put( [FromBody] UpdateServicoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
