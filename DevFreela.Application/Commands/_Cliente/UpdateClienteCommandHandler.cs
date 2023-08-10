using VisionCar.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;

namespace VisionCar.Application.Commands._Ciente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Unit>
    {
        private readonly IClienteRepository _clienteRepository;
        public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);

            cliente.Update(request.Id, request.IdEmpresa, request.Nome, request.Placa,request.Celular,request.TipoVeiculo,request.Data_add,request.Ativo);

            await _clienteRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
