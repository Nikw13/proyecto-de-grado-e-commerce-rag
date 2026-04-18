using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using proyecto_api_grado.Models;

namespace proyecto_api_grado.Data
{
    public class ResenaData
    {
        public static bool Registrar(Resena oResena)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_resena_registrar {oResena.Rating},'{oResena.Comentario}','{oResena.IdCliente}',{oResena.IdProducto}";

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

        public static bool Actualizar(Resena oResena)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_resena_actualizar {oResena.IdResena},{oResena.Rating},'{oResena.Comentario}'";

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

        public static bool Eliminar(int idResena)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_resena_eliminar {idResena}";

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

        public static List<Resena> ListarPorProducto(int idProducto)
        {
            List<Resena> oListaResena = new List<Resena>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_resena_listar_por_producto {idProducto}";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaResena.Add(new Resena()
                    {
                        IdResena = Convert.ToInt32(dr["id_resena"]),
                        Rating = Convert.ToInt32(dr["rating"]),
                        Comentario = dr["comentario"].ToString(),
                        FechaResena = Convert.ToDateTime(dr["fecha_resena"]),
                        IdCliente = dr["id_cliente"].ToString(),
                        IdProducto = idProducto
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaResena;
        }

        public static List<Resena> Listar()
        {
            List<Resena> oListaResena = new List<Resena>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = "SELECT * FROM RESENA";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaResena.Add(new Resena()
                    {
                        IdResena = Convert.ToInt32(dr["id_resena"]),
                        Rating = Convert.ToInt32(dr["rating"]),
                        Comentario = dr["comentario"].ToString(),
                        FechaResena = Convert.ToDateTime(dr["fecha_resena"]),
                        IdCliente = dr["id_cliente"].ToString(),
                        IdProducto = Convert.ToInt32(dr["id_producto"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaResena;
        }
    }
}