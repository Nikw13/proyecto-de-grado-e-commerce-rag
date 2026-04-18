using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class FacturaProductoController : ApiController
    {
        [HttpGet]
        [Route("api/FacturaProducto")]
        public List<FacturaProducto> Get()
        {
            return FacturaProdudctoData.Listar();
        }

        [HttpGet]
        [Route("api/FacturaProducto/{idFactura}/{idProducto}")]
        public List<FacturaProducto> Get(long idFactura, int idProducto)
        {
            return FacturaProdudctoData.Consultar(idFactura, idProducto);
        }

        [HttpPost]
        [Route("api/FacturaProducto")]
        public bool Post([FromBody] FacturaProducto oFacturaProducto)
        {
            return FacturaProdudctoData.Registrar(oFacturaProducto);
        }

        [HttpPut]
        [Route("api/FacturaProducto")]
        public bool Put([FromBody] FacturaProducto oFacturaProducto)
        {
            return FacturaProdudctoData.Actualizar(oFacturaProducto);
        }

        [HttpDelete]
        [Route("api/FacturaProducto/{idFactura}/{idProducto}")]
        public bool Delete(long idFactura, int idProducto)
        {
            return FacturaProdudctoData.Eliminar(idFactura, idProducto);
        }
    }
}
