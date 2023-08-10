using VisionCar.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace VisionCar.Application.Queries.QueriesCliente
{
    public class GetClienteQuery : IRequest<List<ClienteViewModel>>
    {
        public GetClienteQuery(int idempresa)
        {
            IdEmpresa = idempresa;
        }
        public int IdEmpresa { get; private set; }
    }
}
