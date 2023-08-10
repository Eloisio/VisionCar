using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.Commands._Servico
{
    public class DeleteServicoCommand : IRequest<Unit>
    {
        public DeleteServicoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
