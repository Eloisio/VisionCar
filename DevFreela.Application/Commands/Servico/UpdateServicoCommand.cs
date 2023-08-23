﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.Commands._Produto
{
    public class UpdateServicoCommand : IRequest<Unit>
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public bool ativo { get; set; }
    }
}
