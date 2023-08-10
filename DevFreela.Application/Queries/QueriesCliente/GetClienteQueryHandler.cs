using VisionCar.Application.ViewModels;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;
using System.Collections.Generic;
using VisionCar.Core.Entities;
using System.Linq;

namespace VisionCar.Application.Queries.QueriesCliente
{
    public class GetClienteQueryHandler : IRequestHandler<GetClienteQuery, List<ClienteViewModel>>
    {
        private readonly IClienteRepository _clienteRepository;
        public GetClienteQueryHandler(IClienteRepository clienterepository)
        {
            _clienteRepository = clienterepository;
        }

        public async Task<List<ClienteViewModel>> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetAllAsync(request.IdEmpresa);

            var empresaViewModel = cliente
                        .Where(p => p.IdEmpresa == request.IdEmpresa)
                        .Where(p => p.Ativo)
                        .Select(p => new ClienteViewModel(p.Id, p.IdEmpresa, p.Nome, p.Placa, p.Celular, p.TipoVeiculo, p.Data_add, p.Ativo))
                        .ToList();

            return empresaViewModel;
        }
    }
}
