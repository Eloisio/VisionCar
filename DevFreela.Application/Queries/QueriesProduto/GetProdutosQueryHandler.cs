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
    public class GetProdutosQueryHandler : IRequestHandler<GetProdutosQuery, List<ProdutoViewModel>>
    {
        private readonly IProdutoRepository _ProdutoRepository;
        public GetProdutosQueryHandler(IProdutoRepository produtoRepository)
        {
            _ProdutoRepository = produtoRepository;
        }

        public async Task<List<ProdutoViewModel>> Handle(GetProdutosQuery request, CancellationToken cancellationToken)
        {
            var produto = await _ProdutoRepository.GetAllAsync(request.IdEmpresa);

            if (produto == null)
            {

                produto = produto
                    .Where(p => p.IdEmpresa == request.IdEmpresa)
                    .ToList();

            }
            var vendaViewModel = produto
                        .Select(p => new ProdutoViewModel(p.Id, p.IdEmpresa, p.Descricao, p.Preco, p.Ativo))
                        .ToList();

            return vendaViewModel;
        }
    }
}
