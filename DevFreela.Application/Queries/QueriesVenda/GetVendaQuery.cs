using VisionCar.Application.ViewModels;
using MediatR;

namespace VisionCar.Application.Queries.QueriesVenda
{
    public class GetVendaQuery : IRequest<System.Collections.Generic.List<VendaViewModel>>
    {
        public GetVendaQuery(int idEmpresa)
        {
            IdEmpresa = idEmpresa;
        }
        public int IdEmpresa { get; set; }
    }
}
