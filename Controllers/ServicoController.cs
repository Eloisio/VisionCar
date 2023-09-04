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
    public class ServicoController : ControllerBase
    {
        private readonly visioncarContext _context;
        public ServicoController(visioncarContext context)
        {
            _context = context;
        }
        // GET: api/Servico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicoModel>>> GetServicos()
        {
            return await _context.Servico.ToListAsync();
        }
        // GET: api/Servico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoModel>> GetServico(int id)
        {
            var servico = await _context.Servico.FindAsync(id);

            if (servico == null)
            {
                return NotFound();
            }

            return servico;
        }
        // GET: api/Servico/Empresa/1
        [HttpGet("empresa/{idempresa}")]
        public async Task<ActionResult<IEnumerable<ServicoModel>>> GetServicosPorEmpresa(int idempresa)
        {
            var servicos = await _context.Servico.Where(c => c.IdEmpresa == idempresa ).ToListAsync();
            if (servicos == null || servicos.Count == 0)
            {
                return NotFound();
            }
            return servicos;
        }

        [HttpGet("empresa/EmpresaAtiva/{idempresa}")]
        public async Task<ActionResult<IEnumerable<ServicoModel>>> GetServicosPorEmpresaAtiva(int idempresa)
        {
            var servicos = await _context.Servico.Where(c => c.IdEmpresa == idempresa && c.Ativo).ToListAsync();
            if (servicos == null || servicos.Count == 0)
            {
                return NotFound();
            }
            return servicos;
        }

        // PUT: api/Servico/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServico(int id, ServicoModel servicoModel)
        {
            if (id != servicoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!servicoExists(id))
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

        // POST: api/Servico
        [HttpPost]
        public async Task<ActionResult<ServicoModel>> PostServico(ServicoModel servicoModel)
        {
            _context.Servico.Add(servicoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServico", new { id = servicoModel.Id }, servicoModel);
        }

        // DELETE: api/Servico/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            var servico = await _context.Servico.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }

            _context.Servico.Remove(servico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool servicoExists(int id)
        {
            return _context.Servico.Any(e => e.Id == id);
        }
    }
}
