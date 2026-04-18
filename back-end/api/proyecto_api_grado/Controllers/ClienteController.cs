using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class ClienteController : ApiController
    {
        [HttpGet]
        [Route("api/Cliente")]
        public List<Cliente> Get()
        {
            return ClienteData.Listar();
        }

        [HttpGet]
        [Route("api/Cliente/{idCliente}")]
        public List<Cliente> Get(string idCliente)
        {
            return ClienteData.Consultar(idCliente);
        }

        [HttpPost]
        [Route("api/Cliente")]
        public bool Post([FromBody] Cliente oCliente)
        {
            return ClienteData.Registrar(oCliente);
        }

        [HttpPut]
        [Route("api/Cliente")]
        public bool Put([FromBody] Cliente oCliente)
        {
            return ClienteData.Actualizar(oCliente);
        }

        [HttpDelete]
        [Route("api/Cliente/{id}")]
        public bool Delete(string id)
        {
            return ClienteData.Eliminar(id);
        }
    }
}