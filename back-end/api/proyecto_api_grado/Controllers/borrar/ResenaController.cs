using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class ResenaController : ApiController
    {
        public List<Resena> Get()
        {
            return ResenaData.Listar();
        }

        public List<Resena> Get(int idProducto)
        {
            return ResenaData.ListarPorProducto(idProducto);
        }

        public bool Post([FromBody] Resena oResena)
        {
            return ResenaData.Registrar(oResena);
        }

        public bool Put([FromBody] Resena oResena)
        {
            return ResenaData.Actualizar(oResena);
        }

        public bool Delete(int id)
        {
            return ResenaData.Eliminar(id);
        }
    }
}
