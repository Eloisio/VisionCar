using VisionCar.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;
using VisionCar.Application.Commands._Empresa;
using VisionCar.Core.Entities;
using VisionCar.Application.Commands._Produto;

namespace VisionCar.Application.Commands._Servico
{
    public class UpdateServicoCommandHandler : IRequestHandler<UpdateServicoCommand, Unit>
    {
        private readonly IServicoRepository _ServicoRepository;
        public UpdateServicoCommandHandler(IServicoRepository ServicoRepository)
        {
            _ServicoRepository = ServicoRepository;
        }

        public async Task<Unit> Handle(UpdateServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = await _ServicoRepository.GetByIdAsync(request.id);

            servico.Update(request.id, request.idEmpresa, request.Descricao,request.Preco, request.ativo);

            await _ServicoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
