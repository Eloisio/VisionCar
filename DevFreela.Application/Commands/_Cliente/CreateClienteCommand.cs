using MediatR;
using System;

namespace VisionCar.Application.Commands.CreateCliente
{
    public class CreateClienteCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public string Celular { get; set; }
        public string TipoVeiculo { get; set; }
        public DateTime data_add { get; set; }
        public bool ativo { get; set; }
    }
}
