using System;
using System.ComponentModel;
using System.Security.Cryptography;
using UniEstoque.Util;

namespace UniEstoque.Classes
{
    public class Funcionario
    {
        private string _Senha;
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha 
        {
            get => _Senha;
            set => _Senha = PasswordHelper.HashPassword(value); // Sempre que for colcoar uma senha, deixar ela desse jeito aqui
        }
        public StatusEnum Status { get; set; }


        public Funcionario()
        {
            Id = 0; 
            Nome = String.Empty;
            Cpf = String.Empty;
            Senha = String.Empty;
            Status = StatusEnum.Ativo;
        }

        public enum StatusEnum
        {
            Ativo = 1,
            Inativo = 0,
            // Descutir a necessidade de outras opções 
        }
    }
}
