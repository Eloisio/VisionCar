using VisionCar.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;

namespace VisionCar.Application.Commands._Ciente
{
    public class DeleteCienteCommandHandler : IRequestHandler<DeleteCienteCommand, Unit>
    {
        private readonly IClienteRepository _cienteRepository;
        public DeleteCienteCommandHandler(IClienteRepository cienteRepository)
        {
            _cienteRepository = cienteRepository;
        }

        public async Task<Unit> Handle(DeleteCienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _cienteRepository.GetByIdAsync(request.Id);

            cliente.Update(cliente.Id, cliente.IdEmpresa,cliente.Nome,cliente.Placa,cliente.Celular,cliente.TipoVeiculo,cliente.Data_add,false);

            await _cienteRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
