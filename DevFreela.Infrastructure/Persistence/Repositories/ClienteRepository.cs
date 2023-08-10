
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionCar.Core.Entities;
using VisionCar.Core.Repositories;
using VisionCar.Infrastructure.Persistence;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly VisionCarDbContext _dbContext;
        private readonly string _connectionString;
        public ClienteRepository(VisionCarDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("VisionCarCs");
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _dbContext.Cliente.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
        }
        async Task<List<Cliente>> IClienteRepository.GetAllAsync(int idEmpresa)
        {
            return await _dbContext.Cliente.Where(c => c.IdEmpresa == idEmpresa).ToListAsync();
        }

        async Task<Cliente> IClienteRepository.GetByIdAsync(int id)
        {
            return await _dbContext.Cliente.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Cliente produto)
        {
            throw new NotImplementedException();
        }
    }
}
