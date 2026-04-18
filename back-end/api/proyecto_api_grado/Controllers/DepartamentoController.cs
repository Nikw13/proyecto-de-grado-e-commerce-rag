using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class DepartamentoController : ApiController
    {
        [HttpGet]
        [Route("api/Departamento")]
        public List<Departamento> Get()
        {
            return DepartamentoData.Listar();
        }

        [HttpGet]
        [Route("api/Departamento/{id}")]
        public List<Departamento> Get(int id)
        {
            return DepartamentoData.Consultar(id);
        }

        [HttpPost]
        [Route("api/Departamento")]
        public bool Post([FromBody] Departamento oDepartamento)
        {
            return DepartamentoData.Registrar(oDepartamento);
        }

        [HttpPut]
        [Route("api/Departamento")]
        public bool Put([FromBody] Departamento oDepartamento)
        {
            return DepartamentoData.Actualizar(oDepartamento);
        }

        [HttpDelete]
        [Route("api/Departamento/{id}")]
        public bool Delete(int id)
        {
            return DepartamentoData.Eliminar(id);
        }
    }
}
