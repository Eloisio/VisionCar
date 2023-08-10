using VisionCar.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionCar.Core.Repositories;
using VisionCar.Application.Commands._Empresa;

namespace VisionCar.Application.Commands._Produto
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, Unit>
    {
        private readonly IProdutoRepository _ProdutoRepository;
        public UpdateProdutoCommandHandler(IProdutoRepository ProdutoRepository)
        {
            _ProdutoRepository = ProdutoRepository;
        }

        public async Task<Unit> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _ProdutoRepository.GetByIdAsync(request.id);

            produto.Update(request.id, request.idEmpresa, request.Descricao,request.Preco, request.ativo);

            await _ProdutoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
