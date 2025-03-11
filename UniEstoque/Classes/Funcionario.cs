using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniEstoque.Classes
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public int Status { get; set; }


        public Funcionario()
        {
            Id = 0;
            Nome = String.Empty;
            Cpf = String.Empty;
            Senha = String.Empty;
            Status = 0;
        }
    }
}
