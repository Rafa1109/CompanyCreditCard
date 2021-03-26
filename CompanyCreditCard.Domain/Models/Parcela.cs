using System;

namespace CompanyCreditCard.Domain.Models
{
    public class Parcela
    {
        public int CodCompra { get; set; }
        public int CodParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorParcela { get; set; }
        public int? CodFatura { get; set; }

        //EF Constructor 
        private Parcela() { }
        public virtual Compra Compra { get; private set; }
        public virtual Fatura Fatura { get; private set; }
    }
}
