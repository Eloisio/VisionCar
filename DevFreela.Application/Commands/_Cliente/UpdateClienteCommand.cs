using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.Commands._Ciente
{
    public class UpdateClienteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public string Celular { get; set; }
        public string TipoVeiculo { get; set; }
        public DateTime Data_add { get; set; }
        public bool Ativo { get; set; }
    }
}
