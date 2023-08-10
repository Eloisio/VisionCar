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
    public class DeleteEmpresaCommandHandler : IRequestHandler<DeleteEmpresaCommand, Unit>
    {
        private readonly IEmpresaRepository _EmpresaRepository;
        public DeleteEmpresaCommandHandler(IEmpresaRepository empresaRepository)
        {
            _EmpresaRepository = empresaRepository;
        }

        public async Task<Unit> Handle(DeleteEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresa = await _EmpresaRepository.GetByIdAsync(request.Id);

            empresa.Update(empresa.Nome,empresa.NomeFantasia,empresa.Data_add,false);

            await _EmpresaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
