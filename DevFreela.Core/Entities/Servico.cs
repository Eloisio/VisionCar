using VisionCar.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Core.Entities
{
    public class Servico : BaseEntity
    {
        public Servico(int id,int idEmpresa,  string descricao, string preco, bool ativo)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            Descricao = descricao;
            Preco = preco;
        //    PrecoGD=precogd;
            Ativo = ativo;
        }
       public Servico()
        {

        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
       // public string PrecoGD { get; set; }
        public bool Ativo { get; set; }


        public void Update(int id, int idEmpresa, string descricao, string preco, bool ativo)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            Descricao = descricao;
            Preco = preco;
        //    PrecoGD = precogd;
            Ativo = ativo;
        }
    }
}
