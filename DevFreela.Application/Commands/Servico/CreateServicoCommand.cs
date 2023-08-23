using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.Commands._Servico
{
    public class CreateServicoCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public bool Ativo { get; set; }
    }
}
