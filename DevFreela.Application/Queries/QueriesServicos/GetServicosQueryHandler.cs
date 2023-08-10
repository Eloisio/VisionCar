using Dapper;
using VisionCar.Application.ViewModels;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;
using VisionCar.Application.Queries.QueriesVenda;
using VisionCar.Core.Entities;

namespace VisionCar.Application.Queries.QueriesServico
{
    public class GetServicosQueryHandler : IRequestHandler<GetServicoQuery, List<ServicoViewModel>>
    {
        private readonly IServicoRepository _ServicoRepository;
        public GetServicosQueryHandler(IServicoRepository servicoRepository)
        {
            _ServicoRepository = servicoRepository;
        }

        public async Task<List<ServicoViewModel>> Handle(GetServicoQuery request, CancellationToken cancellationToken)
        {
            var servico = await _ServicoRepository.GetAllAsync(request.IdEmpresa);

            if (servico == null)
            {

                servico = servico
                    .Where(p => p.IdEmpresa == request.IdEmpresa )
                    .ToList();

            }
            var servicoViewModel = servico
                        .Select(p => new ServicoViewModel(p.Id, p.IdEmpresa, p.Descricao,p.Preco, p.Ativo))
                        .ToList();

            return servicoViewModel;
        }
    }
}
