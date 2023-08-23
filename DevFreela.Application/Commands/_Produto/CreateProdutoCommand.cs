using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.Commands._Produto
{
    public class CreateProdutoCommand : IRequest<int>
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public bool ativo { get; set; }
    }
}
