using MediatR;
using System;

namespace VisionCar.Application.Commands._User
{
    public class CreateUserCommand : IRequest<int>
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime data_add { get; set; }
        public bool ativo { get; set; }
        public bool Master { get; set; }
        public string Role { get; set; }
    }
}
