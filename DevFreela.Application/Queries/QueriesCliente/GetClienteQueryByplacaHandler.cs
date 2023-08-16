using VisionCar.Application.ViewModels;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace VisionCar.Application.Queries.QueriesCliente
{
    public class GetClienteQueryByplacaHandler : IRequestHandler<GetClienteQueryByplaca, List<ClienteViewModel>>
    {
        private readonly IClienteRepository _clienteRepository;
        public GetClienteQueryByplacaHandler(IClienteRepository clienterepository)
        {
            _clienteRepository = clienterepository;
        }

        public async Task<List<ClienteViewModel>> Handle(GetClienteQueryByplaca request, CancellationToken cancellationToken)
        {
           var cliente = await _clienteRepository.GetPlacaAsync(request.IdEmpresa,request.Placa);

            var empresaViewModel = cliente
                        .Where(p => p.IdEmpresa == request.IdEmpresa)
                        .Where(p => p.Placa == request.Placa)
                        .Where(p => p.Ativo)
                        .Select(p => new ClienteViewModel(p.Id, p.IdEmpresa, p.Nome, p.Placa, p.Celular, p.TipoVeiculo, p.Data_add, p.Ativo))
                        .ToList();

            return empresaViewModel;
        }
    }
}
