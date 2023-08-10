using VisionCar.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace VisionCar.Application.Queries.QueriesProduto
{
    public class GetProdutosQueryById : IRequest<ProdutoViewModel>
    {
        public GetProdutosQueryById(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
