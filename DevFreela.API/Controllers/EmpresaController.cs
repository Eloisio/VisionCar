
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisionCar.Application.Commands._Empresa;
using VisionCar.Application.Queries.QueriesEmpresa;

namespace VisionCar.API.Controllers
{
    [Route("api/Empresa")]
    public class EmpresaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmpresaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/Empresa?query=net core
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllEmpresaQuery = new GetEmpresaQuery(query);

            var empresa = await _mediator.Send(getAllEmpresaQuery); 

            return Ok(empresa);
        }

        // api/Empresa/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetEmpresaByIdQuery(id);

            var empresa = await _mediator.Send(query);

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmpresaCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/Empresa/2
        [HttpPut]
        public async Task<IActionResult> Put( [FromBody] UpdateEmpresaCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // api/Empresa/3 DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteEmpresaCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
