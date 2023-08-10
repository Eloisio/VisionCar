using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.Commands._Empresa
{
    public class DeleteVendaCommand : IRequest<Unit>
    {
        public DeleteVendaCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
