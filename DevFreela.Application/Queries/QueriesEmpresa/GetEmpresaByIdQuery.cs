using VisionCar.Application.ViewModels;
using MediatR;

namespace VisionCar.Application.Queries.QueriesEmpresa
{
    public class GetEmpresaByIdQuery : IRequest<EmpresaViewModel>
    {
        public GetEmpresaByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
