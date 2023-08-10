
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
    public class ServicoRepository : IServicoRepository
    {
        private readonly VisionCarDbContext _dbContext;
        private readonly string _connectionString;
        public ServicoRepository(VisionCarDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("VisionCarCs");
        }

        public async Task AddAsync(Servico servico)
        {
            await _dbContext.Servico.AddAsync(servico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Servico servico)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Servico>> GetAllAsync(int idEmpresa)
        {
            return await _dbContext.Servico.Where(c => c.IdEmpresa == idEmpresa).ToListAsync();
        }

        public async Task<Servico> GetByIdAsync(int id)
        {
            return await _dbContext.Servico.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
