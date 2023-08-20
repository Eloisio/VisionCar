
using Microsoft.EntityFrameworkCore;
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
    public class UserRepository : IUserRepository
    {
        private readonly VisionCarDbContext _dbContext;
        public UserRepository(VisionCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByemailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetByEmpresaAsync(int IdEmpresa)
        {
            return await _dbContext.Users.Where(c => c.IdEmpresa == IdEmpresa).ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
