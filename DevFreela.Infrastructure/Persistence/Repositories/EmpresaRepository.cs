
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

namespace VisionCar.Infrastructure.Persistence.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly VisionCarDbContext _dbContext;
        private readonly string _connectionString;
        public EmpresaRepository(VisionCarDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("VisionCarCs");
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task IEmpresaRepository.AddAsync(Empresa empresa)
        {
            await _dbContext.Empresa.AddAsync(empresa);
            await _dbContext.SaveChangesAsync();
        }

        async Task<List<Empresa>> IEmpresaRepository.GetAllAsync()
        {
            return await _dbContext.Empresa.ToListAsync();
        }

        async Task<Empresa> IEmpresaRepository.GetByIdAsync(int id)
        {
            return await _dbContext.Empresa.SingleOrDefaultAsync(p => p.Id == id);
        }

        async Task IEmpresaRepository.SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
