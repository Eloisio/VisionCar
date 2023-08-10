
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionCar.Core.Entities;
using VisionCar.Core.Repositories;
using VisionCar.Infrastructure.Persistence;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly VisionCarDbContext _dbContext;
        private readonly string _connectionString;
        public ProdutoRepository(VisionCarDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("VisionCarCs");
        }

        public Task DeleteAsync(Produto produto)
        {
            throw new System.NotImplementedException();
        }

        async Task IProdutoRepository.AddAsync(Produto produto)
        {
            await _dbContext.Produto.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
        }


        async Task<List<Produto>> IProdutoRepository.GetAllAsync(int idEmpresa)
        {
            return await _dbContext.Produto.Where(c => c.IdEmpresa == idEmpresa).ToListAsync();
        }

        async Task<Produto> IProdutoRepository.GetByIdAsync(int id)
        {
            return await _dbContext.Produto.SingleOrDefaultAsync(p => p.Id == id);
        }

        async Task IProdutoRepository.SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
