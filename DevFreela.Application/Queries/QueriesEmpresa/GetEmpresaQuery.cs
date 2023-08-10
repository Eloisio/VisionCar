//using DevFreela.Application.ViewModels;
using MediatR;
using System.Collections.Generic;
using VisionCar.Application.ViewModels;

namespace VisionCar.Application.Queries.QueriesEmpresa
{
    public class GetEmpresaQuery : IRequest<List<EmpresaViewModel>>
    {
        public GetEmpresaQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
