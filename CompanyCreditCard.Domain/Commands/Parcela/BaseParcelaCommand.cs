using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyCreditCard.Domain.Commands.Parcela
{
    public class BaseParcelaCommand
    {
        public int CodCompra { get; protected set; }
        public int CodParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorParcela { get; set; }
        public int CodFatura { get; set; }
    }
}
