using System;
using System.ComponentModel;

namespace UniEstoque.Classes
{
    public class Funcionario
    {
        private static int lastId = 0; // variavel privada para verificar o ultimo id gerado
        private int _Id; // id do funcionario
        public int Id
        {
            get { return _Id; }
            private set { _Id = value; } // só sera setada dentro do construtor, impossivel de setar fora de Funcionario
        }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public StatusEnum Status { get; set; }


        public Funcionario()
        {
            _Id = ++lastId; // adiciona mais um no lastId e seta o Id do funcionario 
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
