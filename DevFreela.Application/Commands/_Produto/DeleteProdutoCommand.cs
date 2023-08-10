using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.Commands._Produto
{
    public class DeleteProdutoCommand : IRequest<Unit>
    {
        public DeleteProdutoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
