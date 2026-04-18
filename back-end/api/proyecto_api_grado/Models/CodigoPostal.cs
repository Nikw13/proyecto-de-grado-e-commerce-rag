using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_api_grado.Models
{
    public class CodigoPostal
    {
        public int IdCp { get; set; }
        public string Cp { get; set; }
        public string EstadoCp { get; set; }
        public int IdCiudad { get; set; }
    }
}