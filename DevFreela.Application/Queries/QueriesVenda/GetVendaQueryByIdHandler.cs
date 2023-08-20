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

namespace VisionCar.Application.Queries.QueriesVenda
{
    public class GetVendaQueryByIdHandler : IRequestHandler<GetVendaQueryById, VendaViewModel>
    {
        private readonly IVendaRepository _VendaRepository;
        public GetVendaQueryByIdHandler(IVendaRepository vendaRepository)
        {
            _VendaRepository = vendaRepository;
        }

        public async Task<VendaViewModel> Handle(GetVendaQueryById request, CancellationToken cancellationToken)
        {
            var venda = await _VendaRepository.GetByIdAsync(request.Id);

            if (venda == null)
            {
                return null;
            }
            var vendaViewModel = new VendaViewModel(venda.Id, venda.IdEmpresa, venda.IdCliente, venda.Valor, venda.Caixinha, venda.Inicio, venda.Fim, venda.Data, venda.Pago, venda.AvisarCliente, venda.Excluido, venda.Observacao, venda.Descricao);

            return vendaViewModel;
        }
    }
}
