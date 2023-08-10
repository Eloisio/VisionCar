using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.Commands._Empresa
{
    public class DeleteEmpresaCommand : IRequest<Unit>
    {
        public DeleteEmpresaCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
