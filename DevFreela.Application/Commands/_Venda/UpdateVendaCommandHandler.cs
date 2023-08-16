using VisionCar.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;
using VisionCar.Core.Entities;

namespace VisionCar.Application.Commands._Empresa
{
    public class UpdateVendaCommandHandler : IRequestHandler<UpdateVendaCommand, Unit>
    {
        private readonly IVendaRepository _VendaRepository;
        public UpdateVendaCommandHandler(IVendaRepository VendaRepository)
        {
            _VendaRepository = VendaRepository;
        }

        public async Task<Unit> Handle(UpdateVendaCommand request, CancellationToken cancellationToken)
        {
            var venda = await _VendaRepository.GetByIdAsync(request.Id);

            venda.Update(request.Id, request.IdEmpresa, request.IdCliente, request.Valor,request.Caixinha,request.Inicio,request.Fim,request.Data,request.Pago,request.AvisarCliente,request.Excluido,request.Observacao, request.Descricao,request.TipoPgto);

            await _VendaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
