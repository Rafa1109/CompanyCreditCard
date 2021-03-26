using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyCreditCard.Domain.Commands.Compra
{
    public class BaseCompraCommand
    {
        public int CodCompra { get; protected set; }
        public int CodCliente { get; protected set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorCompra { get; set; }
        public int QuantParcelas { get; set; }
        public string DescrExtrato { get; set; }
    }
}
