using VisionCar.Core.Entities;
using VisionCar.Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Application.Commands._Empresa;
using VisionCar.Core.Repositories;

namespace VisionCar.Application.Commands._Empresa
{
    public class CreateEmpresaCommandHandler : IRequestHandler<CreateEmpresaCommand, int>
    {
        private readonly IEmpresaRepository _empresaRepository;
        public CreateEmpresaCommandHandler(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<int> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresa = new Empresa(request.Id, request.Nome, request.NomeFantasia, request.Data_add, request.Ativo);

            await _empresaRepository.AddAsync(empresa);
            await _empresaRepository.SaveChangesAsync();

            return empresa.Id;
        }
    }
}
