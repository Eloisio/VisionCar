using VisionCar.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;

namespace VisionCar.Application.Commands._Empresa
{
    public class DeleteVendaCommandHandler : IRequestHandler<DeleteVendaCommand, Unit>
    {
        private readonly IVendaRepository _VendaRepository;
        public DeleteVendaCommandHandler(IVendaRepository VendaRepository)
        {
            _VendaRepository = VendaRepository;
        }

        public async Task<Unit> Handle(DeleteVendaCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _VendaRepository.GetByIdAsync(request.Id);
            await _VendaRepository.DeleteAsync(cliente);

            await _VendaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
