using VisionCar.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace VisionCar.Application.Queries.QueriesVenda
{
    public class GetVendaQueryByData : IRequest<List<VendaViewModel>>
    {
        public GetVendaQueryByData(int idEmp,DateTime data)
        {
            IdEmpresa = idEmp;
            Data = data;
        }
        public int IdEmpresa { get; set; }
        public DateTime Data { get; set; }
    }

}
