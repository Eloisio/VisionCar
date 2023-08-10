using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.Commands._Ciente
{
    public class DeleteCienteCommand : IRequest<Unit>
    {
        public DeleteCienteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
