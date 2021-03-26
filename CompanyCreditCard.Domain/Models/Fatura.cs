using System;
using System.Collections.Generic;

namespace CompanyCreditCard.Domain.Models
{
    public class Fatura
    {
        public int CodFatura { get; set; }
        public int CodCliente { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorFatura { get; set; }
        public DateTime? DataPagto { get; set; }
        public string CodigoBarra { get; set; }

        // EF Constructor
        private Fatura() { }
        public virtual Cliente Cliente { get; private set; }
        public virtual ICollection<Parcela> Parcelas { get; private set; }
    }
}
