using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using proyecto_api_grado.Models;

namespace proyecto_api_grado.Data
{
    public class ProductoData
    {
        public static bool Registrar(Producto oProducto)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_producto_registrar '{oProducto.NombreProd}','{oProducto.Sku}','{oProducto.Descripcion}',{oProducto.Precio},{oProducto.StockQty},'{oProducto.EstadoProd}',{oProducto.IdCategoria}";

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

        public static bool Actualizar(Producto oProducto)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_actualizar_producto {oProducto.IdProducto},'{oProducto.NombreProd}','{oProducto.Sku}','{oProducto.Descripcion}',{oProducto.Precio},{oProducto.StockQty},'{oProducto.EstadoProd}',{oProducto.IdCategoria}";

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

        public static bool Eliminar(int idProducto)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_borrar_producto {idProducto}";

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

        public static List<Producto> Consultar(int idProducto)
        {
            List<Producto> oListaProducto = new List<Producto>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_consultar_producto {idProducto}";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                if (dr.Read())
                {
                    oListaProducto.Add(new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr["id_producto"]),
                        NombreProd = dr["nombre_prod"].ToString(),
                        Sku = dr["sku"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                        Precio = Convert.ToDecimal(dr["precio"]),
                        StockQty = Convert.ToInt32(dr["stock_qty"]),
                        EstadoProd = dr["estado_prod"].ToString(),
                        IdCategoria = Convert.ToInt32(dr["id_categoria"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaProducto;
        }

        public static List<Producto> Listar()
        {
            List<Producto> oListaProducto = new List<Producto>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = "EXEC usp_listar_producto";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaProducto.Add(new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr["id_producto"]),
                        NombreProd = dr["nombre_prod"].ToString(),
                        Sku = dr["sku"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                        Precio = Convert.ToDecimal(dr["precio"]),
                        StockQty = Convert.ToInt32(dr["stock_qty"]),
                        EstadoProd = dr["estado_prod"].ToString(),
                        IdCategoria = Convert.ToInt32(dr["id_categoria"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaProducto;
        }
    }
}