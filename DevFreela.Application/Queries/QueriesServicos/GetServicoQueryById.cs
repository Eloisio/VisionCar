using VisionCar.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace VisionCar.Application.Queries.QueriesServico
{
    public class GetServicoQueryById : IRequest<ServicoViewModel>
    {
        public GetServicoQueryById(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
