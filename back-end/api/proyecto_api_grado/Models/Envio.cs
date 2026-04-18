using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_api_grado.Models
{
    public class Envio
    {
        public long IdEnvio { get; set; }
        public string DirecEnvio { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string EstadoEnvio { get; set; }
        public decimal CostoEnvio { get; set; }
        public string MetodoEnvio { get; set; }
        public string EmpresaEnvio { get; set; }
        public long IdPago { get; set; }
        public int IdCp { get; set; }
    }
}