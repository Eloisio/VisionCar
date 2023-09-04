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
    public class VendaController : ControllerBase
    {
        private readonly visioncarContext _context;
        public VendaController(visioncarContext context)
        {
            _context = context;
        }
        // GET: api/Venda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaModel>>> GetVendas()
        {
            return await _context.Venda.ToListAsync();
        }
        // GET: api/Venda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendaModel>> GetVenda(int id)
        {
            var venda = await _context.Venda.FindAsync(id);

            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }
        // GET: api/Venda/Empresa/1
        [HttpGet("empresa/{idempresa}")]
        public async Task<ActionResult<IEnumerable<VendaModel>>> GetVendasPorEmpresa(int idempresa)
        {
            var venda = await _context.Venda.Where(c => c.IdEmpresa == idempresa).ToListAsync();

            if (venda == null || venda.Count == 0)
            {
                return NotFound();
            }

            return venda;
        }
        // GET: api/Venda/Empresa/1
        [HttpGet("empresa/{idempresa}/data/{data}")]
        public async Task<ActionResult<IEnumerable<VendaModel>>> GetVendasPorEmpresadata(int idempresa, DateTime data)
        {
            var venda = await _context.Venda.Where(c => c.IdEmpresa == idempresa && c.Data.Date==data.Date).ToListAsync();
            if (venda == null || venda.Count == 0)
            {
                return NotFound();
            }
            return venda;
        }

        [HttpGet("empresa/abertas/{idempresa}")]
        public async Task<ActionResult<IEnumerable<VendaModel>>> GetVendasabertasPorEmpresa(int idempresa)
        {
            var venda = await _context.Venda.Where(c => c.IdEmpresa == idempresa && c.Fim.Date.ToString() == "2001-01-01").ToListAsync();
            if (venda == null || venda.Count == 0)
            {
                return NotFound();
            }
            return venda;
        }

        [HttpPut("fechamento/{id}")]
        public async Task<IActionResult> PutVendafechamento(int id, VendaModel vendaModel)
        {
            if (id != vendaModel.Id)
            {
                return BadRequest();
            }
            var vendaExistente = await _context.Venda.FindAsync(id);
            if (vendaExistente == null)
            {
                return NotFound();
            }
            vendaExistente.Observacao = vendaModel.Observacao;
            vendaExistente.Fim = vendaModel.Fim;
            vendaExistente.tipoPgto = vendaModel.tipoPgto;
            vendaExistente.Pago = true;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vendaExists(id))
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

        [HttpPut("avaliacao/{id}")]
        public async Task<IActionResult> PutVendaavaliacao(int id, VendaModel vendaModel)
        {
            if (id != vendaModel.Id)
            {
                return BadRequest();
            }
            var vendaExistente = await _context.Venda.FindAsync(id);
            if (vendaExistente == null)
            {
                return NotFound();
            }
            vendaExistente.AvaliacaoDescricao = vendaModel.AvaliacaoDescricao;
            vendaExistente.celular = vendaModel.celular;
            vendaExistente.Avaliacao = vendaModel.Avaliacao;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vendaExists(id))
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
        // PUT: api/Venda/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenda(int id, VendaModel vendaModel)
        {
            if (id != vendaModel.Id)
            {
                return BadRequest();
            }
            _context.Entry(vendaModel).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vendaExists(id))
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
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<VendaModel>> PostVenda(VendaModel vendaModel)
        {

            vendaModel.Fim = Convert.ToDateTime("2001-01-01");
            _context.Venda.Add(vendaModel);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Getvenda", new { id = vendaModel.Id }, vendaModel);
        }
        // DELETE: api/Venda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendas(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool vendaExists(int id)
        {
            return _context.Venda.Any(e => e.Id == id);
        }
    }
}
