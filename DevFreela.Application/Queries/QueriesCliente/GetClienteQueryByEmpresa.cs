using VisionCar.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace VisionCar.Application.Queries.QueriesCliente
{
    public class GetClienteQueryByEmpresa : IRequest<List<ClienteViewModel>>
    {
        public GetClienteQueryByEmpresa(int idempresa)
        {
            IdEmpresa = idempresa;
        }
        public int IdEmpresa { get; private set; }
    }
}
