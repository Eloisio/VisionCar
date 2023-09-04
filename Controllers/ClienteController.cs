using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using visioncar.Context;
using visioncar.Models;

namespace visioncar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly visioncarContext _context;

        public ClienteController(visioncarContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteModel>>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> GetCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // GET: api/Cliente/Empresa/1
        [HttpGet("empresa/{idempresa}")]
        public async Task<ActionResult<IEnumerable<ClienteModel>>> GetClientesPorEmpresa(int idempresa)
        {
            var clientes = await _context.Cliente.Where(c => c.IdEmpresa == idempresa).ToListAsync();

            if (clientes == null || clientes.Count == 0)
            {
                return NotFound();
            }

            return clientes;
        }

        [HttpGet("empresa/{idempresa}/placa")]
        public async Task<ActionResult<IEnumerable<ClienteModel>>> GetClientesPorEmpresaeplca(int idempresa,string placa)
        {
            var clientes = await _context.Cliente.Where(c => c.IdEmpresa == idempresa && c.Placa==placa).ToListAsync();

            if (clientes == null || clientes.Count == 0)
            {
                return NotFound();
            }

            return clientes;
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteModel clienteModel)
        {
            if (id != clienteModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(clienteModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<ClienteModel>> PostCliente(ClienteModel clienteModel)
        {
            _context.Cliente.Add(clienteModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcliente", new { id = clienteModel.Id }, clienteModel);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
