using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class FacturaController : ApiController
    {
        [HttpGet]
        [Route("api/Factura")]
        public List<Factura> Get()
        {
            return FacturaData.Listar();
        }

        [HttpGet]
        [Route("api/Factura/{id}")]
        public List<Factura> Get(long id)
        {
            return FacturaData.Consultar(id);
        }

        [HttpPost]
        [Route("api/Factura")]
        public bool Post([FromBody] Factura oFactura)
        {
            return FacturaData.Registrar(oFactura);
        }

        [HttpPut]
        [Route("api/Factura")]
        public bool Put([FromBody] Factura oFactura)
        {
            return FacturaData.Actualizar(oFactura);
        }

        [HttpDelete]
        [Route("api/Factura/{id}")]
        public bool Delete(long id)
        {
            return FacturaData.Eliminar(id);
        }
    }
}
