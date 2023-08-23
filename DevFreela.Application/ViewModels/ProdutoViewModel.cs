using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel(int id, int idEmpresa, string descricao, string preco, bool ativo)
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
        public string Preco { get; set; }
        public bool Ativo { get; set; }
    }
}
