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
    public class GetServicosQueryByIdHandler : IRequestHandler<GetServicoQueryById, ServicoViewModel>
    {
        private readonly IServicoRepository _ServicoRepository;
        public GetServicosQueryByIdHandler(IServicoRepository servicoRepository)
        {
            _ServicoRepository = servicoRepository;
        }

        public async Task<ServicoViewModel> Handle(GetServicoQueryById request, CancellationToken cancellationToken)
        {
            var servico = await _ServicoRepository.GetByIdAsync(request.Id);

            if (servico == null)
            {
                return null;

            }
            var servicoViewModel = new ServicoViewModel(servico.Id, servico.IdEmpresa, servico.Descricao, servico.Preco, servico.Ativo);

            return servicoViewModel;
        }
    }
}
