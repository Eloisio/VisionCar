using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.ViewModels
{
    public class EmpresaViewModel
    {
        public EmpresaViewModel(int id,string nome,string nomefantasia,DateTime dataadd,bool ativo)
        {
            Id = id;
            Nome = nome;
            NomeFantasia = nomefantasia;
            Data_add = dataadd;
            Ativo = ativo;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string NomeFantasia { get; set; }
        public DateTime Data_add { get; set; }
        public bool Ativo { get; set; }
    }
}
