using System;
using System.Collections.Generic;

namespace CompanyCreditCard.Domain.Models
{
    public class Compra
    {
        public int CodCompra { get; set; }
        public int CodCliente { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorCompra { get; set; }
        public int QuantParcelas { get; set; }
        public string DescrExtrato { get; set; }

        // EF Constructor
        private Compra() { }

        public virtual Cliente Cliente { get; private set; }
        public virtual ICollection<Parcela> Parcelas { get; private set; }
    }
}
