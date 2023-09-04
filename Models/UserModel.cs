using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace visioncar.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime data_add { get; set; }
        public bool ativo { get; set; }
        public bool Master { get; set; }
    }
}
