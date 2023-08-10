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

namespace VisionCar.Application.Commands.CreateUser
{
    public class CreateVendaCommandHandler : IRequestHandler<CreateVendaCommand, int>
    {
        private readonly IVendaRepository _VendaRepository;
        public CreateVendaCommandHandler(IVendaRepository VendaRepository)
        {
            _VendaRepository = VendaRepository;
        }

        public async Task<int> Handle(CreateVendaCommand request, CancellationToken cancellationToken)
        {
            var venda = new Venda(request.Id, request.IdEmpresa, request.IdCliente, request.Valor,  request.Caixinha,request.Inicio,request.Fim,request.Data,request.Pago,request.AvisarCliente,request.Excluido,request.Observacao);

            await _VendaRepository.AddAsync(venda);
            await _VendaRepository.SaveChangesAsync();

            return venda.Id;
        }
    }
}
