using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using proyecto_api_grado.Models;

namespace proyecto_api_grado.Data
{
    public class CodigoPostalData
    {
        public static bool Registrar(CodigoPostal oCodigoPostal)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_insertar_cp {oCodigoPostal.IdCp},'{oCodigoPostal.Cp}','{oCodigoPostal.EstadoCp}',{oCodigoPostal.IdCiudad}";

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

        public static bool Actualizar(CodigoPostal oCodigoPostal)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_actualizar_codigo_postal {oCodigoPostal.IdCp},'{oCodigoPostal.Cp}','{oCodigoPostal.EstadoCp}',{oCodigoPostal.IdCiudad}";

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

        public static bool Eliminar(int idCp)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_eliminar_codigo_postal {idCp}";

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

        public static List<CodigoPostal> Consultar(int idCp)
        {
            List<CodigoPostal> oListaCodigoPostal = new List<CodigoPostal>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_consultar_codigo_postal {idCp}";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                if (dr.Read())
                {
                    oListaCodigoPostal.Add(new CodigoPostal()
                    {
                        IdCp = Convert.ToInt32(dr["id_cp"]),
                        Cp = dr["cp"].ToString(),
                        EstadoCp = dr["estado_cp"].ToString(),
                        IdCiudad = Convert.ToInt32(dr["id_ciudad"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaCodigoPostal;
        }

        public static List<CodigoPostal> Listar()
        {
            List<CodigoPostal> oListaCodigoPostal = new List<CodigoPostal>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = "EXEC usp_listar_codigos_postales";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaCodigoPostal.Add(new CodigoPostal()
                    {
                        IdCp = Convert.ToInt32(dr["id_cp"]),
                        Cp = dr["cp"].ToString(),
                        EstadoCp = dr["estado_cp"].ToString(),
                        IdCiudad = Convert.ToInt32(dr["id_ciudad"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaCodigoPostal;
        }
    }
}