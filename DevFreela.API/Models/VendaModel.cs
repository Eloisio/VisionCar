using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionCar.API.Models
{
    public class VendaModel
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdCliente { get; set; }
        public decimal Valor { get; set; }
        public decimal Caixinha { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public DateTime Data { get; set; }
        public bool Pago { get; set; }
        public bool AvisarCliente { get; set; }
        public bool Excluido { get; set; }
        public string Observacao { get; set; }
        public string Descricao { get; set; }
        public string Placa { get; set; }
    }
}
