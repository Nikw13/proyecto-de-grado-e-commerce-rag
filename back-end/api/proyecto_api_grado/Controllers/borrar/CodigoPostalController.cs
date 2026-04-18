using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class CodigoPostalController : ApiController
    {
        public List<CodigoPostal> Get()
        {
            return CodigoPostalData.Listar();
        }

        public List<CodigoPostal> Get(int id)
        {
            return CodigoPostalData.Consultar(id);
        }

        public bool Post([FromBody] CodigoPostal oCodigoPostal)
        {
            return CodigoPostalData.Registrar(oCodigoPostal);
        }

        public bool Put([FromBody] CodigoPostal oCodigoPostal)
        {
            return CodigoPostalData.Actualizar(oCodigoPostal);
        }

        public bool Delete(int id)
        {
            return CodigoPostalData.Eliminar(id);
        }
    }
}
