
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
    public class VendaRepository : IVendaRepository
    {
        private readonly VisionCarDbContext _dbContext;
        private readonly string _connectionString;
        public VendaRepository(VisionCarDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("VisionCarCs");
        }

        public Task DeleteAsync(Venda venda)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Venda> GetByIdAsync(int id)
        {
            return await _dbContext.Venda.SingleOrDefaultAsync(p => p.Id == id);
        }

        async Task IVendaRepository.AddAsync(Venda venda)
        {
            await _dbContext.Venda.AddAsync(venda);
            await _dbContext.SaveChangesAsync();
        }


        async Task<List<Venda>> IVendaRepository.GetAllAsync(int idEmpresa)
        {
            return await _dbContext.Venda.Where(c => c.IdEmpresa == idEmpresa).ToListAsync();
        }

        async Task IVendaRepository.SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
