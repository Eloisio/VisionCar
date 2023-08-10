using VisionCar.Core.Entities;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Application.Commands.CreateCliente;
using VisionCar.Application.Commands._Empresa;
using VisionCar.Core.Repositories;
using System.Numerics;
using System;
using VisionCar.Application.Commands._Servico;
using DevFreela.Infrastructure.Persistence.Repositories;

namespace VisionCar.Application.Commands.CreateUser
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IClienteRepository _ClienteRepository;
        public CreateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _ClienteRepository = clienteRepository;
        }

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.Id, request.IdEmpresa, request.Nome, request.Placa,  request.Celular,request.TipoVeiculo,request.data_add,request.ativo);

            await _ClienteRepository.AddAsync(cliente);
            await _ClienteRepository.SaveChangesAsync();

            return cliente.Id;
        }
    }
}
