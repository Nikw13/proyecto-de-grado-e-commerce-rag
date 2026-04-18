using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using proyecto_api_grado.Models;

namespace proyecto_api_grado.Data
{
    public class CiudadData
    {
        public static bool Registrar(Ciudad oCiudad)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_insertar_ciudad '{oCiudad.NombreCiu}','{oCiudad.CodigoDaneCiu}','{oCiudad.EstadoCiu}',{oCiudad.IdDepartamento}";

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

        public static List<Ciudad> Listar()
        {
            List<Ciudad> oListaCiudad = new List<Ciudad>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = "EXEC usp_listar_ciudades";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaCiudad.Add(new Ciudad()
                    {
                        IdCiudad = Convert.ToInt32(dr["id_ciudad"]),
                        NombreCiu = dr["nombre_ciu"].ToString(),
                        CodigoDaneCiu = dr["codigo_dane_ciu"].ToString(),
                        EstadoCiu = dr["estado_ciu"].ToString(),
                        IdDepartamento = Convert.ToInt32(dr["id_departamento"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaCiudad;
        }

        public static bool Actualizar(Ciudad oCiudad)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_actualizar_ciudad {oCiudad.IdCiudad},'{oCiudad.NombreCiu}','{oCiudad.CodigoDaneCiu}','{oCiudad.EstadoCiu}',{oCiudad.IdDepartamento}";

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

        public static bool Eliminar(int idCiudad)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_eliminar_ciudad {idCiudad}";

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

        public static List<Ciudad> Consultar(int idCiudad)
        {
            List<Ciudad> oListaCiudad = new List<Ciudad>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_consultar_ciudad {idCiudad}";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                if (dr.Read())
                {
                    oListaCiudad.Add(new Ciudad()
                    {
                        IdCiudad = Convert.ToInt32(dr["id_ciudad"]),
                        NombreCiu = dr["nombre_ciu"].ToString(),
                        CodigoDaneCiu = dr["codigo_dane_ciu"].ToString(),
                        EstadoCiu = dr["estado_ciu"].ToString(),
                        IdDepartamento = Convert.ToInt32(dr["id_departamento"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaCiudad;
        }
    }
}