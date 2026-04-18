using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        [Route("api/Producto")]
        public List<Producto> Get()
        {
            return ProductoData.Listar();
        }

        [HttpGet]
        [Route("api/Producto/{id}")]
        public List<Producto> Get(int id)
        {
            return ProductoData.Consultar(id);
        }

        [HttpPost]
        [Route("api/Producto")]
        public bool Post([FromBody] Producto oProducto)
        {
            return ProductoData.Registrar(oProducto);
        }

        [HttpPut]
        [Route("api/Producto")]
        public bool Put([FromBody] Producto oProducto)
        {
            return ProductoData.Actualizar(oProducto);
        }

        [HttpDelete]
        [Route("api/Producto/{id}")]
        public bool Delete(int id)
        {
            return ProductoData.Eliminar(id);
        }
    }
}
