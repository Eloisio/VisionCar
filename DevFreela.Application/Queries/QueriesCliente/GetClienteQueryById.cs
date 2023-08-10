using VisionCar.Application.ViewModels;
using MediatR;

namespace VisionCar.Application.Queries.QueriesCliente
{
    public class GetClienteQueryById : IRequest<ClienteViewModel>
    {
        public GetClienteQueryById(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
