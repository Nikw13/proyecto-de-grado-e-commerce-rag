using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class EnvioController : ApiController
    {
        public List<Envio> Get()
        {
            return EnvioData.Listar();
        }

        public List<Envio> Get(long id)
        {
            return EnvioData.Consultar(id);
        }

        public bool Post([FromBody] Envio oEnvio)
        {
            return EnvioData.Registrar(oEnvio);
        }

        public bool Put([FromBody] Envio oEnvio)
        {
            return EnvioData.Actualizar(oEnvio);
        }

        public bool Delete(long id)
        {
            return EnvioData.Eliminar(id);
        }
    }
}
