using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisionCar.Core.Entities;

namespace VisionCar.Core.Repositories
{
    public interface IEmpresaRepository
    {
        Task AddAsync(Empresa emp);
        Task<List<Empresa>> GetAllAsync();
        Task<Empresa> GetByIdAsync( int id);
        Task DeleteAsync(int emp);
        Task SaveChangesAsync();

    }
}
