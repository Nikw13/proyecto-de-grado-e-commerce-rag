using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using proyecto_api_grado.Models;

namespace proyecto_api_grado.Data
{
    public class FacturaProdudctoData
    {
        public static bool Registrar(FacturaProducto oFacturaProducto)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_insertar_factura_producto {oFacturaProducto.IdFactura},{oFacturaProducto.IdProducto},{oFacturaProducto.Cantidad},{oFacturaProducto.Precio}";

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

        public static bool Actualizar(FacturaProducto oFacturaProducto)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_actualizar_factura_producto {oFacturaProducto.IdFactura},{oFacturaProducto.IdProducto},{oFacturaProducto.Cantidad},{oFacturaProducto.Precio}";

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

        public static bool Eliminar(long idFactura, int idProducto)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_eliminar_factura_producto {idFactura},{idProducto}";

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

        public static List<FacturaProducto> Consultar(long idFactura, int idProducto)
        {
            List<FacturaProducto> oListaFacturaProducto = new List<FacturaProducto>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_consultar_factura_producto {idFactura},{idProducto}";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                if (dr.Read())
                {
                    oListaFacturaProducto.Add(new FacturaProducto()
                    {
                        IdFactura = Convert.ToInt64(dr["id_factura"]),
                        IdProducto = Convert.ToInt32(dr["id_producto"]),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        Precio = Convert.ToDecimal(dr["precio"]),
                        ValorTotal = Convert.ToDecimal(dr["valor_total"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaFacturaProducto;
        }

        public static List<FacturaProducto> Listar()
        {
            List<FacturaProducto> oListaFacturaProducto = new List<FacturaProducto>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = "EXEC usp_listar_factura_productos";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaFacturaProducto.Add(new FacturaProducto()
                    {
                        IdFactura = Convert.ToInt64(dr["id_factura"]),
                        IdProducto = Convert.ToInt32(dr["id_producto"]),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        Precio = Convert.ToDecimal(dr["precio"]),
                        ValorTotal = Convert.ToDecimal(dr["valor_total"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaFacturaProducto;
        }
    }
}