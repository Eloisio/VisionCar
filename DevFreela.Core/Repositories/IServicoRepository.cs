using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisionCar.Core.Entities;

namespace VisionCar.Core.Repositories
{
    public interface IServicoRepository
    {
        Task AddAsync(Servico servico);
        Task<List<Servico>> GetAllAsync(int id);
        Task<Servico> GetByIdAsync( int id);
        Task DeleteAsync(Servico servico);
        Task SaveChangesAsync();

    }
}
