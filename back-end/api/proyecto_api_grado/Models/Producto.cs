using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_api_grado.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProd { get; set; }
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int StockQty { get; set; }
        public string EstadoProd { get; set; }
        public int IdCategoria { get; set; }
    }
}