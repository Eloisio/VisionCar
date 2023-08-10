using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisionCar.Core.Entities;

namespace VisionCar.Core.Repositories
{
    public interface IProdutoRepository
    {
        Task AddAsync(Produto produto);
        Task<List<Produto>> GetAllAsync(int idEmpresa);
        Task<Produto> GetByIdAsync( int id);
        Task DeleteAsync(Produto produto);
        Task SaveChangesAsync();

    }
}
