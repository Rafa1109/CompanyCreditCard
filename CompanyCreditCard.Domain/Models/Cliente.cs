using System.Collections.Generic;

namespace CompanyCreditCard.Domain.Models
{
    public class Cliente
    {
        public int Cod_Cliente { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int DiaVencimentoCartao { get; set; }

        // EF Constructor
        private Cliente() { }

        public virtual ICollection<Compra> Compras { get; private set; }
        public virtual ICollection<Fatura> Faturas { get; private set; }
    }
}
