using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace visioncar.Models
{
    public class ProdutoModel
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public bool ativo { get; set; }
    }
}
