using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class CiudadController : ApiController
    {
        [HttpGet]
        [Route("api/Ciudad")]
        public List<Ciudad> Get()
        {
            return CiudadData.Listar();
        }

        [HttpGet]
        [Route("api/Ciudad/{id}")]
        public List<Ciudad> Get(int id)
        {
            return CiudadData.Consultar(id);
        }

        [HttpPost]
        [Route("api/Ciudad")]
        public bool Post([FromBody] Ciudad oCiudad)
        {
            return CiudadData.Registrar(oCiudad);
        }

        [HttpPut]
        [Route("api/Ciudad")]
        public bool Put([FromBody] Ciudad oCiudad)
        {
            return CiudadData.Actualizar(oCiudad);
        }

        [HttpDelete]
        [Route("api/Ciudad/{id}")]
        public bool Delete(int id)
        {
            return CiudadData.Eliminar(id);
        }
    }
}
