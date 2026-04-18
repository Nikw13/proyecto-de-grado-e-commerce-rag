using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class ResenaController : ApiController
    {
        [HttpGet]
        [Route("api/Resena")]
        public List<Resena> Get()
        {
            return ResenaData.Listar();
        }

        [HttpGet]
        [Route("api/Resena/producto/{idProducto}")]
        public List<Resena> Get(int idProducto)
        {
            return ResenaData.ListarPorProducto(idProducto);
        }

        [HttpPost]
        [Route("api/Resena")]
        public bool Post([FromBody] Resena oResena)
        {
            return ResenaData.Registrar(oResena);
        }

        [HttpPut]
        [Route("api/Resena")]
        public bool Put([FromBody] Resena oResena)
        {
            return ResenaData.Actualizar(oResena);
        }

        [HttpDelete]
        [Route("api/Resena/{id}")]
        public bool Delete(int id)
        {
            return ResenaData.Eliminar(id);
        }
    }
}
