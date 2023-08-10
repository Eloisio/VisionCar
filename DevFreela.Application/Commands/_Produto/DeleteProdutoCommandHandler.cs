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

namespace VisionCar.Application.Commands._Produto
{
    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, Unit>
    {
        private readonly IProdutoRepository _ProdutoRepository;
        public DeleteProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _ProdutoRepository = produtoRepository;
        }

        public async Task<Unit> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _ProdutoRepository.GetByIdAsync(request.Id);

            await _ProdutoRepository.DeleteAsync(produto);

            await _ProdutoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
