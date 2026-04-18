using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class PagoController : ApiController
    {
        [HttpGet]
        [Route("api/Pago")]
        public List<Pago> Get()
        {
            return PagoData.Listar();
        }

        [HttpGet]
        [Route("api/Pago/{id}")]
        public List<Pago> Get(long id)
        {
            return PagoData.Consultar(id);
        }

        [HttpPost]
        [Route("api/Pago")]
        public bool Post([FromBody] Pago oPago)
        {
            return PagoData.Registrar(oPago);
        }

        [HttpPut]
        [Route("api/Pago")]
        public bool Put([FromBody] Pago oPago)
        {
            return PagoData.Actualizar(oPago);
        }

        [HttpDelete]
        [Route("api/Pago/{id}")]
        public bool Delete(long id)
        {
            return PagoData.Eliminar(id);
        }
    }
}
