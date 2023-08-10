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
using VisionCar.Application.Commands._Empresa;
using VisionCar.Application.Commands._Produto;

namespace VisionCar.Application.Commands._Servico
{
    public class DeleteServicoCommandHandler : IRequestHandler<DeleteServicoCommand, Unit>
    {
        private readonly IServicoRepository _ServicoRepository;
        public DeleteServicoCommandHandler(IServicoRepository produtoRepository)
        {
            _ServicoRepository = produtoRepository;
        }

        public async Task<Unit> Handle(DeleteServicoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _ServicoRepository.GetByIdAsync(request.Id);

            await _ServicoRepository.DeleteAsync(produto);

            await _ServicoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
