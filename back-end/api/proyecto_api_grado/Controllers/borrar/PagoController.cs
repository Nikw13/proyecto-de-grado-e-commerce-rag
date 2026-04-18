using proyecto_api_grado.Data;
using proyecto_api_grado.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace proyecto_api_grado.Controllers
{
    public class PagoController : ApiController
    {
        public List<Pago> Get()
        {
            return PagoData.Listar();
        }

        public List<Pago> Get(long id)
        {
            return PagoData.Consultar(id);
        }

        public bool Post([FromBody] Pago oPago)
        {
            return PagoData.Registrar(oPago);
        }

        public bool Put([FromBody] Pago oPago)
        {
            return PagoData.Actualizar(oPago);
        }

        public bool Delete(long id)
        {
            return PagoData.Eliminar(id);
        }
    }
}
