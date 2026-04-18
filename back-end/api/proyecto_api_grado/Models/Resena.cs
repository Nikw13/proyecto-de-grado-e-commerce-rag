using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_api_grado.Models
{
    public class Resena
    {
        public int IdResena { get; set; }
        public int Rating { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaResena { get; set; }
        public string IdCliente { get; set; }
        public int IdProducto { get; set; }
    }
}