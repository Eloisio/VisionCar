using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace visioncar.Models
{
    public class ClienteModel
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
