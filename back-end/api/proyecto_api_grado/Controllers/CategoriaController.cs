using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class CategoriaController : ApiController
    {
        [HttpGet]
        [Route("api/Categoria")]
        public List<Categoria> Get()
        {
            return CategoriaData.Listar();
        }

        [HttpGet]
        [Route("api/Categoria/{id}")]
        public List<Categoria> Get(int id)
        {
            return CategoriaData.Consultar(id);
        }

        [HttpPost]
        [Route("api/Categoria")]
        public bool Post([FromBody] Categoria oCategoria)
        {
            return CategoriaData.Registrar(oCategoria);
        }

        [HttpPut]
        [Route("api/Categoria")]
        public bool Put([FromBody] Categoria oCategoria)
        {
            return CategoriaData.Actualizar(oCategoria);
        }

        [HttpDelete]
        [Route("api/Categoria/{id}")]
        public bool Delete(int id)
        {
            return CategoriaData.Eliminar(id);
        }
    }
}
