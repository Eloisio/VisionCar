using VisionCar.Application.ViewModels;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Application.ViewModels;
using System.Numerics;
using System;
using VisionCar.Core.Entities;
using System.Collections.Generic;
using VisionCar.Core.Repositories;
using System.Linq;

namespace VisionCar.Application.Queries.QueriesVenda
{
    public class GetVendaQueryPeriodoHandler : IRequestHandler<GetVendaQueryPeriodo, List<VendaViewModel>>
    {
        private readonly IVendaRepository _VendaRepository;
        public GetVendaQueryPeriodoHandler(IVendaRepository vendaRepository)
        {
            _VendaRepository = vendaRepository;
        }

        public async Task<List<VendaViewModel>> Handle(GetVendaQueryPeriodo request, CancellationToken cancellationToken)
        {
            var venda = await _VendaRepository.GetAllAsync(request.IdEmpresa);

            if (request.StartDate.HasValue && request.EndDate.HasValue)
            {
                venda = venda
                    .Where(p => p.Data >= request.StartDate.Value && p.Data <= request.EndDate.Value && p.IdEmpresa <= request.IdEmpresa)
                    .ToList();
            }

            var vendaViewModel = venda
                .Select(p => new VendaViewModel(p.Id, p.IdEmpresa, p.IdCliente, p.Valor, p.Caixinha, p.Inicio, p.Fim, p.Data, p.Pago, p.AvisarCliente, p.Excluido, p.Observacao, p.Descricao,p.Placa))
                .ToList();

            return vendaViewModel;

        }
    }
}
