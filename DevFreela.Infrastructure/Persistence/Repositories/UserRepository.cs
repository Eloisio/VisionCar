
using System;
using System.Collections.Generic;
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

        Task IUserRepository.AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<List<User>> IUserRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
