using VisionCar.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;

namespace VisionCar.Application.Commands._Empresa
{
    public class UpdateEmpresaCommandHandler : IRequestHandler<UpdateEmpresaCommand, Unit>
    {
        private readonly IEmpresaRepository _empresaRepository;
        public UpdateEmpresaCommandHandler(IEmpresaRepository empresaRepository)
        {
            _empresaRepository= empresaRepository;
        }

        public async Task<Unit> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresa = await _empresaRepository.GetByIdAsync(request.Id);

            empresa.Update(request.Nome, request.NomeFantasia, request.Data_add, request.Ativo);

            await _empresaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
