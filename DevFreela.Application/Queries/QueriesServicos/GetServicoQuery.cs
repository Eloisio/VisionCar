using VisionCar.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace VisionCar.Application.Queries.QueriesServico
{
    public class GetServicoQuery : IRequest<List<ServicoViewModel>>
    {
        public GetServicoQuery(int idEmpresa)
        {
            IdEmpresa = idEmpresa;
        }
        public int IdEmpresa { get; set; }
    }
}
