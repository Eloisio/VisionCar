using VisionCar.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace VisionCar.Application.Queries.QueriesProduto
{
    public class GetProdutosQuery : IRequest<List<ProdutoViewModel>>
    {
        public GetProdutosQuery(int idEmp)
        {
            IdEmpresa = idEmp;
        }

        public int IdEmpresa { get; private set; }
    }
}
