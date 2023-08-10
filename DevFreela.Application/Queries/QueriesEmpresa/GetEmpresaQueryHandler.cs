using VisionCar.Application.ViewModels;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;
using VisionCar.Core.Entities;

namespace VisionCar.Application.Queries.QueriesEmpresa
{
    public class GetEmpresaQueryHandler : IRequestHandler<GetEmpresaQuery, List<EmpresaViewModel>>
    {
        private readonly IEmpresaRepository _empresaRepository;
        public GetEmpresaQueryHandler(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<List<EmpresaViewModel>> Handle(GetEmpresaQuery request, CancellationToken cancellationToken)
        {
            var empresa = await _empresaRepository.GetAllAsync();

            var empresaViewModel = empresa
                        .Select(p => new EmpresaViewModel(p.Id, p.Nome, p.NomeFantasia, p.Data_add, p.Ativo))
                        .ToList();

            return empresaViewModel;

        }
    }
}
