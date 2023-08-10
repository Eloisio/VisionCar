using VisionCar.Application.ViewModels;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;

namespace VisionCar.Application.Queries.QueriesCliente
{
    public class GetClienteQueryByIdHandler : IRequestHandler<GetClienteQueryById, ClienteViewModel>
    {
        private readonly IClienteRepository _clienteRepository;
        public GetClienteQueryByIdHandler(IClienteRepository clienterepository)
        {
            _clienteRepository = clienterepository;
        }

        public async Task<ClienteViewModel> Handle(GetClienteQueryById request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);

            if (cliente == null)
            {
                return null;
            }

            return new ClienteViewModel(cliente.Id,cliente.IdEmpresa,cliente.Nome,cliente.Placa,cliente.Celular, cliente.TipoVeiculo,cliente.Data_add,cliente.Ativo);
        }
    }
}
