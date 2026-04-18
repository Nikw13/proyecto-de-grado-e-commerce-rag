using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class EnvioController : ApiController
    {
        [HttpGet]
        [Route("api/Envio")]
        public List<Envio> Get()
        {
            return EnvioData.Listar();
        }

        [HttpGet]
        [Route("api/Envio/{id}")]
        public List<Envio> Get(long id)
        {
            return EnvioData.Consultar(id);
        }

        [HttpPost]
        [Route("api/Envio")]
        public bool Post([FromBody] Envio oEnvio)
        {
            return EnvioData.Registrar(oEnvio);
        }

        [HttpPut]
        [Route("api/Envio")]
        public bool Put([FromBody] Envio oEnvio)
        {
            return EnvioData.Actualizar(oEnvio);
        }

        [HttpDelete]
        [Route("api/Envio/{id}")]
        public bool Delete(long id)
        {
            return EnvioData.Eliminar(id);
        }
    }
}
