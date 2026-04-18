using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_api_grado.Models
{
    public class Ciudad
    {
        public int IdCiudad { get; set; }
        public string NombreCiu { get; set; }
        public string CodigoDaneCiu { get; set; }
        public string EstadoCiu { get; set; }
        public int IdDepartamento { get; set; }
    }
}