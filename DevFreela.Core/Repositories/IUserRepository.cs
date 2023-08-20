using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisionCar.Core.Entities;

namespace VisionCar.Core.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<List<User>> GetAllAsync();
        //Task<List<User>> GetAllempresaAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByemailAsync(string email);
        Task DeleteAsync(User user);
        Task SaveChangesAsync();

    }
}
