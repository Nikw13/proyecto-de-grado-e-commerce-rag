using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_api_grado.Models
{
    public class Factura
    {
        public long IdFactura { get; set; }
        public string NroFactura { get; set; }
        public DateTime FechaFac { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string IdCliente { get; set; }
    }
}