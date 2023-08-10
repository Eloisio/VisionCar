using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.ViewModels
{
    public class EmpresaDetailsViewModel
    {
        public EmpresaDetailsViewModel(int id,string nome,string nomefantasia,string dataadd)
        {
            //Id = id;
            //Nome = nome;
            //NomeFantasia = nomefantasia;
            //Data_add = data_add;
            //Ativo = ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public DateTime Data_add { get; set; }
        public bool Ativo { get; set; }
    }
}
