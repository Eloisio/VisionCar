using VisionCar.Core.Entities;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Application.Commands._Empresa;
using VisionCar.Core.Repositories;
using VisionCar.Application.Commands._Servico;

namespace VisionCar.Application.Commands._Servico
{
    public class CreateServicoCommandHandler : IRequestHandler<CreateServicoCommand, int>
    {
        private readonly IServicoRepository _ServicoRepository;
        public CreateServicoCommandHandler(IServicoRepository ServicoRepository)
        {
            _ServicoRepository = ServicoRepository;
        }

        public async Task<int> Handle(CreateServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = new Servico(request.Id, request.IdEmpresa, request.Descricao, request.Preco, request.Ativo);

            await _ServicoRepository.AddAsync(servico);
            await _ServicoRepository.SaveChangesAsync();

            return servico.Id;
        }
    }
}
