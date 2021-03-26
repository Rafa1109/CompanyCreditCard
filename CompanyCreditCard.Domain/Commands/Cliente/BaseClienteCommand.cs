using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyCreditCard.Domain.Commands.Cliente
{
    public abstract class BaseClienteCommand : Command
    {
        public int Cod_Cliente { get; protected set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int DiaVencimentoCartao { get; set; }
    }
}
