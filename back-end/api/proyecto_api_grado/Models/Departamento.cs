using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_api_grado.Models
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string NombreDep { get; set; }
        public string CodigoDaneDep { get; set; }
        public string EstadoDep { get; set; }
    }
}