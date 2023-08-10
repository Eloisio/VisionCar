using VisionCar.Application.ViewModels;
using MediatR;

namespace VisionCar.Application.Queries.QueriesVenda
{
    public class GetVendaQueryById : IRequest<VendaViewModel>
    {
        public GetVendaQueryById(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

}
