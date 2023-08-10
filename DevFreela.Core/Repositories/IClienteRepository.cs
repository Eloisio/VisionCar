using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisionCar.Core.Entities;

namespace VisionCar.Core.Repositories
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente produto);
        Task<List<Cliente>> GetAllAsync(int id);
        Task<Cliente> GetByIdAsync( int id);
        Task DeleteAsync(Cliente produto);
        Task SaveChangesAsync();

    }
}
