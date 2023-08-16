﻿using VisionCar.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisionCar.Application.Queries.QueriesVenda;
using VisionCar.Application.Commands._Ciente;
using VisionCar.Application.Commands._Produto;
using VisionCar.Application.Commands._Empresa;
using VisionCar.Application.Commands.CreateCliente;
using VisionCar.Application.Commands._Venda;

namespace VisionCar.API.Controllers
{
    [Route("api/Venda")]
    public class VendaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VendaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/Venda/3 DELETE
        [HttpDelete("{id}")]
        //[Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteVendaCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/Venda/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new Application.Queries.QueriesVenda.GetVendaQueryById(id);

            var cliente = await _mediator.Send(query);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
        // api/Venda/Empresa/1
        [HttpGet("Empresa/{idEmpresa}")]
        public async Task<IActionResult> GetByIdEmpresa(int idEmpresa)
        {
            var query = new Application.Queries.QueriesVenda.GetVendaQuery(idEmpresa);

            var produto = await _mediator.Send(query);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }
        // api/Venda
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVendaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
