using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class ProductoController : ApiController
    {
        public List<Producto> Get()
        {
            return ProductoData.Listar();
        }

        public List<Producto> Get(int id)
        {
            return ProductoData.Consultar(id);
        }

        public bool Post([FromBody] Producto oProducto)
        {
            return ProductoData.Registrar(oProducto);
        }

        public bool Put([FromBody] Producto oProducto)
        {
            return ProductoData.Actualizar(oProducto);
        }

        public bool Delete(int id)
        {
            return ProductoData.Eliminar(id);
        }
    }
}
