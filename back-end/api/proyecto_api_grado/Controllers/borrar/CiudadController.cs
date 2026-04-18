using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class CiudadController : ApiController
    {
        public List<Ciudad> Get()
        {
            return CiudadData.Listar();
        }

        public List<Ciudad> Get(int id)
        {
            return CiudadData.Consultar(id);
        }

        public bool Post([FromBody] Ciudad oCiudad)
        {
            return CiudadData.Registrar(oCiudad);
        }

        public bool Put([FromBody] Ciudad oCiudad)
        {
            return CiudadData.Actualizar(oCiudad);
        }

        public bool Delete(int id)
        {
            return CiudadData.Eliminar(id);
        }
    }
}
