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
using VisionCar.Core.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace VisionCar.Application.Queries.QueriesVenda
{
    public class GetVendaQueryByDataHandler : IRequestHandler<GetVendaQueryByData, List<VendaViewModel>>
    {
        private readonly IVendaRepository _VendaRepository;
        public GetVendaQueryByDataHandler(IVendaRepository vendaRepository)
        {
            _VendaRepository = vendaRepository;
        }

        public async Task<List<VendaViewModel>> Handle(GetVendaQueryByData request, CancellationToken cancellationToken)
        {
            var venda = await _VendaRepository.GetByDataAsync(request.IdEmpresa,request.Data);

            if (venda == null)
            {

                venda = venda
                    .Where(p => p.IdEmpresa == request.IdEmpresa)
                    .Where(p => p.Data == request.Data)
                    .ToList();

            }
            var vendaViewModel = venda
                        .Select(p => new VendaViewModel(p.Id, p.IdEmpresa, p.IdCliente, p.Valor, p.Caixinha, p.Inicio, p.Fim, p.Data, p.Pago, p.AvisarCliente, p.Excluido, p.Observacao, p.Descricao, p.Placa))
                        .ToList();

            return vendaViewModel;
        }
    }
}
