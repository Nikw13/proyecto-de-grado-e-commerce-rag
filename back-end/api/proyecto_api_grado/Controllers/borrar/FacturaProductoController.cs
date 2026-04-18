using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class FacturaProductoController : ApiController
    {
        public List<FacturaProducto> Get()
        {
            return FacturaProdudctoData.Listar();
        }

        public List<FacturaProducto> Get(long idFactura, int idProducto)
        {
            return FacturaProdudctoData.Consultar(idFactura, idProducto);
        }

        public bool Post([FromBody] FacturaProducto oFacturaProducto)
        {
            return FacturaProdudctoData.Registrar(oFacturaProducto);
        }

        public bool Put([FromBody] FacturaProducto oFacturaProducto)
        {
            return FacturaProdudctoData.Actualizar(oFacturaProducto);
        }

        public bool Delete(long idFactura, int idProducto)
        {
            return FacturaProdudctoData.Eliminar(idFactura, idProducto);
        }
    }
}
