using VisionCar.Application.ViewModels;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;

namespace VisionCar.Application.Queries.QueriesEmpresa
{
    public class GetEmpresaByIdQueryHandler : IRequestHandler<GetEmpresaByIdQuery, EmpresaViewModel>
    {
        private readonly IEmpresaRepository _empresaRepository;
        public GetEmpresaByIdQueryHandler(IEmpresaRepository empresarepository)
        {
            _empresaRepository = empresarepository;
        }

        public async Task<EmpresaViewModel> Handle(GetEmpresaByIdQuery request, CancellationToken cancellationToken)
        {
            var empresa = await _empresaRepository.GetByIdAsync(request.Id);

            if (empresa == null) return null;

            var empresaViewModel = new EmpresaViewModel(empresa.Id, empresa.Nome, empresa.NomeFantasia, empresa.Data_add, empresa.Ativo);

            return empresaViewModel;
        }
    }
}
