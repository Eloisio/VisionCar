using VisionCar.Core.Entities;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Application.Commands._Empresa;
using VisionCar.Core.Repositories;

namespace VisionCar.Application.Commands._Produto
{
    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, int>
    {
        private readonly IProdutoRepository _ProdutoRepository;
        public CreateProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _ProdutoRepository = produtoRepository;
        }

        public async Task<int> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto(request.id, request.idEmpresa, request.Descricao, request.Preco, request.ativo);

            await _ProdutoRepository.AddAsync(produto);
            await _ProdutoRepository.SaveChangesAsync();

            return produto.Id;
        }
    }
}
