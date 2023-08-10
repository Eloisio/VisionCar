using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisionCar.Application.Commands._Ciente;
using VisionCar.Application.Commands._Produto;
using VisionCar.Application.Commands.CreateCliente;

namespace VisionCar.API.Controllers
{
    [Route("api/Produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/Produto/3 DELETE
        [HttpDelete("{id}")]
        //[Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCienteCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/Produto/Empresa/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new Application.Queries.QueriesProduto.GetProdutosQueryById(id);

            var cliente = await _mediator.Send(query);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
        // api/Produto/1
        [HttpGet("Empresa/{idEmpresa}")]
        public async Task<IActionResult> GetByIdEmpresa(int idEmpresa)
        {
            var query = new Application.Queries.QueriesProduto.GetProdutosQuery(idEmpresa);

            var produto = await _mediator.Send(query);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }
        // api/Cliente
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProdutoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
