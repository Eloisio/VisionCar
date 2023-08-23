using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionCar.API.Models
{
    public class ServicoModel
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string descricao { get; set; }
        public string Preco { get; set; }
        public bool Ativo { get; set; }
    }
}
