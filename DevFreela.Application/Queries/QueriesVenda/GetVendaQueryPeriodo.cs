using VisionCar.Application.ViewModels;
using MediatR;
using System.Collections.Generic;
using System;

namespace VisionCar.Application.Queries.QueriesVenda
{
    public class GetVendaQueryPeriodo : IRequest<List<VendaViewModel>>
    {
        public GetVendaQueryPeriodo(int idEmpresa, DateTime? startDate, DateTime? endDate)
        {
            IdEmpresa = idEmpresa;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int IdEmpresa { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
    }
}
