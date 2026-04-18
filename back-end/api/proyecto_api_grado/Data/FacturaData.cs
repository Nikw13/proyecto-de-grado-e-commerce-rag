using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using proyecto_api_grado.Models;

namespace proyecto_api_grado.Data
{
    public class FacturaData
    {
        public static bool Registrar(Factura oFactura)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_insertar_factura '{oFactura.NroFactura}',{oFactura.Subtotal},{oFactura.Iva},{oFactura.Total},'{oFactura.IdCliente}'";

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

        public static bool Actualizar(Factura oFactura)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_actualizar_factura {oFactura.IdFactura},{oFactura.Subtotal},{oFactura.Iva},{oFactura.Total}";

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

        public static bool Eliminar(long idFactura)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_eliminar_factura {idFactura}";

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

        public static List<Factura> Consultar(long idFactura)
        {
            List<Factura> oListaFactura = new List<Factura>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_consultar_factura {idFactura}";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                if (dr.Read())
                {
                    oListaFactura.Add(new Factura()
                    {
                        IdFactura = Convert.ToInt64(dr["id_factura"]),
                        NroFactura = dr["nro_factura"].ToString(),
                        FechaFac = Convert.ToDateTime(dr["fecha_fac"]),
                        Subtotal = Convert.ToDecimal(dr["subtotal"]),
                        Iva = Convert.ToDecimal(dr["iva"]),
                        Total = Convert.ToDecimal(dr["total"]),
                        IdCliente = dr["id_cliente"].ToString()
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaFactura;
        }

        public static List<Factura> Listar()
        {
            List<Factura> oListaFactura = new List<Factura>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = "EXEC usp_listar_facturas";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaFactura.Add(new Factura()
                    {
                        IdFactura = Convert.ToInt64(dr["id_factura"]),
                        NroFactura = dr["nro_factura"].ToString(),
                        FechaFac = Convert.ToDateTime(dr["fecha_fac"]),
                        Subtotal = Convert.ToDecimal(dr["subtotal"]),
                        Iva = Convert.ToDecimal(dr["iva"]),
                        Total = Convert.ToDecimal(dr["total"]),
                        IdCliente = dr["id_cliente"].ToString()
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaFactura;
        }
    }
}