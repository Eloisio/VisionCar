using VisionCar.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace VisionCar.Application.Queries.QueriesCliente
{
    public class GetClienteQueryByplaca : IRequest<List<ClienteViewModel>>
    {
        public GetClienteQueryByplaca(int idemp,string placa)
        {
            Placa = placa;
            IdEmpresa = idemp;
        }
        public string Placa { get; private set; }
        public int IdEmpresa { get; private set; }
    }
}
