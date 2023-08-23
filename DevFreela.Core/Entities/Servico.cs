using VisionCar.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Core.Entities
{
    public class Servico : BaseEntity
    {
        public Servico(int id,int idEmpresa,  string descricao, decimal preco, bool ativo)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }


        public void Update(int id, int idEmpresa, string descricao, decimal preco, bool ativo)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
        }
    }
}
