using VisionCar.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Core.Entities
{
    public class Empresa : BaseEntity
    {
        public Empresa(int id, string nome, string nomefantasia, DateTime data_add, bool ativo)
        {
            Id = id;
            Nome = nome;
            NomeFantasia = nomefantasia;
            Data_add = data_add;
            Ativo = ativo;
        }
        public Empresa()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public DateTime Data_add { get; set; }
        public bool Ativo { get; set; }

        public void Cancel()
        {
            Ativo = false;
        }

        public void Update(string nome, string nomefantasia, DateTime data_add, bool ativo)
        {
            Nome = nome;
            NomeFantasia = nomefantasia;
            Data_add = data_add;
            Ativo = ativo;
        }
    }
}
