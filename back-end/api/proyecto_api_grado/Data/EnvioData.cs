using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using proyecto_api_grado.Models;

namespace proyecto_api_grado.Data
{
    public class EnvioData
    {
        public static bool Registrar(Envio oEnvio)
        {
            ConexionBD objConex = new ConexionBD();
            string fechaEntrega = oEnvio.FechaEntrega.HasValue ? $"'{oEnvio.FechaEntrega.Value:yyyy-MM-dd HH:mm:ss}'" : "NULL";
            string sentencia = $"EXEC usp_insertar_envio '{oEnvio.DirecEnvio}','{oEnvio.EstadoEnvio}',{oEnvio.CostoEnvio},'{oEnvio.MetodoEnvio}','{oEnvio.EmpresaEnvio}',{fechaEntrega},{oEnvio.IdPago},{oEnvio.IdCp}";

            if (!objConex.EjecutarSentencia(sentencia, false))
            {
                objConex = null;
                return false;
            }
            else
            {
                objConex = null;
                return true;
            }
        }

        public static bool Actualizar(Envio oEnvio)
        {
            ConexionBD objConex = new ConexionBD();
            string fechaEntrega = oEnvio.FechaEntrega.HasValue ? $"'{oEnvio.FechaEntrega.Value:yyyy-MM-dd HH:mm:ss}'" : "NULL";
            string sentencia = $"EXEC usp_actualizar_envio {oEnvio.IdEnvio},'{oEnvio.DirecEnvio}','{oEnvio.EstadoEnvio}',{oEnvio.CostoEnvio},'{oEnvio.MetodoEnvio}','{oEnvio.EmpresaEnvio}',{fechaEntrega},{oEnvio.IdPago},{oEnvio.IdCp}";

            if (!objConex.EjecutarSentencia(sentencia, false))
            {
                objConex = null;
                return false;
            }
            else
            {
                objConex = null;
                return true;
            }
        }

        public static bool Eliminar(long idEnvio)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_eliminar_envio {idEnvio}";

            if (!objConex.EjecutarSentencia(sentencia, false))
            {
                objConex = null;
                return false;
            }
            else
            {
                objConex = null;
                return true;
            }
        }

        public static List<Envio> Consultar(long idEnvio)
        {
            List<Envio> oListaEnvio = new List<Envio>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_consultar_envio {idEnvio}";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                if (dr.Read())
                {
                    oListaEnvio.Add(new Envio()
                    {
                        IdEnvio = Convert.ToInt64(dr["id_envio"]),
                        DirecEnvio = dr["direc_envio"].ToString(),
                        FechaEnvio = Convert.ToDateTime(dr["fecha_envio"]),
                        FechaEntrega = dr["fecha_entrega"] != DBNull.Value ? Convert.ToDateTime(dr["fecha_entrega"]) : null,
                        EstadoEnvio = dr["estado_envio"].ToString(),
                        CostoEnvio = Convert.ToDecimal(dr["costo_envio"]),
                        MetodoEnvio = dr["metodo_envio"].ToString(),
                        EmpresaEnvio = dr["empresa_envio"].ToString(),
                        IdPago = Convert.ToInt64(dr["id_pago"]),
                        IdCp = Convert.ToInt32(dr["id_cp"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaEnvio;
        }

        public static List<Envio> Listar()
        {
            List<Envio> oListaEnvio = new List<Envio>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = "EXEC usp_listar_envios";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaEnvio.Add(new Envio()
                    {
                        IdEnvio = Convert.ToInt64(dr["id_envio"]),
                        DirecEnvio = dr["direc_envio"].ToString(),
                        FechaEnvio = Convert.ToDateTime(dr["fecha_envio"]),
                        FechaEntrega = dr["fecha_entrega"] != DBNull.Value ? Convert.ToDateTime(dr["fecha_entrega"]) : null,
                        EstadoEnvio = dr["estado_envio"].ToString(),
                        CostoEnvio = Convert.ToDecimal(dr["costo_envio"]),
                        MetodoEnvio = dr["metodo_envio"].ToString(),
                        EmpresaEnvio = dr["empresa_envio"].ToString(),
                        IdPago = Convert.ToInt64(dr["id_pago"]),
                        IdCp = Convert.ToInt32(dr["id_cp"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaEnvio;
        }
    }
}