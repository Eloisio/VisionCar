using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace visioncar.Models
{
    public class ItemVendaModel
    {
        public int id { get; set; }
        public int idVenda { get; set; }
        public int idServico { get; set; }
        public int idProduto { get; set; }
        public decimal Valor { get; set; }
        public bool Excluido { get; set; }
    }
}
