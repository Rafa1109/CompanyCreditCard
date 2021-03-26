using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyCreditCard.Domain.Commands.Fatura
{
    public class BaseFaturaCommand
    {
        public int CodFatura { get; protected set; }
        public int CodCliente { get; protected set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorFatura { get; set; }
        public DateTime DataPagto { get; set; }
        public string CodigoBarra { get; set; }
    }
}
