using System;
using System.Collections.Generic;
using System.Numerics;

namespace VisionCar.Core.Entities
{
    public class Venda : BaseEntity
    {
        public Venda(){}
        public Venda(
           int id
         , int idEmpresa
         , int idCliente
         , decimal valor
         , decimal caixinha
         , DateTime inicio
         , DateTime fim
         , DateTime data
         , bool pago
         , bool avisarCliente
         , bool excluido
         , string observacao
         , string descricao
            , string placa
            )
        {
            Id = id;
            IdEmpresa = idEmpresa;
            IdCliente = idCliente;
            Valor = valor;
            Caixinha = caixinha;
            Inicio = inicio;
            Fim = fim;
            Data = data;
            Pago = pago;
            AvisarCliente = avisarCliente;
            Excluido = excluido;
            Observacao = observacao;
            Descricao = descricao;
            Placa = placa;
        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdCliente { get; set; }
        public decimal Valor { get; set; }
        public decimal Caixinha { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public DateTime Data { get; set; }
        public bool Pago { get; set; }
        public bool AvisarCliente { get; set; }
        public bool Excluido { get; set; }
        public string Observacao { get; set; }
        public string Descricao { get; set; }
        public string Placa { get; set; }
        public void Update(int id
         , int idEmpresa
         , int idCliente
         , decimal valor
         , decimal caixinha
         , DateTime inicio
         , DateTime fim
         , DateTime data
         , bool pago
         , bool avisarCliente
         , bool excluido
         , string observacao
         , string descricao, string placa)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            IdCliente = idCliente;
            Valor = valor;
            Caixinha = caixinha;
            Inicio = inicio;
            Fim = fim;
            Data = data;
            Pago = pago;
            AvisarCliente = avisarCliente;
            Excluido = excluido;
            Observacao = observacao;
            Descricao = descricao;
            Placa = placa;
        }
    }
}
