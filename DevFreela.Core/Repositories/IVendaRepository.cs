using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisionCar.Core.Entities;

namespace VisionCar.Core.Repositories
{
    public interface IVendaRepository
    {
        Task AddAsync(Venda venda);
        Task<List<Venda>> GetAllAsync(int id);
        Task<Venda> GetByIdAsync( int id);
        Task DeleteAsync(Venda venda);
        Task SaveChangesAsync();

    }
}
