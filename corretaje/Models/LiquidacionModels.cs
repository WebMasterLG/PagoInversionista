using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using corretaje.Clases;
using corretaje.Helpers;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace corretaje.Models
{
    public class LiquidacionModels
    {
        private static readonly string connCorretaje = Environment.GetEnvironmentVariable("CORRETAJE", EnvironmentVariableTarget.Machine);
        private static readonly string GESTIONPROD = Environment.GetEnvironmentVariable("GESTIONPROD", EnvironmentVariableTarget.Machine);
        private static readonly int sqlTimeout = Convert.ToInt32(Environment.GetEnvironmentVariable("SQLTIMEOUT", EnvironmentVariableTarget.Machine));
        public static List<liquidaciones> Liquidacion_Carga_Lista_2(int id_usuario, string mes, string id_estado_arriendo, string id_estado_propietario, int por_cliente, string mes_hasta, string sac_inversionista, int filtros, string forma_pago_liq, string rut)
        {
            List<liquidaciones> lst = new List<liquidaciones>();
            string Llama_PA = "Liquidacion_Carga_Lista_2";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@id_estado_arriendo", id_estado_arriendo);
                cmd.Parameters.AddWithValue("@id_estado_propietario", id_estado_propietario);
                cmd.Parameters.AddWithValue("@por_cliente", por_cliente);
                cmd.Parameters.AddWithValue("@mes_hasta", mes_hasta);
                cmd.Parameters.AddWithValue("@sac_inversionista", sac_inversionista);
                cmd.Parameters.AddWithValue("@filtros", filtros);
                cmd.Parameters.AddWithValue("@forma_pago_liq", forma_pago_liq);
                cmd.Parameters.AddWithValue("@rut_cliente", rut);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        lst = reader.ToList<liquidaciones>();
                    }
                }
                conn.Close();
            }

            return lst;
        }

        public static List<liquidaciones> Liquidaciones(int id_usuario, string mes, string id_estado_arriendo, string id_estado_propietario, int por_cliente, string mes_hasta, int sac_inversionista, int filtros, int forma_pago_liq, int rut)
        {
            List<liquidaciones> lst = new List<liquidaciones>();
            string Llama_PA = "exec Liquidacion_Carga_Lista @id_usuario, @mes, @id_estado_arriendo, @id_estado_propietario, @por_cliente, @mes_hasta, @sac_inversionista, @filtros,@forma_pago_liq,@rut_cliente";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@id_estado_arriendo", id_estado_arriendo);
                cmd.Parameters.AddWithValue("@id_estado_propietario", id_estado_propietario);
                cmd.Parameters.AddWithValue("@por_cliente", por_cliente);
                cmd.Parameters.AddWithValue("@mes_hasta", mes_hasta);
                cmd.Parameters.AddWithValue("@sac_inversionista", sac_inversionista);
                cmd.Parameters.AddWithValue("@filtros", filtros);
                cmd.Parameters.AddWithValue("@forma_pago_liq", forma_pago_liq);
                cmd.Parameters.AddWithValue("@rut_cliente", rut);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new liquidaciones
                        {
                            id_liq = (ColumnExists(reader, "id_liq") == true ? reader["id_liq"].ToString() : "0"),
                            id_pago = (ColumnExists(reader, "id_pago") == true ? reader["id_pago"].ToString() : "0"),
                            id_contrato = (ColumnExists(reader, "id_contrato") == true ? reader["id_contrato"].ToString() : "0"),
                            id_prop_arriendo = (ColumnExists(reader, "id_prop_arriendo") == true ? reader["id_prop_arriendo"].ToString() : "0"),
                            mes = (ColumnExists(reader, "mes") == true ? reader["mes"].ToString() : ""),
                            direccion = (ColumnExists(reader, "direccion") == true ? reader["direccion"].ToString() : ""),
                            num_depto = (ColumnExists(reader, "num_depto") == true ? reader["num_depto"].ToString() : ""),
                            propietario = (ColumnExists(reader, "propietario") == true ? reader["propietario"].ToString() : ""),
                            arriendo = (ColumnExists(reader, "arriendo") == true ? reader["arriendo"].ToString() : "0"),
                            estado_arriendo = (ColumnExists(reader, "estado_arriendo") == true ? reader["estado_arriendo"].ToString() : ""),
                            com_admin_por = (ColumnExists(reader, "com_admin_por") == true ? reader["com_admin_por"].ToString() : "0%"),
                            com_neta = (ColumnExists(reader, "com_neta") == true ? reader["com_neta"].ToString() : "0"),
                            com_iva = (ColumnExists(reader, "com_iva") == true ? reader["com_iva"].ToString() : "0"),
                            descuentos = (ColumnExists(reader, "descuentos") == true ? reader["descuentos"].ToString() : "0"),
                            a_pagar = (ColumnExists(reader, "a_pagar") == true ? reader["a_pagar"].ToString() : "0"),
                            estado_pago = (ColumnExists(reader, "estado_pago") == true ? reader["estado_pago"].ToString() : ""),
                            ejecutivo = (ColumnExists(reader, "ejecutivo") == true ? reader["ejecutivo"].ToString() : ""),
                            estado_factura = (ColumnExists(reader, "estado_factura") == true ? reader["estado_factura"].ToString() : ""),
                            mail = (ColumnExists(reader, "mail") == true ? reader["mail"].ToString() : ""),
                            observacion = (ColumnExists(reader, "observacion") == true ? reader["observacion"].ToString() : ""),
                            periodo = (ColumnExists(reader, "periodo") == true ? reader["periodo"].ToString() : ""),
                            concepto = (ColumnExists(reader, "concepto") == true ? reader["concepto"].ToString() : ""),
                            rut_propietario = (ColumnExists(reader, "rut_propietario") == true ? reader["rut_propietario"].ToString() : ""),
                            monto = (ColumnExists(reader, "monto") == true ? reader["monto"].ToString() : "0"),
                            total_com = (ColumnExists(reader, "com_total") == true ? reader["com_total"].ToString() : "0"),
                            g_file_factura = (ColumnExists(reader, "g_file_factura") == true ? reader["g_file_factura"].ToString() : ""),
                            g_file_liquidacion = (ColumnExists(reader, "g_file_liquidacion") == true ? reader["g_file_liquidacion"].ToString() : ""),
                            mes_liq = (ColumnExists(reader, "mes_liq") == true ? reader["mes_liq"].ToString() : ""),
                            mes_gracia = (ColumnExists(reader, "mes_gracia") == true ? reader["mes_gracia"].ToString() : "0"),
                            sac_inversionista = (ColumnExists(reader, "sac_inversionista") == true ? reader["sac_inversionista"].ToString() : ""),
                            tf_fecha = (ColumnExists(reader, "tf_fecha") == true ? reader["tf_fecha"].ToString() : "tf_fecha"),
                            b_pago_contra_garantia = (ColumnExists(reader, "b_pago_contra_garantia") == true ? reader["b_pago_contra_garantia"].ToString() : "0"),
                            com_total = (ColumnExists(reader, "com_total") == true ? reader["com_total"].ToString() : "0"),
                            f_mail_liquidacion = (ColumnExists(reader, "f_mail_liquidacion") == true ? reader["f_mail_liquidacion"].ToString() : "0"),
                            forma_pago = (ColumnExists(reader, "forma_pago") == true ? reader["forma_pago"].ToString() : ""),
                            g_tipologia = (ColumnExists(reader, "g_tipologia") == true ? reader["g_tipologia"].ToString() : ""),
                            //cheque_rescatado = (ColumnExists(reader, "cheque_rescatado") == true ? reader["cheque_rescatado"].ToString() : "0")

                            b_repetido = (ColumnExists(reader, "b_repetido") == true ? reader["b_repetido"].ToString() : ""),
                            color_letra = (ColumnExists(reader, "color_letra") == true ? reader["color_letra"].ToString() : ""),
                            b_comentario = (ColumnExists(reader, "b_comentario") == true ? reader["b_comentario"].ToString() : ""),

                            g_archivo_factura = (ColumnExists(reader, "g_archivo_factura") == true ? reader["g_archivo_factura"].ToString() : ""),
                            folio_factura = (ColumnExists(reader, "folio_factura") == true ? reader["folio_factura"].ToString() : ""),
                            icono_mostrar_ldi = (ColumnExists(reader, "icono_mostrar_ldi") == true ? reader["icono_mostrar_ldi"].ToString() : ""),

                            g_archivo_factura_ilp = (ColumnExists(reader, "g_archivo_factura_ilp") == true ? reader["g_archivo_factura_ilp"].ToString() : ""),
                            folio_factura_ilp = (ColumnExists(reader, "folio_factura_ilp") == true ? reader["folio_factura_ilp"].ToString() : ""),
                            icono_mostrar_ilp = (ColumnExists(reader, "icono_mostrar_ilp") == true ? reader["icono_mostrar_ilp"].ToString() : ""),
                            f_termino_contrato = (ColumnExists(reader, "f_termino_contrato") == true ? reader["f_termino_contrato"].ToString() : ""),
                            color_f_termino = (ColumnExists(reader, "color_f_termino") == true ? reader["color_f_termino"].ToString() : "")

                        });
                    }
                }
                conn.Close();
            }

            return lst;
        }

        public static bool ColumnExists(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public static List<liquidaciones> Llama_Liquidacion_Carga_Lista(int id_usuario, string mes, int id_estado_arriendo, int id_estado_propietario, int por_cliente, string mes_hasta, int sac_inversionista) //Trae listado de liquidaciones
        {
            List<liquidaciones> lst = new List<liquidaciones>();
            string Llama_PA = "EXEC Liquidacion_Carga_Lista @id_usuario, @mes, @id_estado_arriendo, @id_estado_propietario, @por_cliente, @mes_hasta, @sac_inversionista";
            //string Llama_DC = "EXEC Liquidacion_Obtener_Doble_Canon @id_usuario, @mes, @id_estado_arriendo, @id_estado_propietario, @por_cliente, @mes_hasta";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@id_estado_arriendo", id_estado_arriendo);
                cmd.Parameters.AddWithValue("@id_estado_propietario", id_estado_propietario);
                cmd.Parameters.AddWithValue("@por_cliente", por_cliente);
                cmd.Parameters.AddWithValue("@mes_hasta", mes_hasta);
                cmd.Parameters.AddWithValue("@sac_inversionista", sac_inversionista);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new liquidaciones
                        {

                            id_pago = reader["id_pago"].ToString(),
                            id_contrato = reader["id_contrato"].ToString(),
                            id_prop_arriendo = reader["id_prop_arriendo"].ToString(),
                            mes = reader["mes"].ToString(),
                            direccion = reader["direccion"].ToString(),
                            num_depto = reader["num_depto"].ToString(),
                            propietario = reader["propietario"].ToString(),
                            arriendo = reader["arriendo"].ToString(),
                            estado_arriendo = reader["estado_arriendo"].ToString(),
                            com_admin_por = reader["com_admin_por"].ToString(),
                            com_neta = reader["com_neta"].ToString(),
                            //com_neta_sf = reader["com_neta_sf"].ToString(),
                            com_iva = reader["com_iva"].ToString(),
                            //com_iva_sf = reader["com_iva_sf"].ToString(),
                            descuentos = reader["descuentos"].ToString(),
                            //descuentos_sf = reader["descuentos_sf"].ToString(),
                            a_pagar = reader["a_pagar"].ToString(),
                            //a_pagar_sf = reader["a_pagar_sf"].ToString(),
                            estado_pago = reader["estado_pago"].ToString(),
                            ejecutivo = reader["ejecutivo"].ToString(),
                            estado_factura = reader["estado_factura"].ToString(),
                            mail = reader["mail"].ToString(),
                            observacion = reader["observacion"].ToString(),
                            concepto = reader["concepto"].ToString(),
                            mes_gracia = reader["mes_gracia"].ToString(),
                            sac_inversionista = reader["sac_inversionista"].ToString(),
                            tf_fecha = reader["tf_fecha"].ToString(),
                            b_pago_contra_garantia = reader["b_pago_contra_garantia"].ToString(),
                            //g_file_propietario = reader["g_file_propietario"].ToString()
                            //cheque_rescatado = reader["cheque_rescatado"].ToString()

                            b_repetido = reader["b_repetido"].ToString(),
                            color_letra = reader["color_letra"].ToString(),
                            b_comentario = reader["b_comentario"].ToString(),
                            id_forma_pago = reader["id_forma_pago"].ToString()

                        });
                    }
                }
                conn.Close();

                //doble canon
            }
            return lst;
        }

        public static List<liquidaciones> Llama_Aprobacion_Carga_Lista(int id_usuario, string mes, int id_estado_arriendo, int id_estado_propietario, int por_cliente, string mes_hasta, int sac_inversionista) //Trae listado de liquidaciones
        {
            List<liquidaciones> lst = new List<liquidaciones>();
            string Llama_PA = "EXEC Liquidacion_Carga_Lista @id_usuario, @mes, @id_estado_arriendo, @id_estado_propietario, @por_cliente, @mes_hasta, @sac_inversionista";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@id_estado_arriendo", id_estado_arriendo);
                cmd.Parameters.AddWithValue("@id_estado_propietario", id_estado_propietario);
                cmd.Parameters.AddWithValue("@por_cliente", por_cliente);
                cmd.Parameters.AddWithValue("@mes_hasta", mes_hasta);
                cmd.Parameters.AddWithValue("@sac_inversionista", sac_inversionista);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new liquidaciones
                        {
                            id_liq = reader["id_liq"].ToString(),
                            id_pago = reader["id_pago"].ToString(),
                            //id_contrato = reader["id_contrato"].ToString(),
                            //id_prop_arriendo = reader["id_prop_arriendo"].ToString(),
                            mes = reader["mes"].ToString(),
                            rut_propietario = reader["rut_propietario"].ToString(),
                            //direccion = reader["direccion"].ToString(),
                            //num_depto = reader["num_depto"].ToString(),
                            propietario = reader["propietario"].ToString(),
                            monto = reader["monto"].ToString(),
                            //arriendo = reader["arriendo"].ToString(),
                            //estado_arriendo = reader["estado_arriendo"].ToString(),
                            //com_admin_por = reader["com_admin_por"].ToString(),
                            com_neta = reader["com_neta"].ToString(),
                            //com_neta_sf = reader["com_neta_sf"].ToString(),
                            com_iva = reader["com_iva"].ToString(),
                            total_com = reader["com_total"].ToString(),
                            //com_iva_sf = reader["com_iva_sf"].ToString(),
                            descuentos = reader["descuentos"].ToString(),
                            //descuentos_sf = reader["descuentos_sf"].ToString(),
                            a_pagar = reader["a_pagar"].ToString(),
                            g_file_factura = reader["g_file_factura"].ToString(),
                            g_file_liquidacion = reader["g_file_liquidacion"].ToString(),
                            mes_liq = reader["mes_liq"].ToString(),
                            sac_inversionista = reader["sac_inversionista"].ToString()
                            //a_pagar_sf = reader["a_pagar_sf"].ToString(),
                            //estado_pago = reader["estado_pago"].ToString(),
                            //ejecutivo = reader["ejecutivo"].ToString(),
                            //estado_factura = reader["estado_factura"].ToString(),
                            //mail = reader["mail"].ToString(),
                            //observacion = reader["observacion"].ToString(),
                            //g_file_propietario = reader["g_file_propietario"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }


        public static List<liquidaciones> Llama_Liquidacion_Carga_Lista_Liquidadas(int id_usuario, string mes, int id_estado_arriendo, int id_estado_propietario, int por_cliente, string mes_hasta, int sac_inversionista) //Trae listado de liquidaciones
        {
            List<liquidaciones> lst = new List<liquidaciones>();
            string Llama_PA = "EXEC Liquidacion_Carga_Lista_Liquidadas @id_usuario, @mes, @id_estado_arriendo, @id_estado_propietario, @por_cliente, @mes_hasta, @sac_inversionista";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@id_estado_arriendo", id_estado_arriendo);
                cmd.Parameters.AddWithValue("@id_estado_propietario", id_estado_propietario);
                cmd.Parameters.AddWithValue("@por_cliente", por_cliente);
                cmd.Parameters.AddWithValue("@mes_hasta", mes_hasta);
                cmd.Parameters.AddWithValue("@sac_inversionista", sac_inversionista);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new liquidaciones
                        {
                            id_liq = reader["id_liq"].ToString(),
                            id_pago = reader["id_pago"].ToString(),
                            //id_contrato = reader["id_contrato"].ToString(),
                            //id_prop_arriendo = reader["id_prop_arriendo"].ToString(),
                            mes = reader["mes"].ToString(),
                            rut_propietario = reader["rut_propietario"].ToString(),
                            //direccion = reader["direccion"].ToString(),
                            //num_depto = reader["num_depto"].ToString(),
                            propietario = reader["propietario"].ToString(),
                            monto = reader["monto"].ToString(),
                            //arriendo = reader["arriendo"].ToString(),
                            //estado_arriendo = reader["estado_arriendo"].ToString(),
                            //com_admin_por = reader["com_admin_por"].ToString(),
                            com_neta = reader["com_neta"].ToString(),
                            //com_neta_sf = reader["com_neta_sf"].ToString(),
                            com_iva = reader["com_iva"].ToString(),
                            total_com = reader["com_total"].ToString(),
                            //com_iva_sf = reader["com_iva_sf"].ToString(),
                            descuentos = reader["descuentos"].ToString(),
                            //descuentos_sf = reader["descuentos_sf"].ToString(),
                            a_pagar = reader["a_pagar"].ToString(),
                            g_file_factura = reader["g_file_factura"].ToString(),
                            g_file_liquidacion = reader["g_file_liquidacion"].ToString(),
                            mes_liq = reader["mes_liq"].ToString(),
                            sac_inversionista = reader["sac_inversionista"].ToString()
                            //a_pagar_sf = reader["a_pagar_sf"].ToString(),
                            //estado_pago = reader["estado_pago"].ToString(),
                            //ejecutivo = reader["ejecutivo"].ToString(),
                            //estado_factura = reader["estado_factura"].ToString(),
                            //mail = reader["mail"].ToString(),
                            //observacion = reader["observacion"].ToString(),
                            //g_file_propietario = reader["g_file_propietario"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static string Llama_Liquidacion_RELiquidar_Propietario_Mes(string mes, int rut, int id_usuario)
        {
            string res = "";
            string Llama_PA = "EXEC Liquidacion_RELiquidar_Propietario_Mes @mes, @rut, @id_usuario";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@rut", rut);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res = reader["estado"] + "|" + reader["mensaje"];
                    }
                }
                conn.Close();
            }
            return res;
        }

        public static List<ExcelLiquidaciones> Llama_Liquidacion_Genera_Excel_TF(int id_usuario, string mes)
        {
            List<ExcelLiquidaciones> lst = new List<ExcelLiquidaciones>();
            string Llama_PA = "EXEC Liquidacion_Genera_Excel_TF @id_usuario, @mes";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@mes", mes);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new ExcelLiquidaciones
                        {
                            mes = reader["mes"].ToString(),
                            cuenta_destino = reader["cuenta_destino"].ToString(),
                            banco_deposito = reader["banco_deposito"].ToString(),
                            rut_propietario = reader["rut_propietario"].ToString(),
                            propietario = reader["propietario"].ToString(),
                            pago = reader["pago"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static DataTable Llama_Liquidacion_Genera_Excel_TF_V2(int id_usuario, string mes)
        {
            DataTable dt = new DataTable();
            List<ExcelLiquidaciones> lst = new List<ExcelLiquidaciones>();
            string Llama_PA = "EXEC Liquidacion_Genera_Excel_TF @id_usuario, @mes";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@mes", mes);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                conn.Close();
            }
            return dt;
        }

        public static DataTable Llama_Liquidacion_Genera_Excel_Aprobaciones(int id_usuario, string fecha_desde, string fecha_hasta)
        {
            DataTable dt = new DataTable();
            List<ExcelLiquidaciones> lst = new List<ExcelLiquidaciones>();
            string Llama_PA = "EXEC Liquidacion_Genera_Excel_Aprobaciones @id_usuario, @mes, @mes_hasta";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@mes", fecha_desde);
                cmd.Parameters.AddWithValue("@mes_hasta", fecha_hasta);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                conn.Close();
            }
            return dt;
        }

        public static DataTable Llama_Liquidacion_Genera_Excel_Liquidaciones(int id_usuario, string fecha_desde, string fecha_hasta)
        {
            DataTable dt = new DataTable();
            List<ExcelLiquidaciones> lst = new List<ExcelLiquidaciones>();
            string Llama_PA = "EXEC Liquidacion_Genera_Excel_Liquidaciones @id_usuario, @mes, @mes_hasta";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@mes", fecha_desde);
                cmd.Parameters.AddWithValue("@mes_hasta", fecha_hasta);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                conn.Close();
            }
            return dt;
        }

        public static DataTable Llama_Liquidacion_PDF_Header(int id_usuario, int id_liq, int rut, string fecha, int proceso)
        {

            SqlDataAdapter adp = new SqlDataAdapter("EXEC Liquidacion_PDF_Header " + id_usuario.ToString() + "," + id_liq.ToString() + " ," + rut.ToString() + ",'" + fecha + "', " + proceso.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable Llama_Liquidacion_PDF_Arriendos_Por_Propietario(int id_usuario, int id_liq, int rut, string fecha, int proceso)
        {
            SqlDataAdapter adp = new SqlDataAdapter("EXEC Liquidacion_PDF_Arriendos_Por_Propietario " + id_usuario.ToString() + "," + id_liq.ToString() + "," + rut.ToString() + ",'" + fecha + "', " + proceso.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable Llama_Liquidacion_PDF_Arriendos_Por_Propietario_Administracion(int id_usuario, int id_liq, int rut, string fecha, int proceso)
        {
            SqlDataAdapter adp = new SqlDataAdapter("EXEC Liquidacion_PDF_Arriendos_Por_Propietario_Administracion " + id_usuario.ToString() + "," + id_liq.ToString() + "," + rut.ToString() + ",'" + fecha + "', " + proceso.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable Llama_Liquidacion_PDF_Arriendos_Por_Propietario_Colocaciones(int id_usuario, int id_liq, int rut, string fecha, int proceso)
        {
            SqlDataAdapter adp = new SqlDataAdapter("EXEC Liquidacion_PDF_Arriendos_Por_Propietario_Colocaciones " + id_usuario.ToString() + "," + id_liq.ToString() + "," + rut.ToString() + ",'" + fecha + "', " + proceso.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable Llama_Liquidacion_PDF_Descuentos_Por_Propietario(int id_usuario, int id_liq, int rut, string fecha, int proceso)
        {
            SqlDataAdapter adp = new SqlDataAdapter("EXEC Liquidacion_PDF_Descuentos_Por_Propietario " + id_usuario.ToString() + "," + id_liq.ToString() + "," + rut.ToString() + ", '" + fecha + "', " + proceso.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable Llama_Liquidacion_PDF_Descuentos_Por_Propietario_Totales(int id_usuario, int id_liq, int rut, string fecha, int proceso)
        {
            SqlDataAdapter adp = new SqlDataAdapter("EXEC Liquidacion_PDF_Arriendos_Por_Propietario_Totales " + id_usuario.ToString() + "," + id_liq.ToString() + "," + rut.ToString() + ", '" + fecha + "', " + proceso.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable Llama_Liquidacion_PDF_Propiedades_No_Liquidadas(int id_usuario, int id_liq, int rut, string fecha, int proceso)
        {
            SqlDataAdapter adp = new SqlDataAdapter("EXEC Liquidacion_PDF_Arriendos_Por_Propietario_No_Liquidados " + id_usuario.ToString() + "," + id_liq.ToString() + "," + rut.ToString() + ", '" + fecha + "', " + proceso.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable Llama_Liquidacion_PDF_Propiedades_Observaciones(int id_usuario, int id_liq, int rut, string fecha, int proceso)
        {
            SqlDataAdapter adp = new SqlDataAdapter("EXEC Liquidacion_PDF_Propiedades_Observaciones " + id_usuario.ToString() + "," + id_liq.ToString() + "," + rut.ToString() + ", '" + fecha + "', " + proceso.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }


        public static List<liquidaciones> Llama_Liquidacion_Observacion_Carga(int id_pago, int id_usuario)
        {
            List<liquidaciones> lst = new List<liquidaciones>();
            string Llama_PA = "EXEC Liquidacion_Observacion_Carga @id_pago, @id_usuario";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new liquidaciones
                        {

                            id_pago = reader["id_pago"].ToString(),
                            id_contrato = reader["id_contrato"].ToString(),
                            id_prop_arriendo = reader["id_prop_arriendo"].ToString(),
                            periodo = reader["periodo"].ToString(),
                            concepto = reader["concepto"].ToString(),
                            propietario = reader["propietario"].ToString(),
                            direccion = reader["direccion"].ToString(),
                            num_depto = reader["num_depto"].ToString(),
                            observacion = reader["observacion"].ToString(),
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static string Llama_Liquidacion_Observacion_Actualiza(int id_pago, string observacion, int id_usuario)
        {
            string retorno = "";
            string Llama_PA = "exec Liquidacion_Observacion_Actualiza @id_pago, @observacion, @id_usuario";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retorno = reader["estado"].ToString() + "|" + reader["mensaje"].ToString() + "|" + reader["id_cuota"].ToString();
                    }
                }
                conn.Close();
            }
            return retorno;
        }

        public static string Llama_Liquidacion_Factura_Adjuntar(int id_liq, string g_file, int id_usuario)
        {
            string retorno = "";
            string Llama_PA = "exec Liquidacion_Factura_Adjuntar @id_liq, @g_file, @id_usuario";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_liq", id_liq);
                cmd.Parameters.AddWithValue("@g_file", g_file);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retorno = reader["estado"].ToString() + "|" + reader["mensaje"].ToString() + "|" + reader["id_liq"].ToString();
                    }
                }
                conn.Close();
            }
            return retorno;
        }

        public static string Llama_liquidacion_Factura_Eliminar(int id_liq, int id_usuario)
        {
            string retorno = "";
            string Llama_PA = "exec liquidacion_Factura_Eliminar @id_liq, @id_usuario";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_liq", id_liq);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retorno = reader["estado"].ToString() + "|" + reader["mensaje"].ToString() + "|" + reader["id_cuota"].ToString();
                    }
                }
                conn.Close();
            }
            return retorno;
        }

        public static void Llama_Liquidacion_Liquida_Arriendos_Propietario(int rut_propietario, string periodo, string file,int IdUsuario)
        {
            string Llama_PA = "exec Liquidacion_Liquida_Arriendos_Propietario @rut_propietario, @periodo, @file,@id_usu ";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@rut_propietario", rut_propietario);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cmd.Parameters.AddWithValue("@file", file);
                cmd.Parameters.AddWithValue("@id_usu", IdUsuario);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        //public static string Llama_Liquidacion_Archivo_Adjuntar(int id_usuario, int id_pago, string g_file)
        //{
        //    string retorno = "";
        //    string Llama_PA = "exec Liquidacion_Archivo_Adjuntar @id_pago, @g_file, @id_usuario";
        //    using (SqlConnection conn = new SqlConnection(connCorretaje))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(Llama_PA, conn);
        //        cmd.Parameters.AddWithValue("@id_pago", id_pago);
        //        cmd.Parameters.AddWithValue("@g_file", g_file);
        //        cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                retorno = reader["estado"].ToString() + "|" + reader["mensaje"].ToString() + "|" + reader["id_cuota"].ToString();
        //            }
        //        }
        //        conn.Close();
        //    }
        //    return retorno;
        //}

        //public static string Llama_liquidacion_Archivo_Eliminar(int id_pago, int id_usuario)
        //{
        //    string retorno = "";
        //    string Llama_PA = "exec liquidacion_Archivo_Eliminar @id_pago, @id_usuario";
        //    using (SqlConnection conn = new SqlConnection(connCorretaje))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(Llama_PA, conn);
        //        cmd.Parameters.AddWithValue("@id_pago", id_pago);
        //        cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                retorno = reader["estado"].ToString() + "|" + reader["mensaje"].ToString() + "|" + reader["id_cuota"].ToString();
        //            }
        //        }
        //        conn.Close();
        //    }
        //    return retorno;
        //}

        public static string Llama_Liquidacion_CambiarEstado_Cuota(int id_pago, int estado, DateTime fecha, int b_pago_contra_garantia, int tf_id_banco, string tf_num, int usuario, string observacion, string fecha_proceso)
        {
            string retorno = "";
            string Llama_PA = "exec Liquidacion_CambiarEstado_Cuota @id_pago, @estado_propietario, @fecha, @b_pago_contra_garantia, @tf_id_banco, @tf_num, @usuario, @observacion, @fecha_proceso";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                cmd.Parameters.AddWithValue("@estado_propietario", estado);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@b_pago_contra_garantia", b_pago_contra_garantia);
                cmd.Parameters.AddWithValue("@tf_id_banco", tf_id_banco);
                cmd.Parameters.AddWithValue("@tf_num", tf_num);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@fecha_proceso", fecha_proceso);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retorno = reader["estado"].ToString() + "|" + reader["mensaje"].ToString() + "|" + reader["id_pago"].ToString() + "|" + reader["estado_anterior"].ToString() + "|" + reader["nuevo_estado"].ToString() + "|" + reader["nombre_ejecutivo"] + "|" + reader["monto"];
                    }
                }
                conn.Close();
            }
            return retorno;
        }

        public static void Llama_Liquidacion_Marca_PagoContraGarantia(int id_pago, int b_pago_contra_garantia, int usuario)
        {
            string Llama_PA = "exec Liquidacion_Marca_PagoContraGarantia @id_pago, @b_pago_contra_garantia, @usuario";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                cmd.Parameters.AddWithValue("@b_pago_contra_garantia", b_pago_contra_garantia);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void Llama_Liquidacion_Marca_PagoSeguroArriendo(int id_pago, int b_pago_seguro_arriendo, int usuario)
        {
            string Llama_PA = "exec Liquidacion_Marca_PagoSeguroArriendo @id_pago, @b_pago_seguro_arriendo, @usuario";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                cmd.Parameters.AddWithValue("@b_pago_seguro_arriendo", b_pago_seguro_arriendo);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static List<ResultadoEnvioMails> Llama_Liquidacion_Enviar_Por_Mail(int usuario, string m_g_file_liquidacion, int proceso)
        {
            var retorno = new List<ResultadoEnvioMails>();
            string LLama_PA = "Liquidacion_Enviar_Por_Mail";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(LLama_PA, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@m_g_file_liquidacion", m_g_file_liquidacion);
                cmd.Parameters.AddWithValue("@proceso", proceso);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retorno.Add(new ResultadoEnvioMails
                        {
                            estado = reader["estado"].ToString(),
                            mensaje = reader["mensaje"].ToString(),
                            rut = reader["rut"].ToString(),
                            fecha = reader["fecha"].ToString(),
                            nombre = reader["nombre"].ToString(),
                            archivo = reader["archivo"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return retorno;
        }

        public static List<ResultadoEnvioMails> Llama_Liquidacion_Factura_Enviar_Por_Mail(int usuario, string m_rut, string m_mes, int proceso)
        {
            var retorno = new List<ResultadoEnvioMails>();
            string LLama_PA = "Liquidacion_Factura_Enviar_Por_Mail";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(LLama_PA, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@m_rut", m_rut);
                cmd.Parameters.AddWithValue("@m_mes", m_mes);
                cmd.Parameters.AddWithValue("@proceso", proceso);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retorno.Add(new ResultadoEnvioMails
                        {
                            estado = reader["estado"].ToString(),
                            mensaje = reader["mensaje"].ToString(),
                            rut = reader["rut"].ToString(),
                            fecha = reader["fecha"].ToString(),
                            nombre = reader["nombre"].ToString(),
                            archivo = reader["archivo"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return retorno;
        }

        public static List<Aprobaciones_Comparativo> Llama_Liquidacion_Genera_Excel_Aprobaciones_Comparativo(int id_usuario, string mes, int id_estado_arriendo, int id_estado_propietario
            , string mes_hasta, int sac_inversionista, int proceso)
        {
            List<Aprobaciones_Comparativo> lst = new List<Aprobaciones_Comparativo>();
            string Llama_PA = "EXEC Liquidacion_Genera_Excel_Aprobaciones_Comparativo @id_usuario, @mes, @id_estado_arriendo, @id_estado_propietario, @mes_hasta, @sac_inversionista, @proceso";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@id_estado_arriendo", id_estado_arriendo);
                cmd.Parameters.AddWithValue("@id_estado_propietario", id_estado_propietario);
                cmd.Parameters.AddWithValue("@mes_hasta", mes_hasta);
                cmd.Parameters.AddWithValue("@sac_inversionista", sac_inversionista);
                cmd.Parameters.AddWithValue("@proceso", proceso);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new Aprobaciones_Comparativo
                        {
                            Dif = reader["Dif?"].ToString(),
                            id_pago = reader["id_pago"].ToString(),
                            contrato_act = reader["contrato_act"].ToString(),
                            contrato_ant = reader["contrato_ant"].ToString(),
                            estado_pago = reader["estado_pago"].ToString(),
                            arriendo_act = reader["arriendo_act"].ToString(),
                            arriendo_ant = reader["arriendo_ant"].ToString(),
                            com_act = reader["com_act"].ToString(),
                            com_ant = reader["com_ant"].ToString(),
                            descuento_act = reader["descuento_act"].ToString(),
                            descuento_ant = reader["descuento_ant"].ToString(),
                            a_pagar_act = reader["a_pagar_act"].ToString(),
                            a_pagar_ant = reader["a_pagar_ant"].ToString(),
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<BeneficiosPropiedad> Cargar_Beneficios_Propiedad(int proc)
        {
            List<BeneficiosPropiedad> lst = new List<BeneficiosPropiedad>();
            string Llama_PA = "Carga_Lista_Beneficios_Propiedad";
            using (SqlConnection conn = new SqlConnection(GESTIONPROD))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@proc", proc);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new BeneficiosPropiedad
                        {
                            c_item = reader["c_item"].ToString(),
                            g_glosa1 = reader["g_glosa1"].ToString(),
                            n_valor1 = reader["n_valor1"].ToString(),
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<BeneficiosPropiedad> Llama_Beneficios_Propiedad_Posee(int proc, int id_prop, int id_contrato)
        {
            //var response = new BeneficiosPropiedad();
            List<BeneficiosPropiedad> lst = new List<BeneficiosPropiedad>();
            string Llama_PA = "Carga_Lista_Beneficios_Propiedad";
            using (SqlConnection conn = new SqlConnection(GESTIONPROD))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@proc", proc);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new BeneficiosPropiedad
                        {
                            id_ben = reader["id_ben"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static bool Llama_Actualiza_Beneficios_Propiedad(int IdUsuario, int id_prop, string chk_seleccionados, string chk_NO_seleccionados, int id_contrato)
        {
            string Llama_PA = "Actualiza_Beneficios_Propiedad";
            using (SqlConnection conn = new SqlConnection(GESTIONPROD))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", IdUsuario);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);
                cmd.Parameters.AddWithValue("@ids_ben", chk_seleccionados);
                cmd.Parameters.AddWithValue("@ids_NO_ben", chk_NO_seleccionados);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }
        public static bool Llama_Mail_Envia_Alerta_Cambio_Estado_Cuota(int id_pago, int estado_actual, int estado_anterior, int usuario, string observacion
            , string fecha, string para, string nombre_destinatario, int proceso)
        {
            string Llama_PA = "EXEC Mail_Envia_Alerta_Cambio_Estado_Cuota @id_pago, @estado_actual, @estado_anterior, @usuario, @observacion, @fecha, @para, @nombre_destinatario, @proceso";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                cmd.Parameters.AddWithValue("@estado_actual", estado_actual);
                cmd.Parameters.AddWithValue("@estado_anterior", estado_anterior);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@para", para);
                cmd.Parameters.AddWithValue("@nombre_destinatario", nombre_destinatario);
                cmd.Parameters.AddWithValue("@proceso", proceso);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }

        //public static bool Llama_Mail_Envia_Alerta_Atencion_Gerencia(string ids_pago, string mensaje, int tipo_correo)
        //{
        //    string Llama_PA = "EXEC Mail_Envia_Alerta_Atencion_Gerencia @ids_pago, @mensaje, @tipo_correo";
        //    using (SqlConnection conn = new SqlConnection(connCorretaje))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(Llama_PA, conn);
        //        cmd.Parameters.AddWithValue("@ids_pago", ids_pago);
        //        cmd.Parameters.AddWithValue("@mensaje", mensaje);
        //        cmd.Parameters.AddWithValue("@tipo_correo", tipo_correo);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        conn.Close();
        //    }
        //    return true;
        //}

        public static bool Llama_Mail_Envia_Alerta_Atencion_Gerencia_Nuevo(int tipo_correo, string fecha, string periodo)
        {
            string Llama_PA = "EXEC Mail_Envia_Alerta_Atencion_Gerencia_Nuevo @tipo_correo,@fecha,@periodo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@tipo_correo", tipo_correo);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }

        public static bool Llama_Mail_Envia_Alerta_Atencion_Finanzas(int tipo_correo, string fecha, string periodo)
        {
            string Llama_PA = "EXEC Mail_Envia_Alerta_Atencion_Finanzas @tipo_correo,@fecha,@periodo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@tipo_correo", tipo_correo);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }

        public static List<observacion_pago> Llama_Pagos_Actualiza_Observacion_Carga(int proc, int id_pago, int id_usuario, string observacion)
        {
            List<observacion_pago> lst = new List<observacion_pago>();
            string Llama_PA = "EXEC Pagos_Actualiza_Observacion @proc, @id_pago, @id_usuario,@observacion";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@proc", proc);
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new observacion_pago
                        {
                            id_pago = reader["id_pago"].ToString(),
                            id_usuario = reader["id_usuario"].ToString(),
                            observacion = reader["observacion"].ToString(),
                            fecha_obs = reader["fecha_obs"].ToString(),
                            nom_usuario = reader["nom_usuario"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static string Llama_Pagos_Actualiza_Observacion_Graba(int proc, int id_pago, int id_usuario, string observacion)
        {
            //List<retorno_obs> lst = new List<retorno_obs>();
            string Llama_PA = "EXEC Pagos_Actualiza_Observacion @proc, @id_pago, @id_usuario,@observacion";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@proc", proc);
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.ExecuteNonQuery();
                //SqlDataReader reader = cmd.ExecuteReader();
                //if (reader.HasRows)
                //{
                //    while (reader.Read())
                //    {
                //        lst.Add(new retorno_obs
                //        {
                //            estado = reader["estado"].ToString(),
                //            mensaje = reader["mensaje"].ToString(),
                //            id_cuota = reader["id_cuota"].ToString()
                //        });
                //    }
                //}
                conn.Close();
            }
            //return lst;
            return null;
        }
        public static List<HistorialEstadoPago> Llama_HistorialEstados(int id_usuario, string id_pago)
        {
            var resp = new List<HistorialEstadoPago>();

            string Llama_PA = "EXEC Liquidacion_Carga_Eventos @id_pago";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_pago", id_pago);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resp.Add(new HistorialEstadoPago
                        {
                            id_pago = reader["id_pago"].ToString(),
                            usuario = reader["usuario"].ToString(),
                            fecha = reader["fecha"].ToString(),
                            fecha_sin_formato = reader["fecha_sin_formato"].ToString(),
                            estado_anterior = reader["estado_anterior"].ToString(),
                            estado_nuevo = reader["estado_nuevo"].ToString()
                        });
                    }
                }
                conn.Close();
            }

            return resp;
        }
        public static List<perfilamiento> Llama_Perfilamiento_Filtros_Default_Front(int id_usuario, string modulo, string vista)
        {
            var resp = new List<perfilamiento>();

            string Llama_PA = "EXEC Perfilamiento_Filtros_Default_front @id_usu,@modulo,@vista";
            //string Llama_PA = "EXEC Perfilamiento_Filtros_Default @id_usu,@modulo,@vista,'0','0',0";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@modulo", modulo);
                cmd.Parameters.AddWithValue("@vista", vista);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resp.Add(new perfilamiento
                        {
                            g_estado_arriendo = reader["g_estado_arriendo"].ToString(),
                            g_estado_propietario = reader["g_estado_propietario"].ToString(),
                            sac_inversionista = reader["sac_inversionista"].ToString(),
                        });
                    }
                }
                conn.Close();
            }

            return resp;
        }
        public static List<verificador_cartera> Llama_Liquidacion_Verificador_Cartera(int id_usu,string id_propiedad, string fecha_desde, string fecha_hasta)
        {
            List<verificador_cartera> lst = new List<verificador_cartera>();
            string Llama_PA = "EXEC Verificador_Cartera_Carga_Lista @id_propiedad, @fecha_desde,@fecha_hasta, @id_usu,@tipo_tabla";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_propiedad", id_propiedad);
                cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                cmd.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@tipo_tabla", 1);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new verificador_cartera
                        {
                            direccion = reader["direccion"].ToString(),
                            num_depto = reader["num_depto"].ToString(),
                            id_pago = reader["id_pago"].ToString(),
                            registros_cobrados = reader["registros_cobrados"].ToString(),
                            registros_pendientes = reader["registros_pendientes"].ToString(),
                            registros_totales = reader["registros_totales"].ToString(),
                            estado_propiedad = reader["estado_propiedad"].ToString(),
                            num_contrato = reader["num_contrato"].ToString(),
                            estado_pago = reader["estado_pago"].ToString(),
                            periodo = reader["periodo"].ToString(),
                            count_prop = reader["count_prop"].ToString(),
                            observacion = reader["observacion"].ToString(),
                            nombre_propietario = reader["nombre_propietario"].ToString(),
                            id_propiedad = reader["id_propiedad"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static string Llama_Liquidacion_Verificador_Cartera_Obs(int id_usu, string id_propiedad, string fecha_desde, string fecha_hasta)
        {
            string observacion = "";
            string Llama_PA = "EXEC Verificador_Cartera_Carga_Lista @id_propiedad, @fecha_desde,@fecha_hasta, @id_usu, @tipo_tabla";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_propiedad", id_propiedad);
                cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                cmd.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@tipo_tabla", 2);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        observacion = reader["observacion"].ToString();
                       
                    }
                }
                conn.Close();
            }
            return observacion;
        }
        public static List<KPIInversionista> KPI_Pago_Inversionista_Excel_Planilla(int id_usu, DateTime mes, DateTime mes_hasta)
        {
            List<KPIInversionista> Carga_Lista_KPI = new List<KPIInversionista>();
            string comand_sp = "exec KPI_Pago_Inversionista_Excel_Planilla @id_usu, @mes, @mes_hasta";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(comand_sp, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@mes_hasta", mes_hasta);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //System.Diagnostics.Debug.WriteLine(reader["nombre"].ToString());

                        Carga_Lista_KPI.Add(new KPIInversionista
                        {
                            column1 = reader["column1"].ToString(),
                            column2 = reader["column2"].ToString(),
                            column3 = reader["column3"].ToString()

                        });
                    }
                }
                conn.Close();
            }
            return Carga_Lista_KPI;
        }
        public static List<KPIInversionista2> KPI_Pago_Inversionista_Excel_Planilla2(int id_usu, DateTime mes, DateTime mes_hasta)
        {
            List<KPIInversionista2> Carga_Lista_KPI2 = new List<KPIInversionista2>();
            string comand_sp = "exec Liquidacion_Genera_Excel_Aprobaciones_Estado @id_usu, @FechaPagoIni, @id_estado_arriendo, @id_estado_propietario,  @FechaPagoFin,  @sac_inversionista";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(comand_sp, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@FechaPagoIni", mes);
                cmd.Parameters.AddWithValue("@id_estado_arriendo", 0);
                cmd.Parameters.AddWithValue("@id_estado_propietario", 0);
                cmd.Parameters.AddWithValue("@FechaPagoFin", mes_hasta);
                cmd.Parameters.AddWithValue("@sac_inversionista", 0);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //System.Diagnostics.Debug.WriteLine(reader["nombre"].ToString());

                        Carga_Lista_KPI2.Add(new KPIInversionista2
                        {
                            id_pago = reader["id_pago"].ToString(),
                            id_contrato = reader["id_contrato"].ToString(),
                            concepto = reader["concepto"].ToString(),
                            rut_propietario = reader["rut_propietario"].ToString(),
                            propietario = reader["propietario"].ToString(),
                            direccion = reader["direccion"].ToString(),
                            num_depto = reader["num_depto"].ToString(),
                            forma_pago = reader["forma_pago"].ToString(),
                            numero_cheque = reader["numero_cheque"].ToString(),
                            id_prop_arriendo = reader["id_prop_arriendo"].ToString(),
                            mes = reader["mes"].ToString(),
                            arriendo = reader["arriendo"].ToString(),
                            estado_arriendo = reader["estado_arriendo"].ToString(),
                            com_admin_por = reader["com_admin_por"].ToString(),
                            com_neta = reader["com_neta"].ToString(),
                            com_iva = reader["com_iva"].ToString(),
                            com_total = reader["com_total"].ToString(),
                            descuentos = reader["descuentos"].ToString(),
                            mes_gracia = reader["mes_gracia"].ToString(),
                            a_pagar = reader["a_pagar"].ToString(),
                            estado_pago = reader["estado_pago"].ToString(),
                            fecha_pago = reader["fecha_pago"].ToString(),
                            ejecutivo = reader["ejecutivo"].ToString(),
                            kam_inversionista = reader["kam_inversionista"].ToString(),
                            id_kam_inversionista = reader["id_kam_inversionista"].ToString(),
                            estado_factura = reader["estado_factura"].ToString(),
                            mail = reader["mail"].ToString(),
                            observacion = reader["observacion"].ToString(),
                            pago_contra_garantia = reader["pago_contra_garantia"].ToString()

                        });
                    }
                }
                conn.Close();
            }
            return Carga_Lista_KPI2;
        }
    }
}