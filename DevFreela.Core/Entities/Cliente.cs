using System;

namespace VisionCar.Core.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(int id, int idEmpresa, string nome, string placa, string celular, string tipoVeiculo, DateTime data_add, bool ativo)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            Nome = nome;
            Placa = placa;
            Celular = celular;
            TipoVeiculo = tipoVeiculo;
            Data_add = DateTime.Now;
            Ativo = ativo;
        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public string Celular { get; set; }
        public string TipoVeiculo { get; set; }
        public DateTime Data_add { get; set; }
        public bool Ativo { get; set; }

        public void Update(int id, int idEmpresa, string nome, string placa, string celular, string tipoVeiculo, DateTime data_add, bool ativo)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            Nome = nome;
            Placa = placa;
            Celular = celular;
            TipoVeiculo = tipoVeiculo;
            Data_add = DateTime.Now;
            Ativo = ativo;
        }
    }
}
