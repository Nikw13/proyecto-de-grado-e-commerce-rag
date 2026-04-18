using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using proyecto_api_grado.Models;

namespace proyecto_api_grado.Data
{
    public class ClienteData
    {
        public static bool Registrar(Cliente oCliente)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_registrar '{oCliente.IdCliente}','{oCliente.Nombres}','{oCliente.Apellidos}','{oCliente.Email}','{oCliente.Telefono}','{oCliente.Direccion}','{oCliente.Contrasena}'";

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

        public static bool Actualizar(Cliente oCliente)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_actualizar '{oCliente.IdCliente}','{oCliente.Nombres}','{oCliente.Apellidos}','{oCliente.Email}','{oCliente.Telefono}','{oCliente.Direccion}','{oCliente.Contrasena}'";

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

        public static bool Eliminar(string idCliente)
        {
            ConexionBD objConex = new ConexionBD(); 
            string sentencia = $"EXEC usp_eliminar '{idCliente}'";

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

        public static List<Cliente> Consultar(string idCliente) // para listar un solo cliente
        {
            List<Cliente> oListaCliente = new List<Cliente>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_consultar_clnt '{idCliente}'";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaCliente.Add(new Cliente()
                    {
                        IdCliente = dr["id_cliente"].ToString(),
                        Nombres = dr["nombres"].ToString(),
                        Apellidos = dr["apellidos"].ToString(),
                        Email = dr["email"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Contrasena = dr["contrasena"].ToString(),
                        CreadaEn = Convert.ToDateTime(dr["creada_en"]),
                        Estado = dr["estado"].ToString()
                    } 
                    );

                }
                return oListaCliente;
            }
            else
            {
                return oListaCliente;
            }
        }

        public static List<Cliente> Listar()
        {
            List<Cliente> oListaCliente = new List<Cliente>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = "EXEC usp_listar_clientes";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaCliente.Add(new Cliente()
                    {
                        IdCliente = dr["id_cliente"].ToString(),
                        Nombres = dr["nombres"].ToString(),
                        Apellidos = dr["apellidos"].ToString(),
                        Email = dr["email"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Contrasena = dr["contrasena"].ToString(),
                        CreadaEn = Convert.ToDateTime(dr["creada_en"]),
                        Estado = dr["estado"].ToString()
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaCliente;
        }
    }
}