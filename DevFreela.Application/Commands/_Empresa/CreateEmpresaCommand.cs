using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.Commands._Empresa
{
    public class CreateEmpresaCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public DateTime Data_add { get; set; }
        public bool Ativo { get; set; }
    }
}
