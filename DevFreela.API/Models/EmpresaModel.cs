using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionCar.API.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public DateTime Data_add { get; set; }
        public bool ativo { get; set; }
    }
}
