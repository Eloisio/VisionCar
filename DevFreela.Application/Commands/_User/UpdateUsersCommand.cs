using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.Commands._User
{
    public class UpdateUsersCommand : IRequest<Unit>
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime data_add { get; set; }
        public bool ativo { get; set; }
        public bool Master { get; set; }
    }
}
