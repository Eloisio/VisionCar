using VisionCar.Application.ViewModels;
using MediatR;

namespace VisionCar.Application.Queries.QueriesUser
{
    public class GetUserEmpresaQuery : IRequest<System.Collections.Generic.List<UserViewModel>>
    {
        public GetUserEmpresaQuery(int idEmpresa)
        {
            IdEmpresa = idEmpresa;
        }
        public int IdEmpresa { get; set; }
    }
}
