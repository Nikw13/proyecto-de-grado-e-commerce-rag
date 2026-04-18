using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using proyecto_api_grado.Models;

namespace proyecto_api_grado.Data
{
    public class CategoriaData
    {
        public static bool Registrar(Categoria oCategoria)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_categoria_registrar '{oCategoria.NombreCatg}'";

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

        public static bool Actualizar(Categoria oCategoria)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_actualizar_categoria {oCategoria.IdCategoria},'{oCategoria.NombreCatg}','{oCategoria.Descripcion}','{oCategoria.EstadoCat}'";

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

        public static bool Eliminar(int idCategoria)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_categoria_eliminar {idCategoria}";

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

        public static List<Categoria> Consultar(int idCategoria)
        {
            List<Categoria> oListaCategoria = new List<Categoria>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_categoria_consultar {idCategoria}";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                if (dr.Read())
                {
                    oListaCategoria.Add(new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(dr["id_categoria"]),
                        NombreCatg = dr["nombre_catg"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                        EstadoCat = dr["estado_cat"].ToString()
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaCategoria;
        }

        public static List<Categoria> Listar()
        {
            List<Categoria> oListaCategoria = new List<Categoria>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = "EXEC usp_categoria_listar";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaCategoria.Add(new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(dr["id_categoria"]),
                        NombreCatg = dr["nombre_catg"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                        EstadoCat = dr["estado_cat"].ToString()
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaCategoria;
        }
    }
}