using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using proyecto_api_grado.Models;

namespace proyecto_api_grado.Data
{
    public class PagoData
    {
        public static bool Registrar(Pago oPago)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_insertar_pago '{oPago.MetodoPago}',{oPago.Monto},'{oPago.Estado}',{oPago.IdFactura}";

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

        public static bool Actualizar(Pago oPago)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_actualizar_pago {oPago.IdPago},'{oPago.Estado}'";

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

        public static bool Eliminar(long idPago)
        {
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_eliminar_pago {idPago}";

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

        public static List<Pago> Consultar(long idPago)
        {
            List<Pago> oListaPago = new List<Pago>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = $"EXEC usp_consultar_pago {idPago}";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                if (dr.Read())
                {
                    oListaPago.Add(new Pago()
                    {
                        IdPago = Convert.ToInt64(dr["id_pago"]),
                        MetodoPago = dr["metodo_pago"].ToString(),
                        Monto = Convert.ToDecimal(dr["monto"]),
                        FechaPago = Convert.ToDateTime(dr["fecha_pago"]),
                        Estado = dr["estado"].ToString(),
                        IdFactura = Convert.ToInt64(dr["id_factura"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaPago;
        }

        public static List<Pago> Listar()
        {
            List<Pago> oListaPago = new List<Pago>();
            ConexionBD objConex = new ConexionBD();
            string sentencia = "EXEC usp_listar_pagos";

            if (objConex.Consultar(sentencia, false))
            {
                SqlDataReader dr = objConex.Reader;
                while (dr.Read())
                {
                    oListaPago.Add(new Pago()
                    {
                        IdPago = Convert.ToInt64(dr["id_pago"]),
                        MetodoPago = dr["metodo_pago"].ToString(),
                        Monto = Convert.ToDecimal(dr["monto"]),
                        FechaPago = Convert.ToDateTime(dr["fecha_pago"]),
                        Estado = dr["estado"].ToString(),
                        IdFactura = Convert.ToInt64(dr["id_factura"])
                    });
                }
            }
            objConex.CerrarConexion();
            objConex = null;
            return oListaPago;
        }
    }
}