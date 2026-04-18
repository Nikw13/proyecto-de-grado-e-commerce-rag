using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using proyecto_api_grado.Models;

namespace proyecto_api_grado.Data
{
    public class DepartamentoData
    {
        public static bool Registrar(Departamento oDepartamento)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_insertar_departamento '{oDepartamento.NombreDep}','{oDepartamento.CodigoDaneDep}','{oDepartamento.EstadoDep}'";

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

        public static List<Departamento> Listar()
        {
            List<Departamento> oListaDepartamento = new List<Departamento>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = "EXEC usp_listar_departamentos";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaDepartamento.Add(new Departamento()
                    {
                        IdDepartamento = Convert.ToInt32(dr["id_departamento"]),
                        NombreDep = dr["nombre_dep"].ToString(),
                        CodigoDaneDep = dr["codigo_dane_dep"].ToString(),
                        EstadoDep = dr["estado_dep"].ToString()
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaDepartamento;
        }

        public static bool Actualizar(Departamento oDepartamento)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_actualizar_departamento {oDepartamento.IdDepartamento},'{oDepartamento.NombreDep}','{oDepartamento.CodigoDaneDep}','{oDepartamento.EstadoDep}'";

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

        public static bool Eliminar(int idDepartamento)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_eliminar_departamento {idDepartamento}";

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

        public static List<Departamento> Consultar(int idDepartamento)
        {
            List<Departamento> oListaDepartamento = new List<Departamento>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_consultar_departamento {idDepartamento}";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                if (dr.Read())
                {
                    oListaDepartamento.Add(new Departamento()
                    {
                        IdDepartamento = Convert.ToInt32(dr["id_departamento"]),
                        NombreDep = dr["nombre_dep"].ToString(),
                        CodigoDaneDep = dr["codigo_dane_dep"].ToString(),
                        EstadoDep = dr["estado_dep"].ToString()
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaDepartamento;
        }
    }
}