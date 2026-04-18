using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class CodigoPostalController : ApiController
    {
        [HttpGet]
        [Route("api/CodigoPostal")]
        public List<CodigoPostal> Get()
        {
            return CodigoPostalData.Listar();
        }

        [HttpGet]
        [Route("api/CodigoPostal/{id}")]
        public List<CodigoPostal> Get(int id)
        {
            return CodigoPostalData.Consultar(id);
        }

        [HttpPost]
        [Route("api/CodigoPostal")]
        public bool Post([FromBody] CodigoPostal oCodigoPostal)
        {
            return CodigoPostalData.Registrar(oCodigoPostal);
        }

        [HttpPut]
        [Route("api/CodigoPostal")]
        public bool Put([FromBody] CodigoPostal oCodigoPostal)
        {
            return CodigoPostalData.Actualizar(oCodigoPostal);
        }

        [HttpDelete]
        [Route("api/CodigoPostal/{id}")]
        public bool Delete(int id)
        {
            return CodigoPostalData.Eliminar(id);
        }
    }
}
