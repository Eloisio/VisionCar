using System;
using System.Collections.Generic;

namespace VisionCar.Core.Entities
{
    public class User : BaseEntity
    {
        public User(int id, int idEmpresa, string nome, string email, string senha, DateTime data_add, bool ativo, bool master)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            Nome = nome;
            Email = email;
            Senha = senha;
            Data_add = data_add;
            Ativo = ativo;
            Master = master;
        }
       public User()
        {

        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Data_add { get; set; }
        public bool Ativo { get; set; }
        public bool Master { get; set; }

        public void Update(string nome, string email,bool ativo,string senha)
        {
            Nome = nome;
            Email = email;
            Ativo = ativo;
            Senha= senha;
        }
        public void UpdateSenha(string senha)
        {
            Senha=senha;
        }
        public void Updateativo(bool ativo)
        {
            Ativo=ativo;
        }
    }
}
