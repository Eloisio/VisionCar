using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel(int id, int idEmpresa, string nome, string placa, string celular, string tipoVeiculo, DateTime data_add, bool ativo)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            Nome = nome;
            Placa = placa;
            Celular = Celular;
            TipoVeiculo = TipoVeiculo;
            Data_add = data_add;
            Ativo = ativo;
        }
        public int Id  { get; set; }
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public string Celular { get; set; }
        public string TipoVeiculo { get; set; }
        public DateTime Data_add { get; set; }
        public bool Ativo { get; set; }
    }
}
