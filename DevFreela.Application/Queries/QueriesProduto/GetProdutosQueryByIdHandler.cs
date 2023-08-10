using VisionCar.Application.ViewModels;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;
using System.Collections.Generic;
using VisionCar.Core.Entities;
using System.Linq;

namespace VisionCar.Application.Queries.QueriesProduto
{
    public class GetProdutosQueryByIdHandler : IRequestHandler<GetProdutosQueryById,ProdutoViewModel>//IRequestHandler <GetProdutosQueryById, <ProdutoViewModel>
    {
        private readonly IProdutoRepository _ProdutoRepository;
        public GetProdutosQueryByIdHandler(IProdutoRepository produtoRepository)
        {
            _ProdutoRepository = produtoRepository;
        }

        public async Task<ProdutoViewModel> Handle(GetProdutosQueryById request, CancellationToken cancellationToken)
        {
            var produto = await _ProdutoRepository.GetByIdAsync(request.Id);

            if (produto == null)
            {

                return null;

            }

            var pd= new ProdutoViewModel(produto.Id, produto.IdEmpresa, produto.Descricao, produto.Preco, produto.Ativo);
            return pd;
        }
    }
}
