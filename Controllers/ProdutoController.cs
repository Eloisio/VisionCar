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
    public class ProdutoController : ControllerBase
    {
        private readonly visioncarContext _context;

        public ProdutoController(visioncarContext context)
        {
            _context = context;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetProdutos()
        {
            return await _context.Produto.ToListAsync();
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> GetProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // GET: api/Produto/Empresa/1
        [HttpGet("empresa/{idempresa}")]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetProdutosPorEmpresa(int idempresa)
        {
            var produtos = await _context.Produto.Where(c => c.idEmpresa == idempresa).ToListAsync();

            if (produtos == null || produtos.Count == 0)
            {
                return NotFound();
            }

            return produtos;
        }


        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ProdutoModel produtoModel)
        {
            if (id != produtoModel.id)
            {
                return BadRequest();
            }

            _context.Entry(produtoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!produtoExists(id))
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

        // POST: api/Produto
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> PostProduto(ProdutoModel produtoModel)
        {
            _context.Produto.Add(produtoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproduto", new { id = produtoModel.id }, produtoModel);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool produtoExists(int id)
        {
            return _context.Produto.Any(e => e.id == id);
        }
    }
}
