using corretaje.Clases;
using corretaje.Helpers;
using Lecaros.Common.Sign.BusinessObjects;
using Lecaros.Common.Sign.BusinessObjects.SignEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using static corretaje.Helpers.Constant;

namespace corretaje.Models
{
    public class PropiedadesModels
    {
        private static readonly string connCorretaje = Environment.GetEnvironmentVariable("CORRETAJE", EnvironmentVariableTarget.Machine);
        private static readonly string GESTIONPROD = Environment.GetEnvironmentVariable("GESTIONPROD", EnvironmentVariableTarget.Machine);
        private static readonly int sqlTimeout = Convert.ToInt32(Environment.GetEnvironmentVariable("SQLTIMEOUT", EnvironmentVariableTarget.Machine));

        public static List<propiedad> TraePropiedad(int id_usuario, int id_propiedad, string id_contrato = "0") //Trae una propiedad
        {
            List<propiedad> lst = new List<propiedad>();
            string Llama_PA = "Propiedades_Carga_Propiedad";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@id_prop_arriendo", id_propiedad);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    lst = reader.ToList<propiedad>();
                }
            }
            if (lst.Count > 0)
            {
                lst[0].id_contrato = id_contrato;
            }
            return lst;
        }

        public static List<propiedad> TraePropiedades(int id_usuario, int id_pry, int c_tipologia, int n_mes_dis, int id_ejecutivo, int c_edo, string n_ven_con, int sac_inversionista, int reparos) //Trae una propiedad
        {
            List<propiedad> lst = new List<propiedad>();
            string Llama_PA = "Propiedades_Carga_Lista_V2";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@id_pry", id_pry);
                cmd.Parameters.AddWithValue("@c_tipologia", c_tipologia);
                cmd.Parameters.AddWithValue("@n_mes_dis", n_mes_dis);
                cmd.Parameters.AddWithValue("@id_ejecutivo", id_ejecutivo);
                cmd.Parameters.AddWithValue("@c_edo", c_edo);
                cmd.Parameters.AddWithValue("@n_ven_con", n_ven_con);
                cmd.Parameters.AddWithValue("@sac_inversionista", sac_inversionista);
                cmd.Parameters.AddWithValue("@reparos", reparos);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    lst = reader.ToList<propiedad>();
                }
            }
            return lst;
        }

        public static List<PropiedadGrilla> TraePropiedades_sel_mul(int id_usuario, string id_pry, string c_tipologia, string n_mes_dis, string id_ejecutivo, string c_edo, string n_ven_con, string sac_inversionista, string reparos, string enProcesoFirma, string enProcesoFiniquito, string color_filtro, string comuna, string b_contabilizado, string verReservados, string verBloqueados, string b_soc_unipersonal, string b_family_office, string b_amoblados, string tipo_arriendo, string inversionista, string inicio_contrato, string porc_com_adm) //Trae una propiedad
        {
            List<PropiedadGrilla> lst = new List<PropiedadGrilla>();
            string Llama_PA = "Propiedades_Carga_Lista_V2";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@id_pry", id_pry);
                cmd.Parameters.AddWithValue("@c_tipologia", c_tipologia);
                cmd.Parameters.AddWithValue("@n_mes_dis", n_mes_dis);
                cmd.Parameters.AddWithValue("@id_ejecutivo", id_ejecutivo);
                cmd.Parameters.AddWithValue("@c_edo", c_edo);
                cmd.Parameters.AddWithValue("@n_ven_con", n_ven_con);
                cmd.Parameters.AddWithValue("@sac_inversionista", sac_inversionista);
                cmd.Parameters.AddWithValue("@reparos", reparos);
                cmd.Parameters.AddWithValue("@enProcesoFirma", enProcesoFirma);
                cmd.Parameters.AddWithValue("@color_filtro", color_filtro);
                cmd.Parameters.AddWithValue("@comuna", comuna);
                cmd.Parameters.AddWithValue("@b_contabilizado", b_contabilizado);
                cmd.Parameters.AddWithValue("@enProcesoFiniquito", enProcesoFiniquito);
                cmd.Parameters.AddWithValue("@verReservados", verReservados);
                cmd.Parameters.AddWithValue("@verBloqueadas", verBloqueados);
                cmd.Parameters.AddWithValue("@b_soc_unipersonal", b_soc_unipersonal);
                cmd.Parameters.AddWithValue("@b_family_office", b_family_office);
                cmd.Parameters.AddWithValue("@b_amoblados", b_amoblados);
                cmd.Parameters.AddWithValue("@tipo_arriendo", tipo_arriendo);
                cmd.Parameters.AddWithValue("@rut_propietario", inversionista);
                cmd.Parameters.AddWithValue("@inicio_contrato", inicio_contrato);
                cmd.Parameters.AddWithValue("@porc_com_adm", porc_com_adm);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    lst = reader.ToList<PropiedadGrilla>();
                }
            }
            return lst;
        }

        public static List<propiedad> ActualizaPropiedad(int id_usu, int id_prop_arriendo, string direccion, string numero, int comuna,
            int id_metro, string orientacion, int tipo_bien, int id_pry, string g_pry, int id_inmob, string g_inmob, int id_ejecutivo,
            string f_recepcion, string rol_propiedad, string num_depto, string num_estacionam, string num_bodega, int tipologia,
            float superficie, string observacion, int meses_gracia, int banco, float cae, float tasa, float dividendo, string fecha_escritura,
            int plazo, float seguro_muerte, float seguro_incendio, float seguro_sismo, string f_1er_dividendo, string luz, string agua, string gas, string f_ent_inmob,
            string f_ent_eje, int dfl2, float? n_sup_m2_utiles, float? n_sup_m2_terraza, string f_postventa, float seguro_incendio_sismo, int compra_contado, int id_formato,
            float porcentaje_comision_adm, float com_adm_2do, float com_corretaje, int ci_meses_gracia, string ci_f_1er_dividendo,
            int b_pago_saldos, string f_pago_saldos, int b_pago_ajustes, string f_pago_ajustes, int b_pago_fondo, string f_pago_fondo, int b_finiquito, string f_finiquito, int b_otros,
            string g_otros, string f_otros, int b_otros2, string g_otros2, string f_otros2, string ggcc_nombre, string ggcc_cta_deposito, int ggcc_banco, float ch_mto_escritura,
            float ch_mto_financiamiento, float ch_por_financiamiento, string ggcc_rut, float ggcc_monto, string ci_fecha_inicio_adm, int b_nueva, string ddlFechaDisponible, string link_recorrido_virtual,
            string rol_estacionam, string rol_bodega, string num_estacionam_2, string num_bodega_2, string rol_estacionam_2, string rol_bodega_2, float v_uf_estacionam, float v_uf_bodega, float v_uf_estacionam_2, float v_uf_bodega_2, int n_piso, int b_soc_unipersonal, string f_desde_soc_unipersonal, string g_cuenta_deposito_soc_unipersonal, int id_banco_deposito_soc_unipersonal, string g_giro_soc_unipersonal, int id_plan, float com_adm_vigente, string ci_f_desde_com_vigente) //Actualiza propiedad
        {
            List<propiedad> lst = new List<propiedad>();
            string Llama_PA = "Propiedades_Actualiza_Propiedad";

            if (n_sup_m2_utiles == null)//ADD CA 27-05-2018
            {
                n_sup_m2_utiles = 0;
            }

            if (n_sup_m2_terraza == null)//ADD CA 27-05-2018
            {
                n_sup_m2_terraza = 0;
            }
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_prop_arriendo", id_prop_arriendo);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@comuna", comuna);
                cmd.Parameters.AddWithValue("@id_metro", id_metro);
                cmd.Parameters.AddWithValue("@orientacion", orientacion);
                cmd.Parameters.AddWithValue("@tipo_bien", tipo_bien);
                cmd.Parameters.AddWithValue("@id_pry", id_pry);
                cmd.Parameters.AddWithValue("@g_pry", g_pry);
                cmd.Parameters.AddWithValue("@id_inmob", id_inmob);
                cmd.Parameters.AddWithValue("@g_inmob", g_inmob);
                cmd.Parameters.AddWithValue("@id_ejecutivo", id_ejecutivo);
                cmd.Parameters.AddWithValue("@f_recepcion", Convert.ToDateTime(f_recepcion));
                cmd.Parameters.AddWithValue("@rol_propiedad", rol_propiedad);
                cmd.Parameters.AddWithValue("@num_depto", num_depto);
                cmd.Parameters.AddWithValue("@num_estacionam", num_estacionam);
                cmd.Parameters.AddWithValue("@num_bodega", num_bodega);
                cmd.Parameters.AddWithValue("@tipologia", tipologia);
                cmd.Parameters.AddWithValue("@superficie", superficie);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@meses_gracia", meses_gracia);
                cmd.Parameters.AddWithValue("@banco", banco);
                cmd.Parameters.AddWithValue("@cae", cae);
                cmd.Parameters.AddWithValue("@tasa", tasa);
                cmd.Parameters.AddWithValue("@dividendo", dividendo);
                cmd.Parameters.AddWithValue("@fecha_escritura", Convert.ToDateTime(fecha_escritura));
                cmd.Parameters.AddWithValue("@plazo", plazo);
                cmd.Parameters.AddWithValue("@seguro_muerte", seguro_muerte);
                cmd.Parameters.AddWithValue("@seguro_incendio", seguro_incendio);
                cmd.Parameters.AddWithValue("@seguro_sismo", seguro_sismo);
                cmd.Parameters.AddWithValue("@seguro_incendio_sismo", seguro_incendio_sismo);
                if (string.IsNullOrEmpty(f_1er_dividendo))
                    cmd.Parameters.AddWithValue("@f_1er_dividendo", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@f_1er_dividendo", Convert.ToDateTime(f_1er_dividendo));

                cmd.Parameters.AddWithValue("@luz", luz);
                cmd.Parameters.AddWithValue("@agua", agua);
                cmd.Parameters.AddWithValue("@gas", gas);
                cmd.Parameters.AddWithValue("@chk_contado", compra_contado);
                cmd.Parameters.AddWithValue("@f_ent_inmob", Convert.ToDateTime(f_ent_inmob));
                cmd.Parameters.AddWithValue("@f_postventa", Convert.ToDateTime(f_postventa));
                cmd.Parameters.AddWithValue("@f_ent_eje", Convert.ToDateTime(f_ent_eje));
                cmd.Parameters.AddWithValue("@b_dfl2", dfl2);
                cmd.Parameters.AddWithValue("@n_sup_m2_utiles", n_sup_m2_utiles);//ADD CA 27-05-2018
                cmd.Parameters.AddWithValue("@n_sup_m2_terraza", n_sup_m2_terraza);//ADD CA 27-05-2018
                cmd.Parameters.AddWithValue("@id_formato", id_formato);
                cmd.Parameters.AddWithValue("@com_adm", porcentaje_comision_adm);
                cmd.Parameters.AddWithValue("@com_adm_2do", com_adm_2do);
                cmd.Parameters.AddWithValue("@com_corretaje", com_corretaje);
                cmd.Parameters.AddWithValue("@ci_meses_gracia", ci_meses_gracia);
                cmd.Parameters.AddWithValue("@ci_f_1er_dividendo", Convert.ToDateTime(ci_f_1er_dividendo));

                cmd.Parameters.AddWithValue("@ei_chk_pago_saldos", b_pago_saldos);
                cmd.Parameters.AddWithValue("@ei_f_pago_saldos", Convert.ToDateTime(f_pago_saldos));
                cmd.Parameters.AddWithValue("@ei_chk_pago_ajustes", b_pago_ajustes);
                cmd.Parameters.AddWithValue("@ei_f_pago_ajustes", Convert.ToDateTime(f_pago_ajustes));
                cmd.Parameters.AddWithValue("@ei_chk_pago_fondo", b_pago_fondo);
                cmd.Parameters.AddWithValue("@ei_f_pago_fondo", Convert.ToDateTime(f_pago_fondo));
                cmd.Parameters.AddWithValue("@ei_chk_finiquito", b_finiquito);
                cmd.Parameters.AddWithValue("@ei_f_finiquito", Convert.ToDateTime(f_finiquito));
                cmd.Parameters.AddWithValue("@ei_chk_otros", b_otros);
                cmd.Parameters.AddWithValue("@ei_g_otros", g_otros);
                cmd.Parameters.AddWithValue("@ei_f_otros", Convert.ToDateTime(f_otros));
                cmd.Parameters.AddWithValue("@ei_chk_otros2", b_otros2);
                cmd.Parameters.AddWithValue("@ei_g_otros2", g_otros2);
                cmd.Parameters.AddWithValue("@ei_f_otros2", Convert.ToDateTime(f_otros2));

                cmd.Parameters.AddWithValue("@ggcc_nombre", ggcc_nombre);               // add 16-09-2019 CA
                cmd.Parameters.AddWithValue("@ggcc_cta_deposito", ggcc_cta_deposito);   // add 16-09-2019 CA
                cmd.Parameters.AddWithValue("@ggcc_banco", ggcc_banco);                 // add 16-09-2019 CA
                cmd.Parameters.AddWithValue("@ggcc_rut", ggcc_rut);                     // add 25-09-2019 CA

                cmd.Parameters.AddWithValue("@ch_mto_escritura", ch_mto_escritura);
                cmd.Parameters.AddWithValue("@ch_mto_financiamiento", ch_mto_financiamiento);
                cmd.Parameters.AddWithValue("@ch_por_financiamiento", ch_por_financiamiento);

                cmd.Parameters.AddWithValue("@ggcc_monto", ggcc_monto);                 // add 01-10-2019 CA
                if (string.IsNullOrEmpty(ci_fecha_inicio_adm))
                    cmd.Parameters.AddWithValue("@ci_fecha_inicio_adm", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ci_fecha_inicio_adm", Convert.ToDateTime(ci_fecha_inicio_adm));  // add 03-06-2020 IS
                cmd.Parameters.AddWithValue("@b_nueva", b_nueva);  // add 03-06-2020 IS
                if (string.IsNullOrEmpty(ddlFechaDisponible))
                    cmd.Parameters.AddWithValue("@f_fecha_disponible", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@f_fecha_disponible", Convert.ToDateTime(ddlFechaDisponible));  // add 03-06-2020 IS
                cmd.Parameters.AddWithValue("@link_recorrido_virtual", string.IsNullOrEmpty(link_recorrido_virtual) ? DBNull.Value : (object)link_recorrido_virtual);

                cmd.Parameters.AddWithValue("@rol_estacionam", rol_estacionam);
                cmd.Parameters.AddWithValue("@rol_bodega", rol_bodega);
                cmd.Parameters.AddWithValue("@num_estacionam_2", num_estacionam_2);
                cmd.Parameters.AddWithValue("@num_bodega_2", num_bodega_2);
                cmd.Parameters.AddWithValue("@rol_estacionam_2", rol_estacionam_2);
                cmd.Parameters.AddWithValue("@rol_bodega_2", rol_bodega_2);
                cmd.Parameters.AddWithValue("@v_uf_estacionam", v_uf_estacionam);
                cmd.Parameters.AddWithValue("@v_uf_bodega", v_uf_bodega);
                cmd.Parameters.AddWithValue("@v_uf_estacionam_2", v_uf_estacionam_2);
                cmd.Parameters.AddWithValue("@v_uf_bodega_2", v_uf_bodega_2);
                cmd.Parameters.AddWithValue("@n_piso", n_piso);

                cmd.Parameters.AddWithValue("@b_soc_unipersonal", b_soc_unipersonal);
                cmd.Parameters.AddWithValue("@f_desde_soc_unipersonal", f_desde_soc_unipersonal);
                cmd.Parameters.AddWithValue("@g_cuenta_deposito_soc_unipersonal", g_cuenta_deposito_soc_unipersonal);
                cmd.Parameters.AddWithValue("@id_banco_deposito_soc_unipersonal", id_banco_deposito_soc_unipersonal);
                cmd.Parameters.AddWithValue("@g_giro_soc_unipersonal", g_giro_soc_unipersonal);
                cmd.Parameters.AddWithValue("@id_plan", id_plan);
                cmd.Parameters.AddWithValue("@com_adm_vigente", com_adm_vigente);
                cmd.Parameters.AddWithValue("@ci_f_desde_com_vigente", ci_f_desde_com_vigente);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["estado"].ToString() == "false")
                        {
                            lst.Add(new propiedad
                            {
                                estado_pa = reader["estado"].ToString(),
                                mensaje_pa = reader["mensaje"].ToString()
                            });
                        }
                        else
                        {
                            lst.Add(new propiedad
                            {
                                estado_pa = reader["estado"].ToString(),
                                mensaje_pa = reader["mensaje"].ToString(),
                                id_estado = reader["id"].ToString()
                            });
                        }
                    }
                }
            }
            return lst;
        }

        public static bool ActualizaArriendo(int id_usu, int id_propiedad_arriendo, string inicio_contrato, string termino_contrato, string firma_contrato, int dia_pago,
            string fecha_renovacion, float valor_arriendo, float comision_corretaje, float valor_garantia, float gastos_notariales,
            float costo_dicom, float fraccion_mes, int forma_pago, float comision_administracion, int folio_contabilidad_1,
            int folio_contabilidad_2, int meses_gracias, string mes_fin_gracias, string observacion, float porcentaje_admin, float porcentaje_corretaje, float porcentaje_corretaje_prop
            , int folio_contabilidad_3, string f_acta_recepcion) //Actualiza datos de arriendo
        {
            string Llama_PA = "EXEC Propiedades_Actualiza_Arriendo @id_usu, @id_propiedad_arriendo, @inicio_contrato, @termino_contrato, @firma_contrato, @dia_pago, " +
                "@fecha_renovacion, @valor_arriendo, @comision_corretaje, @valor_garantia, @gastos_notariales, @costo_dicom, @fraccion_mes, @forma_pago, " +
                "@comision_administracion, @folio_contabilidad_1, @folio_contabilidad_2, @meses_gracias, @mes_fin_gracias, @observacion, @porcentaje_admin, " +
                "@porcentaje_corretaje, @porcentaje_corretaje_prop, @folio_contabilidad_3, @f_acta_recepcion";

            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_propiedad_arriendo", id_propiedad_arriendo);
                cmd.Parameters.AddWithValue("@inicio_contrato", inicio_contrato);
                cmd.Parameters.AddWithValue("@termino_contrato", termino_contrato);
                cmd.Parameters.AddWithValue("@firma_contrato", firma_contrato);
                cmd.Parameters.AddWithValue("@dia_pago", dia_pago);
                cmd.Parameters.AddWithValue("@fecha_renovacion", fecha_renovacion);
                cmd.Parameters.AddWithValue("@valor_arriendo", valor_arriendo);
                cmd.Parameters.AddWithValue("@comision_corretaje", comision_corretaje);
                cmd.Parameters.AddWithValue("@valor_garantia", valor_garantia);
                cmd.Parameters.AddWithValue("@gastos_notariales", gastos_notariales);
                cmd.Parameters.AddWithValue("@costo_dicom", costo_dicom);
                cmd.Parameters.AddWithValue("@fraccion_mes", fraccion_mes);
                cmd.Parameters.AddWithValue("@forma_pago", forma_pago);
                cmd.Parameters.AddWithValue("@comision_administracion", comision_administracion);
                cmd.Parameters.AddWithValue("@folio_contabilidad_1", folio_contabilidad_1);
                cmd.Parameters.AddWithValue("@folio_contabilidad_2", folio_contabilidad_2);
                cmd.Parameters.AddWithValue("@meses_gracias", meses_gracias);
                cmd.Parameters.AddWithValue("@mes_fin_gracias", mes_fin_gracias);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@porcentaje_admin", porcentaje_admin);
                cmd.Parameters.AddWithValue("@porcentaje_corretaje", porcentaje_corretaje);
                cmd.Parameters.AddWithValue("@porcentaje_corretaje_prop", porcentaje_corretaje_prop);
                cmd.Parameters.AddWithValue("@folio_contabilidad_3", folio_contabilidad_3);
                cmd.Parameters.AddWithValue("@f_acta_recepcion", Convert.ToDateTime(f_acta_recepcion));
                conn.Open();

                cmd.ExecuteNonQuery();
            }

            return true;
        }

        public static bool ActualizaObservacion(int @id_usu, int @id_prop, string observacion)
        {
            string Llama_PA = "EXEC Propiedades_Actualiza_Observacion_Propiedad @id_usu, @id_propiedad_arriendo, @g_observacion";
            //HOLA
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_propiedad_arriendo", id_prop);
                cmd.Parameters.AddWithValue("@g_observacion", observacion);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public static List<listascombobox> ListasCombobox(int id, int? id_seleccion)
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Carga_Combo_Listas_Generales @id";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id"].ToString()),
                            descripcion = reader["descripcion"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<listascombobox> ListaPorcentajesAdministracion(int id_usu)
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Propiedades_Combo_Porcentajes_Administracion @id_usu";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id"].ToString()),
                            descripcion = reader["descripcion"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<listaCliente> ListaClientes(int id_usu)
        {
            List<listaCliente> lst = new List<listaCliente>();
            string Llama_PA = "EXEC Carga_Combo_Lista_Clientes @id_usu";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listaCliente
                        {
                            rut = int.Parse(reader["rut"].ToString()),
                            g_dv = reader["g_dv"].ToString(),
                            nombre = reader["nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<listascombobox> ComboBoxHistoricos(string tipo, int proc, int id_usu = 0)
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Historico_Carga_Combos @tipo, @proc, @id_usu";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@proc", proc);
                cmd.Parameters.AddWithValue("@id_usu", id_usu);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id"].ToString()),
                            descripcion = reader["descripcion"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<listascombobox> ListaSacInversionista(int idUsuario)
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Carga_Combo_SAC_Inversionista @id";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id", idUsuario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id"].ToString()),
                            descripcion = reader["nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }
        public static List<listascombobox> ListaSacInversionista_Habilitados(int idUsuario)
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Carga_Combo_SAC_Inversionista_Habilitados @id";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id", idUsuario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id"].ToString()),
                            descripcion = reader["nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }
        public static List<listascombobox> ListaComboboxFormato(int idUsuario, int idProyecto, int idTipologia)
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Propiedades_Carga_Formato @id_usu,@id_pry,@id_tipologia";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", idUsuario);
                cmd.Parameters.AddWithValue("@id_pry", idProyecto);
                cmd.Parameters.AddWithValue("@id_tipologia", idTipologia);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id_formato"].ToString()),
                            descripcion = reader["g_formato"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<listascombobox> ListasComboboxLecaro(int idUsuario, int lista, string orden)
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC lecaros_core.dbo.core_cargar_lista @id_usu, @lista, @orden";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", idUsuario);
                cmd.Parameters.AddWithValue("@lista", lista);
                cmd.Parameters.AddWithValue("@orden", orden);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id"].ToString()),
                            descripcion = reader["descripcion"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }


        public static List<listascombobox> ComboboxEjecutivos()
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Carga_Combo_Ejecutivos 1";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                //cmd.Parameters.AddWithValue("@id", 1);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id"].ToString()),
                            descripcion = reader["nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<listascombobox> ComboboxEjecutivosKAM()
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Carga_Combo_EjecutivosKAM 1";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                //cmd.Parameters.AddWithValue("@id", 1);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id"].ToString()),
                            descripcion = reader["nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }
        public static List<listascombobox> ComboboxEjecutivos_Habilitados()
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Carga_Combo_Ejecutivos_Habilitados 1";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                //cmd.Parameters.AddWithValue("@id", 1);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id"].ToString()),
                            descripcion = reader["nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<listascombobox> ComboboxProyectos(int usuario)
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Recepcion_Carga_Proyectos @usuario, 0";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", usuario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id_pry"].ToString()),
                            descripcion = reader["g_nom_pry"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<listascombobox> ComboboxProyectosGeneral(int usuario)
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Carga_Combo_Proyectos @usuario";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", usuario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["id_pry"].ToString()),
                            descripcion = reader["g_pry"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<listascombobox> ComboboxDisponibilidad()
        {
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Carga_Combo_Disponibilidad 1";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                //cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["mes"].ToString()),
                            descripcion = reader["nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<Orientacion> ComboboxOrientacion()
        {
            List<Orientacion> lst = new List<Orientacion>();
            string Llama_PA = "EXEC Carga_Combo_Orientacion";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new Orientacion
                        {
                            id = reader["id"].ToString(),
                            glosa = reader["glosa"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<listascombobox> ComboboxVencimientoContrato(int numero = 0, int periodo = 0, string f_desde = "1900-01-01", int salto_mes = 1)
        {
            if (numero == 0) { numero = 3; }
            if (periodo == 0) { periodo = 30; }
            List<listascombobox> lst = new List<listascombobox>();
            string Llama_PA = "EXEC Meses_Periodo_Cantidad @numero, @periodo, @f_desde, @salto_mes";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cmd.Parameters.AddWithValue("@f_desde", f_desde);
                cmd.Parameters.AddWithValue("@salto_mes", salto_mes);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listascombobox
                        {
                            id = int.Parse(reader["dias"].ToString()),
                            descripcion = reader["glosa"].ToString(),
                            periodo_dia = reader["periodo_dia"].ToString(),
                            periodo_mes = reader["periodo_mes"].ToString()

                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }


        public static bool PropiedadesActualizaPropietario(int id_usu, int id_propiedad_arriendo, int tipo_propietario, int rut_propietario_1,
           string dv_propietario_1, string g_nom, string g_ape_pat, string g_ape_mat, string g_fono_par, string g_fono_cel,
           string g_mail_per, int id_est_civ, int rut_propietario_2, string dv_propietario_2, string g_nom_2,
           string g_ape_pat_2, string g_ape_mat_2, string g_fono_par_2, string g_fono_cel_2, string g_mail_per_2,
           int id_est_civ_2, int n_rut_emp, string g_dv_emp, string g_nom_emp, string g_dom_emp, int id_dom_emp_com,
           int n_rut_rep_leg, string g_dv_rep_leg, string g_nom_rep_leg, string g_dom_rep_leg, string id_dom_com_rep_leg,
           string cuenta_deposito, int id_banco_deposito, int otro_titular, int rut_otro_titular, string dv_otro_titular,
           string nombre_otro_titular, string mail_otro_titular,
           string direcciontitular, int comunatitular, string n_casa_titular, string n_depto_titular, string poblacion_titular,
           string direccioncotitular, int comunacotitular, string n_casa_cotitular, string n_depto_cotitular, string poblacion_cotitular,
           string g_ape_pat_rep_leg, string g_ape_mat_rep_leg, int id_nac_rep_leg, int id_est_civ_rep_leg, int id_prof_rep_leg, string g_prof_otra_rep_leg, string g_mail_contacto_emp,
           int sacInversionista, int sac_inversionista_emp, string c_giro, string mail_copia_liquidacion, string fono_contacto_empresa)
        {

            string Llama_PA = "EXEC Propiedades_Actualiza_Propietario @id_usu, @id_propiedad_arriendo, @tipo_propietario, @rut_propietario_1, @dv_propietario_1, " +
                "@g_nom, @g_ape_pat, @g_ape_mat, @g_fono_par, @g_fono_cel, @g_mail_per, @id_est_civ, @rut_propietario_2, @dv_propietario_2, @g_nom2, " +
                "@g_ape_pat2, @g_ape_mat2, @g_fono_par2, @g_fono_cel2, @g_mail_per2, @id_est_civ2, @n_rut_emp, @g_dv_emp, @g_nom_emp, " +
                "@g_dom_emp, @id_dom_emp_com, @n_rut_rep_leg, @g_dv_rep_leg, @g_nom_rep_leg, " +

                "@g_ape_pat_rep_leg, @g_ape_mat_rep_leg, " + //*

                "@g_dom_rep_leg, @id_dom_com_rep_leg, " +

                "@id_nac_rep_leg, @id_est_civ_rep_leg, @id_prof_rep_leg, @g_prof_otra_rep_leg, " + //*               

                "@cuenta_deposito, " +
                "@id_banco_deposito, @otro_titular, @rut_otro_titular, @dv_otro_titular, @nombre_otro_titular, @mail_otro_titular, " +
                "@g_dom_par, @id_dom_com,@g_num_casa, @g_num_dep, @g_pob_villa," +
                "@g_dom_par2, @id_dom_com2, @g_num_casa2, @g_num_dep2, @g_pob_villa2, " +
                "@g_mail_contacto_emp, @sac_inversionista, @sac_inversionista_emp, @c_giro,@mail_copia_liquidacion,@fono_contacto_empresa";

            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_propiedad_arriendo", id_propiedad_arriendo);
                cmd.Parameters.AddWithValue("@tipo_propietario", tipo_propietario);
                cmd.Parameters.AddWithValue("@rut_propietario_1", rut_propietario_1);
                cmd.Parameters.AddWithValue("@dv_propietario_1", dv_propietario_1);
                cmd.Parameters.AddWithValue("@g_nom", g_nom);
                cmd.Parameters.AddWithValue("@g_ape_pat", g_ape_pat);
                cmd.Parameters.AddWithValue("@g_ape_mat", g_ape_mat);
                cmd.Parameters.AddWithValue("@g_fono_par", g_fono_par);
                cmd.Parameters.AddWithValue("@g_fono_cel", g_fono_cel);
                cmd.Parameters.AddWithValue("@g_mail_per", g_mail_per);
                cmd.Parameters.AddWithValue("@id_est_civ", id_est_civ);
                cmd.Parameters.AddWithValue("@rut_propietario_2", rut_propietario_2);
                cmd.Parameters.AddWithValue("@dv_propietario_2", dv_propietario_2);
                cmd.Parameters.AddWithValue("@g_nom2", g_nom_2);
                cmd.Parameters.AddWithValue("@g_ape_pat2", g_ape_pat_2);
                cmd.Parameters.AddWithValue("@g_ape_mat2", g_ape_mat_2);
                cmd.Parameters.AddWithValue("@g_fono_par2", g_fono_par_2);
                cmd.Parameters.AddWithValue("@g_fono_cel2", g_fono_cel_2);
                cmd.Parameters.AddWithValue("@g_mail_per2", g_mail_per_2);
                cmd.Parameters.AddWithValue("@id_est_civ2", id_est_civ_2);
                cmd.Parameters.AddWithValue("@n_rut_emp", n_rut_emp);
                cmd.Parameters.AddWithValue("@g_dv_emp", g_dv_emp);
                cmd.Parameters.AddWithValue("@g_nom_emp", g_nom_emp);
                cmd.Parameters.AddWithValue("@g_dom_emp", g_dom_emp);
                cmd.Parameters.AddWithValue("@id_dom_emp_com", id_dom_emp_com);
                cmd.Parameters.AddWithValue("@n_rut_rep_leg", n_rut_rep_leg);
                cmd.Parameters.AddWithValue("@g_dv_rep_leg", g_dv_rep_leg);
                cmd.Parameters.AddWithValue("@g_nom_rep_leg", g_nom_rep_leg);
                cmd.Parameters.AddWithValue("@g_dom_rep_leg", g_dom_rep_leg);
                cmd.Parameters.AddWithValue("@id_dom_com_rep_leg", id_dom_com_rep_leg);

                cmd.Parameters.AddWithValue("@cuenta_deposito", cuenta_deposito);
                cmd.Parameters.AddWithValue("@id_banco_deposito", id_banco_deposito);

                cmd.Parameters.AddWithValue("@otro_titular", otro_titular);
                cmd.Parameters.AddWithValue("@rut_otro_titular", rut_otro_titular);
                cmd.Parameters.AddWithValue("@dv_otro_titular", dv_otro_titular);
                cmd.Parameters.AddWithValue("@nombre_otro_titular", nombre_otro_titular);
                cmd.Parameters.AddWithValue("@mail_otro_titular", mail_otro_titular);

                cmd.Parameters.AddWithValue("@g_dom_par", direcciontitular);
                cmd.Parameters.AddWithValue("@id_dom_com", comunatitular);
                cmd.Parameters.AddWithValue("@g_num_casa", n_casa_titular);
                cmd.Parameters.AddWithValue("@g_num_dep", n_depto_titular);
                cmd.Parameters.AddWithValue("@g_pob_villa", poblacion_titular);

                cmd.Parameters.AddWithValue("@g_dom_par2", direccioncotitular);
                cmd.Parameters.AddWithValue("@id_dom_com2", comunacotitular);
                cmd.Parameters.AddWithValue("@g_num_casa2", n_casa_cotitular);
                cmd.Parameters.AddWithValue("@g_num_dep2", n_depto_cotitular);
                cmd.Parameters.AddWithValue("@g_pob_villa2", poblacion_cotitular);

                //Nuevos datos agregados
                cmd.Parameters.AddWithValue("@g_ape_pat_rep_leg", g_ape_pat_rep_leg);
                cmd.Parameters.AddWithValue("@g_ape_mat_rep_leg", g_ape_mat_rep_leg);
                cmd.Parameters.AddWithValue("@id_nac_rep_leg", id_nac_rep_leg);
                cmd.Parameters.AddWithValue("@id_est_civ_rep_leg", id_est_civ_rep_leg);
                cmd.Parameters.AddWithValue("@id_prof_rep_leg", id_prof_rep_leg);
                cmd.Parameters.AddWithValue("@g_prof_otra_rep_leg", g_prof_otra_rep_leg);

                cmd.Parameters.AddWithValue("@g_mail_contacto_emp", g_mail_contacto_emp);
                cmd.Parameters.AddWithValue("@sac_inversionista", sacInversionista);
                cmd.Parameters.AddWithValue("@sac_inversionista_emp", sac_inversionista_emp);
                cmd.Parameters.AddWithValue("@c_giro", c_giro);
                cmd.Parameters.AddWithValue("@mail_copia_liquidacion", mail_copia_liquidacion);
                cmd.Parameters.AddWithValue("@fono_contacto_empresa", fono_contacto_empresa);

                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }


        public static Response CambiaEstadoPropiedad(int id_usu, int id_contrato, int estado, string mensaje = "")
        {
            string accion = "";
            var response = new Response();
            switch (estado)
            {
                case 0:
                    accion = "G"; break;
                case 10:
                    accion = "N"; break;
                case 20:
                    accion = "R"; break;
                case 30:
                    accion = "D"; break;
                case 35:
                    accion = "PR"; break;
                case 40:
                    accion = "VA"; break;
                case 50:
                    accion = "RA"; break;
                case 60:
                    accion = "OKA"; break;
                case 70:
                    accion = "RF"; break;
                case 80:
                    accion = "OKF"; break;
                case 90:
                    accion = "RG"; break;
                case 100:
                    accion = "OKG"; break;
                case 110:
                    accion = "FC"; break;
                case 120:
                    accion = "ND"; break;
                case 25:
                    accion = "EM"; break;
            }

            string Llama_PA = "EXEC Propiedades_Actualiza_Estado @id_usu, @id_contrato, @accion, @mensaje";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@accion", accion);
                cmd.Parameters.AddWithValue("@mensaje", mensaje);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    response = new Response
                    {
                        Mensaje = reader["mensaje"].ToString(),
                        EsValido = reader["estado"].ToString() == "true" ? true : false
                    };
                }
                conn.Close();
            }

            return response;
        }

        public static bool FiniquitarPropiedad(int id_usu, int id_contrato, bool finiquitar)
        {
            string Llama_PA = "EXEC Propiedades_Actualiza_Estado @id_usu, @id_contrato, @accion";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@accion", finiquitar ? "FI" : "NFI");
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }

            return true;
        }

        public static string CargaComboComuna(int id_proyecto)
        {
            string result = string.Empty;
            string Llama_PA = "EXEC Carga_Comuna_Proyecto @id_proyecto";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader["g_cmn"].ToString();
                }
                conn.Close();
            }

            return result;
        }

        public static string CargaComboMetro(int id_proyecto)
        {
            string result = string.Empty;
            string Llama_PA = "EXEC [Carga_ Metro_Proyecto] @id_proyecto";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader["id_metro"].ToString();
                }
                conn.Close();
            }

            return result;
        }

        public static string EnviarMail(int id_usu, int id_prop, int id_tipo, string fecha_recepcion, string origen, string arriendo_sugerido, string id_contrato)
        {
            string result = string.Empty;
            string Llama_PA = "EXEC Mail_Enviar @id_usu, @id_prop, @id_contrato, @id_tipo, @fecha_entrega, @origen, @arriendo_sugerido";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);
                cmd.Parameters.AddWithValue("@id_tipo", id_tipo);
                //fecha entrega
                if (string.IsNullOrEmpty(fecha_recepcion))
                    cmd.Parameters.AddWithValue("@fecha_entrega", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@fecha_entrega", fecha_recepcion);
                //origen
                if (string.IsNullOrEmpty(origen))
                    cmd.Parameters.AddWithValue("@origen", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@origen", origen);
                //arriendo sugerido
                if (string.IsNullOrEmpty(arriendo_sugerido))
                    cmd.Parameters.AddWithValue("@arriendo_sugerido", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@arriendo_sugerido", arriendo_sugerido);

                //id_contrato
                if (string.IsNullOrEmpty(id_contrato))
                    cmd.Parameters.AddWithValue("@id_contrato", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@id_contrato", id_contrato);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader["mensaje"].ToString();
                }
                conn.Close();
            }
            return result;
        }

        public static bool ActualizaObservacionFinanzas(int id_usu, int id_prop, string observacion)
        {
            string Llama_PA = "EXEC Propiedades_Actualiza_Observacion_Finanzas @id_usu, @id_propiedad_arriendo, @g_observacion";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_propiedad_arriendo", id_prop);
                cmd.Parameters.AddWithValue("@g_observacion", observacion);
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }
        public static bool EnviaMailFiniquitoTerminoAnticipado(int id_usu, int id_contrato, string email_destinatario, int motivofiniquito)
        {
            string Llama_PA = "EXEC Finiquitos_Mail_Aviso_Termino_Anticipado @id_usu, @id_contrato, @email_destinatario, @motivofiniquito";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@email_destinatario", email_destinatario);
                cmd.Parameters.AddWithValue("@motivofiniquito", motivofiniquito);
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }

        public static List<TipoArchivo> TipoArchivo(int usuario, int propiedad, string clase)
        {
            List<TipoArchivo> lst = new List<TipoArchivo>();
            string Llama_PA = "EXEC Catalogo_Carga_Tipos @usuario, @propiedad, @clase";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@propiedad", propiedad);
                cmd.Parameters.AddWithValue("@clase", clase);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new TipoArchivo
                        {
                            id = reader["id"].ToString(),
                            glosa = reader["glosa"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<TipoArchivo> TipoArchivoReparos()
        {
            List<TipoArchivo> lst = new List<TipoArchivo>();
            string Llama_PA = "EXEC Catalogo_Carga_Combo_Tipo 'REPAROS'";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new TipoArchivo
                        {
                            id = reader["id"].ToString(),
                            glosa = reader["nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }


        public static List<TipoArchivo> llama_Envia_Mail_KAM(int proc, string ids_sol)
        {
            List<TipoArchivo> lst = new List<TipoArchivo>();
            string Llama_PA = "EXEC Devoluciones_Mail_Descuentos_KAM @proc,@id_sol";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@proc", proc);
                cmd.Parameters.AddWithValue("@id_sol", ids_sol);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new TipoArchivo
                        {
                            id = reader["id"].ToString(),
                            glosa = reader["nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }
        public static List<TipoArchivo> llama_Envia_Mail_Arr_Dev(int id_usu, int id_sol, int id_contrato, string pathFile, int m_devolucion)
        {
            List<TipoArchivo> lst = new List<TipoArchivo>();
            string Llama_PA = "EXEC Devoluciones_Mail_Descuentos_Arr_Dev @id_usu,@id_sol,@id_contrato,@pathFile,@m_devolucion";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_sol", id_sol);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@pathFile", pathFile);
                cmd.Parameters.AddWithValue("@m_devolucion", m_devolucion);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new TipoArchivo
                        {
                            id = reader["id"].ToString(),
                            glosa = reader["nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<ArchivoFiniquito> CargaArchivosFiniquito(int idUsuario, int idContrato, string tipo)
        {
            List<ArchivoFiniquito> lst = new List<ArchivoFiniquito>();
            string Llama_PA = "";
            if (tipo == "FINIQUITO") Llama_PA = "EXEC Catalogo_Carga_Lista_Finiquito @usuario, 0, @tipo , 0, @idContrato";
            else if (tipo == "REPAROS") Llama_PA = "EXEC Catalogo_Carga_Lista @usuario, @idContrato, @tipo , 0, 0";
            else Llama_PA = "EXEC Catalogo_Carga_Lista @usuario, 0, @tipo , 0, @idContrato";

            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", idUsuario);
                cmd.Parameters.AddWithValue("@idContrato", idContrato);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                //cmd.Parameters.AddWithValue("@id_ticket", id_ticket);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (tipo != "REPAROS")
                        {
                            lst.Add(new ArchivoFiniquito
                            {
                                id_catalogo = reader["id_catalogo"].ToString(),
                                c_tipo = reader["c_tipo"].ToString(),
                                tipo = reader["tipo"].ToString(),
                                descripcion = reader["descripcion"].ToString(),
                                //f_ini_per = reader["f_ini_per"].ToString(),
                                f_ini_per = ((DateTime)reader["f_ini_per"]).ToString("yyyy-MM-dd"),
                                //  f_ter_per = reader["f_ter_per"].ToString(),
                                f_ter_per = ((DateTime)reader["f_ter_per"]).ToString("yyyy-MM-dd"),
                                m_monto = reader["m_monto"].ToString(),
                                archivo = reader["archivo"].ToString(),
                                estado = reader["estado"].ToString(),
                                tipo_devolucion = reader["tipo_devolucion"].ToString(),
                            });
                        }
                        else
                        {
                            lst.Add(new ArchivoFiniquito
                            {
                                id_catalogo = reader["id_catalogo"].ToString(),
                                f_ini_per = ((DateTime)reader["f_ing"]).ToString("dd-MM-yyyy"),
                                c_tipo = reader["c_tipo"].ToString(),
                                tipo = reader["tipo"].ToString(),
                                descripcion = reader["descripcion"].ToString(),
                                estado = reader["estado"].ToString(),
                                f_ter_per = ((DateTime)reader["f_act"]).ToString("dd-MM-yyyy"),
                                archivo = reader["archivo"].ToString(),
                                archivo2 = reader["archivo2"].ToString()
                            });
                        }
                    }
                }
                conn.Close();
            }
            if (tipo != "REPAROS")
            {
                if (tipo == "DEVOLUCION") return lst.Where(a => a.c_tipo == "55" || a.c_tipo == "56" || a.c_tipo == "57" || a.c_tipo == "58" || a.c_tipo == "82").ToList();
                else return lst.Where(a => a.c_tipo == "26" || a.c_tipo == "27" || a.c_tipo == "28" || a.c_tipo == "29" || a.c_tipo == "30" || a.c_tipo == "59" || a.c_tipo == "81").ToList();
            }
            else return lst;
        }

        public static bool RegistrarArchivoDB(int usuario, int id_prop, int tipo_doc, string descripcion, string nombre_archivo, string rut, string id_contrato)
        {
            string Llama_PA = "EXEC Catalogo_Ingresa_Registro @id_usu, @id_prop, @c_tipo, @descrip, @archivo, @rut, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", usuario);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);
                cmd.Parameters.AddWithValue("@c_tipo", tipo_doc);
                cmd.Parameters.AddWithValue("@descrip", descripcion);
                cmd.Parameters.AddWithValue("@archivo", nombre_archivo);

                if (string.IsNullOrEmpty(rut)) cmd.Parameters.AddWithValue("@rut", DBNull.Value);
                else cmd.Parameters.AddWithValue("@rut", rut);

                if (string.IsNullOrEmpty(id_contrato)) cmd.Parameters.AddWithValue("@id_contrato", DBNull.Value);
                else cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }

        public static bool RegistrarArchivoDBPropiedad(int usuario, int id_prop, int tipo_doc, string descripcion, string nombre_archivo, string rut, string id_contrato, string fecha)
        {
            string Llama_PA = "EXEC Catalogo_Ingresa_Registro_Propiedad @id_usu, @id_prop, @c_tipo, @descrip, @fecha, @f_ter_per, @archivo, @rut, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", usuario);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);
                cmd.Parameters.AddWithValue("@c_tipo", tipo_doc);
                cmd.Parameters.AddWithValue("@descrip", descripcion);
                cmd.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("@f_ter_per", DBNull.Value);
                cmd.Parameters.AddWithValue("@archivo", nombre_archivo);

                if (string.IsNullOrEmpty(rut)) cmd.Parameters.AddWithValue("@rut", DBNull.Value);
                else cmd.Parameters.AddWithValue("@rut", rut);

                if (string.IsNullOrEmpty(id_contrato)) cmd.Parameters.AddWithValue("@id_contrato", DBNull.Value);
                else cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }

        public static bool RegistrarArchivoDBMasivo(int usuario, int id_prop, int tipo_doc, string descripcion, string nombre_archivo, string rut, string id_contrato, string fecha, int proc, int id_catalogo, string monto)
        {
            string Llama_PA = "EXEC Catalogo_Ingresa_Registro_Masivo @id_usu, @id_prop, @c_tipo, @descrip, @fecha, '1900-01-01', @archivo, @rut, @id_contrato,@proc,@id_catalogo, @monto_tasacion";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", usuario);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);
                cmd.Parameters.AddWithValue("@c_tipo", tipo_doc);
                cmd.Parameters.AddWithValue("@descrip", descripcion);
                cmd.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fecha));
                //cmd.Parameters.AddWithValue("@f_ter_per", DBNull.Value);
                cmd.Parameters.AddWithValue("@archivo", nombre_archivo);
                cmd.Parameters.AddWithValue("@proc", proc);
                cmd.Parameters.AddWithValue("@id_catalogo", id_catalogo);
                cmd.Parameters.AddWithValue("@rut", rut);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@monto_tasacion", monto);

                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }

        public static List<ListadoArchivos> TraeArchivos(int id_propiedad, string clase_archivo, int usuario, string ruta, string rut, string id_contrato)
        {
            List<ListadoArchivos> lst = new List<ListadoArchivos>();
            string Llama_PA = "EXEC Catalogo_Carga_Lista_Masivo @usuario, @propiedad, @clase, @rut, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@propiedad", id_propiedad);
                cmd.Parameters.AddWithValue("@clase", clase_archivo);

                if (string.IsNullOrEmpty(rut)) cmd.Parameters.AddWithValue("@rut", DBNull.Value);
                else cmd.Parameters.AddWithValue("@rut", rut.Split('-')[0]);

                if (string.IsNullOrEmpty(id_contrato)) cmd.Parameters.AddWithValue("@id_contrato", DBNull.Value);
                else cmd.Parameters.AddWithValue("@id_contrato", id_contrato);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new ListadoArchivos
                        {
                            descripcion = reader["descripcion"].ToString(),
                            archivo = ruta + reader["archivo"].ToString(),
                            id_catalogo = reader["id_catalogo"].ToString(),
                            tipo = reader["tipo"].ToString(),
                            fecha = ((DateTime)reader["fecha"]).ToString("dd-MM-yyyy"),
                            id_tipo = reader["c_tipo"].ToString(),
                            f_mail = reader["f_mail"].ToString(),
                            g_mail = reader["g_mail"].ToString(),
                            id_usu_mail = reader["id_usu_mail"].ToString(),
                            nom_usu_mail = reader["nom_usu_mail"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<ListadoArchivos> TraeArchivosFiniquito(int id_propiedad, string clase_archivo, int usuario, string ruta, string rut, string id_contrato)
        {
            List<ListadoArchivos> lst = new List<ListadoArchivos>();
            string Llama_PA = "EXEC Catalogo_Carga_Lista_Masivo @usuario, @propiedad, @clase, @rut, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@propiedad", id_propiedad);
                cmd.Parameters.AddWithValue("@clase", clase_archivo);

                if (string.IsNullOrEmpty(rut)) cmd.Parameters.AddWithValue("@rut", DBNull.Value);
                else cmd.Parameters.AddWithValue("@rut", rut.Split('-')[0]);

                if (string.IsNullOrEmpty(id_contrato)) cmd.Parameters.AddWithValue("@id_contrato", DBNull.Value);
                else cmd.Parameters.AddWithValue("@id_contrato", id_contrato);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new ListadoArchivos
                        {
                            descripcion = reader["descripcion"].ToString(),
                            archivo = ruta + reader["archivo"].ToString(),
                            id_catalogo = reader["id_catalogo"].ToString(),
                            tipo = reader["tipo"].ToString(),
                            fecha = ((DateTime)reader["fecha"]).ToString("dd-MM-yyyy"),
                            id_tipo = reader["c_tipo"].ToString(),
                            f_mail = reader["f_mail"].ToString(),
                            g_mail = reader["g_mail"].ToString(),
                            id_usu_mail = reader["id_usu_mail"].ToString(),
                            nom_usu_mail = reader["nom_usu_mail"].ToString(),
                            monto = reader["monto"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<ListadoArchivos> TraeArchivosPropiedad(int id_propiedad, string clase_archivo, int usuario, string ruta, string rut, string id_contrato)
        {
            List<ListadoArchivos> lst = new List<ListadoArchivos>();
            string Llama_PA = "EXEC Catalogo_Carga_Lista_Propiedad @usuario, @propiedad, @clase, @rut, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@propiedad", id_propiedad);
                cmd.Parameters.AddWithValue("@clase", clase_archivo);

                if (string.IsNullOrEmpty(rut)) cmd.Parameters.AddWithValue("@rut", DBNull.Value);
                else cmd.Parameters.AddWithValue("@rut", rut.Split('-')[0]);

                if (string.IsNullOrEmpty(id_contrato)) cmd.Parameters.AddWithValue("@id_contrato", DBNull.Value);
                else cmd.Parameters.AddWithValue("@id_contrato", id_contrato);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new ListadoArchivos
                        {
                            descripcion = reader["descripcion"].ToString(),
                            archivo = ruta + reader["archivo"].ToString(),
                            id_catalogo = reader["id_catalogo"].ToString(),
                            tipo = reader["tipo"].ToString(),
                            fecha = ((DateTime)reader["fecha"]).ToString("dd-MM-yyyy")
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static bool EliminaArchivo(int id_usuario, int id_archivo)
        {
            string Llama_PA = "EXEC Catalogo_Elimina_Registro @usuario, @archivo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", id_usuario);
                cmd.Parameters.AddWithValue("@archivo", id_archivo);
                //cmd.Parameters.AddWithValue("@ticket", ticket);
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }

        public static bool EliminaAdjuntoCaracteristica(int id_usuario, int id_caracteristica)
        {
            string Llama_PA = "EXEC Propiedades_Caracteristica_Elimina_Adjunto @id_usu, @id_caracteristica";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@id_caracteristica", id_caracteristica);
                //cmd.Parameters.AddWithValue("@ticket", ticket);
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }


        public static bool EliminaArchivoArriendo(int id_archivo, int id_usuario)
        {
            string Llama_PA = "EXEC Catalogo_elimina_registro_arriendo @usuario, @archivo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", id_usuario);
                cmd.Parameters.AddWithValue("@archivo", id_archivo);
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }

        public static List<Arriendo> DatosArriendo(int usuario, int id_prop, int id_contrato)
        {
            List<Arriendo> lst = new List<Arriendo>();
            string Llama_PA = "EXEC Propiedades_Carga_Arriendo @usuario, @prop, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@prop", id_prop);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new Arriendo
                        {
                            id_prop_arriendo = reader["id_prop_arriendo"].ToString(),
                            id_contrato = reader["id_contrato"].ToString(),
                            inicio_contrato = reader["inicio_contrato"].ToString(),
                            termino_contrato = reader["termino_contrato"].ToString(),
                            firma_contrato = reader["firma_contrato"].ToString(),
                            dia_pago = reader["dia_pago"].ToString(),
                            f_renovacion = reader["f_renovacion"].ToString(),
                            valor_arriendo = reader["valor_arriendo"].ToString(),
                            com_corretaje_con_iva = reader["com_corretaje_con_iva"].ToString(),
                            valor_garantia = reader["valor_garantia"].ToString(),
                            gastos_notariales = reader["gastos_notariales"].ToString(),
                            costo_dicom = reader["costo_dicom"].ToString(),
                            fraccion_mes = reader["fraccion_mes"].ToString(),
                            forma_pago = reader["forma_pago"].ToString(),
                            com_admin_con_iva = reader["com_admin_con_iva"].ToString(),
                            folio_contabilidad_1 = reader["folio_contabilidad_1"].ToString(),
                            folio_contabilidad_2 = reader["folio_contabilidad_2"].ToString(),
                            folio_contabilidad_3 = reader["folio_contabilidad_3"].ToString(),
                            observacion_general = reader["observacion_general"].ToString(),
                            n_meses_gracia = reader["n_meses_gracia"].ToString(),
                            f_1er_dividendo = reader["f_1er_dividendo"].ToString(),
                            estado = reader["estado"].ToString(),
                            id_banco_deposito = reader["id_banco_deposito"].ToString(),
                            com_corretaje_arrendatario_por = reader["com_corretaje_arrendatario_por"].ToString(),
                            com_corretaje_propietario_por = reader["com_corretaje_propietario_por"].ToString(),
                            comision_administracion_por = reader["comision_administracion_por"].ToString(),
                            f_acta_recepcion = reader["f_acta_recepcion"].ToString(),
                            b_aviso_renovacion = reader["b_aviso_renovacion"].ToString(),
                            arriendo_sugerido = reader["arriendo_sugerido"].ToString(),
                            fecha_aviso_renovacion = reader["fecha_aviso_renovacion"].ToString(),
                            gastos_comunes = reader["gastos_comunes_sugeridos"].ToString(),

                            //Devoluciones
                            b_mail_bienvenida = reader["b_mail_bienvenida"].ToString(),
                            f_mail_bienvenida = reader["f_mail_bienvenida"].ToString(),
                            b_dev_consumo = reader["b_dev_consumo"].ToString(),
                            b_dev_gen_sol = reader["b_dev_gen_sol"].ToString(),
                            b_dev_gen_carta = reader["b_dev_gen_carta"].ToString(),
                            f_dev_gen_sol = reader["f_dev_gen_sol"].ToString(),
                            b_dev_pagada = reader["b_dev_pagada"].ToString(),
                            f_dev_pagada = reader["f_dev_pagada"].ToString(),
                            b_dev_mail_env = reader["b_dev_mail_env"].ToString(),
                            f_dev_mail_env = reader["f_dev_mail_env"].ToString(),

                            //Observacion en PDF de Devoluciones // 01-10-2019
                            observacion_carta_devolucion = reader["observacion_carta_devolucion"].ToString(),
                            ldi_lp = reader["ldi_lp"].ToString(),
                            f_rec_cont_ant = reader["f_rec_cont_ant"].ToString(), //add CA 02-01-2019
                            //Reservas y Renovacion
                            //valor_costo_renovacion = reader["valor_costo_renovacion"].ToString(),
                            //monto_reserva = reader["monto_reserva"].ToString(),
                            //id_forma_pago_reserva = reader["id_forma_pago_reserva"].ToString(),
                            //b_renovacion = reader["b_renovacion"].ToString()
                            tipo_bien = reader["tipo_bien"].ToString(),
                            monto_reserva_garantia = reader["monto_reserva_garantia"].ToString(),
                            b_internet = reader["b_internet"].ToString(),
                            b_arriendouf = reader["b_arriendouf"].ToString(),
                            b_amoblado = reader["b_amoblado"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;

        }


        public static List<Arriendo> DatosArriendoFiniquito(int usuario, int id_prop, int id_contrato)
        {
            List<Arriendo> lst = new List<Arriendo>();
            string Llama_PA = "EXEC Propiedades_Carga_Arriendo_Finiquito @usuario, @prop, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@prop", id_prop);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new Arriendo
                        {
                            id_prop_arriendo = reader["id_prop_arriendo"].ToString(),
                            id_contrato = reader["id_contrato"].ToString(),
                            inicio_contrato = reader["inicio_contrato"].ToString(),
                            termino_contrato = reader["termino_contrato"].ToString(),
                            firma_contrato = reader["firma_contrato"].ToString(),
                            dia_pago = reader["dia_pago"].ToString(),
                            f_renovacion = reader["f_renovacion"].ToString(),
                            valor_arriendo = reader["valor_arriendo"].ToString(),
                            com_corretaje_con_iva = reader["com_corretaje_con_iva"].ToString(),
                            valor_garantia = reader["valor_garantia"].ToString(),
                            gastos_notariales = reader["gastos_notariales"].ToString(),
                            costo_dicom = reader["costo_dicom"].ToString(),
                            fraccion_mes = reader["fraccion_mes"].ToString(),
                            forma_pago = reader["forma_pago"].ToString(),
                            id_banco_deposito = reader["id_banco_deposito"].ToString(),
                            com_admin_con_iva = reader["com_admin_con_iva"].ToString(),
                            folio_contabilidad_1 = reader["folio_contabilidad_1"].ToString(),
                            folio_contabilidad_2 = reader["folio_contabilidad_2"].ToString(),
                            folio_contabilidad_3 = reader["folio_contabilidad_3"].ToString(),
                            f_acta_recepcion = reader["f_acta_recepcion"].ToString(),
                            observacion_general = reader["observacion_general"].ToString(),
                            n_meses_gracia = reader["n_meses_gracia"].ToString(),
                            f_1er_dividendo = reader["f_1er_dividendo"].ToString(),
                            estado = reader["estado"].ToString(),
                            com_corretaje_arrendatario_por = reader["com_corretaje_arrendatario_por"].ToString(),
                            com_corretaje_propietario_por = reader["com_corretaje_propietario_por"].ToString(),
                            comision_administracion_por = reader["comision_administracion_por"].ToString(),
                            b_aviso_renovacion = reader["b_aviso_renovacion"].ToString(),
                            arriendo_sugerido = reader["arriendo_sugerido"].ToString(),
                            fecha_aviso_renovacion = reader["fecha_aviso_renovacion"].ToString(),
                            b_finiquito = reader["b_finiquito"].ToString(),
                            observacion_carta_devolucion = reader["observacion_carta_devolucion"].ToString(),
                            ldi_lp = reader["ldi_lp"].ToString(),
                            f_rec_cont_ant = reader["f_rec_cont_ant"].ToString(), //add CA 02-01-2019
                            devolucion_garantia = reader["devolucion_garantia"].ToString(),
                            b_internet = reader["b_internet"].ToString(),
                            b_arriendouf = reader["b_arriendouf"].ToString(),
                            b_amoblado = reader["b_amoblado"].ToString(),
                            valor_costo_renovacion = reader["valor_costo_renovacion"].ToString(),

                        });
                    }
                }
                conn.Close();
            }
            return lst;

        }

        //public static List<Arriendo> DatosArriendo(int usuario, int id_prop, int id_contrato)
        //{
        //    List<Arriendo> lst = new List<Arriendo>();
        //    string Llama_PA = "EXEC Propiedades_Carga_Arriendo @usuario, @prop, @id_contrato";
        //    using (SqlConnection conn = new SqlConnection(connCorretaje))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(Llama_PA, conn);
        //        cmd.Parameters.AddWithValue("@usuario", usuario);
        //        cmd.Parameters.AddWithValue("@prop", id_prop);
        //        cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                lst.Add(new Arriendo
        //                {
        //                    id_prop_arriendo = reader["id_prop_arriendo"].ToString(),
        //                    id_contrato = reader["id_contrato"].ToString(),
        //                    inicio_contrato = reader["inicio_contrato"].ToString(),
        //                    termino_contrato = reader["termino_contrato"].ToString(),
        //                    firma_contrato = reader["firma_contrato"].ToString(),
        //                    dia_pago = reader["dia_pago"].ToString(),
        //                    f_renovacion = reader["f_renovacion"].ToString(),
        //                    valor_arriendo = reader["valor_arriendo"].ToString(),
        //                    com_corretaje_con_iva = reader["com_corretaje_con_iva"].ToString(),
        //                    valor_garantia = reader["valor_garantia"].ToString(),
        //                    gastos_notariales = reader["gastos_notariales"].ToString(),
        //                    costo_dicom = reader["costo_dicom"].ToString(),
        //                    fraccion_mes = reader["fraccion_mes"].ToString(),
        //                    forma_pago = reader["forma_pago"].ToString(),
        //                    com_admin_con_iva = reader["com_admin_con_iva"].ToString(),
        //                    folio_contabilidad_1 = reader["folio_contabilidad_1"].ToString(),
        //                    folio_contabilidad_2 = reader["folio_contabilidad_2"].ToString(),
        //                    folio_contabilidad_3 = reader["folio_contabilidad_3"].ToString(),
        //                    observacion_general = reader["observacion_general"].ToString(),
        //                    n_meses_gracia = reader["n_meses_gracia"].ToString(),
        //                    f_1er_dividendo = reader["f_1er_dividendo"].ToString(),
        //                    estado = reader["estado"].ToString(),
        //                    id_banco_deposito = reader["id_banco_deposito"].ToString(),
        //                    com_corretaje_arrendatario_por = reader["com_corretaje_arrendatario_por"].ToString(),
        //                    com_corretaje_propietario_por = reader["com_corretaje_propietario_por"].ToString(),
        //                    comision_administracion_por = reader["comision_administracion_por"].ToString(),
        //                    f_acta_recepcion = reader["f_acta_recepcion"].ToString(),
        //                    b_aviso_renovacion = reader["b_aviso_renovacion"].ToString(),
        //                    arriendo_sugerido = reader["arriendo_sugerido"].ToString(),
        //                    fecha_aviso_renovacion = reader["fecha_aviso_renovacion"].ToString(),
        //                     gastos_comunes = reader["gastos_comunes_sugeridos"].ToString(),

        //                    //Devoluciones
        //                    b_mail_bienvenida = reader["b_mail_bienvenida"].ToString(),
        //                    f_mail_bienvenida = reader["f_mail_bienvenida"].ToString(),
        //                    b_dev_consumo = reader["b_dev_consumo"].ToString(),
        //                    b_dev_gen_sol = reader["b_dev_gen_sol"].ToString(),
        //                    b_dev_gen_carta = reader["b_dev_gen_carta"].ToString(),
        //                    f_dev_gen_sol = reader["f_dev_gen_sol"].ToString(),
        //                    b_dev_pagada = reader["b_dev_pagada"].ToString(),
        //                    f_dev_pagada = reader["f_dev_pagada"].ToString(),
        //                    b_dev_mail_env = reader["b_dev_mail_env"].ToString(),
        //                    f_dev_mail_env = reader["f_dev_mail_env"].ToString(),

        //                    //Observacion en PDF de Devoluciones // 01-10-2019
        //                    observacion_carta_devolucion = reader["observacion_carta_devolucion"].ToString(),
        //                    ldi_lp = reader["ldi_lp"].ToString(),

        //                    //Reservas y Renovacion
        //                    //valor_costo_renovacion = reader["valor_costo_renovacion"].ToString(),
        //                    //monto_reserva = reader["monto_reserva"].ToString(),
        //                    //id_forma_pago_reserva = reader["id_forma_pago_reserva"].ToString(),
        //                    //b_renovacion = reader["b_renovacion"].ToString()

        //                });
        //            }
        //        }
        //        conn.Close();
        //    }
        //    return lst;

        //}

        //public static List<Arriendo> DatosArriendoFiniquito(int usuario, int id_prop, int id_contrato)
        //{
        //    List<Arriendo> lst = new List<Arriendo>();
        //    string Llama_PA = "EXEC Propiedades_Carga_Arriendo_Finiquito @usuario, @prop, @id_contrato";
        //    using (SqlConnection conn = new SqlConnection(connCorretaje))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(Llama_PA, conn);
        //        cmd.Parameters.AddWithValue("@usuario", usuario);
        //        cmd.Parameters.AddWithValue("@prop", id_prop);
        //        cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                lst.Add(new Arriendo
        //                {
        //                    id_prop_arriendo = reader["id_prop_arriendo"].ToString(),
        //                    id_contrato = reader["id_contrato"].ToString(),
        //                    inicio_contrato = reader["inicio_contrato"].ToString(),
        //                    termino_contrato = reader["termino_contrato"].ToString(),
        //                    firma_contrato = reader["firma_contrato"].ToString(),
        //                    dia_pago = reader["dia_pago"].ToString(),
        //                    f_renovacion = reader["f_renovacion"].ToString(),
        //                    valor_arriendo = reader["valor_arriendo"].ToString(),
        //                    com_corretaje_con_iva = reader["com_corretaje_con_iva"].ToString(),
        //                    valor_garantia = reader["valor_garantia"].ToString(),
        //                    gastos_notariales = reader["gastos_notariales"].ToString(),
        //                    costo_dicom = reader["costo_dicom"].ToString(),
        //                    fraccion_mes = reader["fraccion_mes"].ToString(),
        //                    forma_pago = reader["forma_pago"].ToString(),
        //                    id_banco_deposito = reader["id_banco_deposito"].ToString(),
        //                    com_admin_con_iva = reader["com_admin_con_iva"].ToString(),
        //                    folio_contabilidad_1 = reader["folio_contabilidad_1"].ToString(),
        //                    folio_contabilidad_2 = reader["folio_contabilidad_2"].ToString(),
        //                    folio_contabilidad_3 = reader["folio_contabilidad_3"].ToString(),
        //                    f_acta_recepcion = reader["f_acta_recepcion"].ToString(),
        //                    observacion_general = reader["observacion_general"].ToString(),
        //                    n_meses_gracia = reader["n_meses_gracia"].ToString(),
        //                    f_1er_dividendo = reader["f_1er_dividendo"].ToString(),
        //                    estado = reader["estado"].ToString(),                            
        //                    com_corretaje_arrendatario_por = reader["com_corretaje_arrendatario_por"].ToString(),
        //                    com_corretaje_propietario_por = reader["com_corretaje_propietario_por"].ToString(),
        //                    comision_administracion_por = reader["comision_administracion_por"].ToString(),                            
        //                    b_aviso_renovacion = reader["b_aviso_renovacion"].ToString(),
        //                    arriendo_sugerido = reader["arriendo_sugerido"].ToString(),
        //                    fecha_aviso_renovacion = reader["fecha_aviso_renovacion"].ToString(),
        //                    b_finiquito = reader["b_finiquito"].ToString()

        //                });
        //            }
        //        }
        //        conn.Close();
        //    }
        //    return lst;

        //}

        public static int Propiedades_Actualiza_Arriendo(int id_usu, int id_propiedad_arriendo,
            string inicio_contrato, string termino_contrato, string firma_contrato, int dia_pago, string fecha_renovacion, float valor_arriendo,
            float comision_corretaje, float valor_garantia, float gastos_notariales, float costo_dicom, float fraccion_mes,
            int forma_pago, float comision_administracion, int folio_contabilidad_1, int folio_contabilidad_2,
            int meses_gracias, string mes_fin_gracias, string observacion, float porcentaje_admin, float porcentaje_corretaje, float porcentaje_corretaje_prop, int folio_contabilidad_3,
            string f_acta_recepcion, string fecha_aviso_renovacion, float arriendo_sugerido, int b_aviso_renovacion, int id_contrato, float gastos_comunes,
            float valor_costo_renovacion, float monto_reserva, int id_forma_pago_reserva, string observacion_carta_devolucion, int ldi_lp)
        {
            //List<propiedad> lst = new List<propiedad>();

            int _id_contrato = 0;

            string Llama_PA = "EXEC Propiedades_Actualiza_Arriendo @id_usu, @id_propiedad_arriendo, @id_contrato, @inicio_contrato, " +
                "@termino_contrato, @firma_contrato, @dia_pago, @fecha_renovacion, @valor_arriendo, @comision_corretaje, @valor_garantia, " +
                "@gastos_notariales, @costo_dicom, @fraccion_mes, @forma_pago, @comision_administracion, " +
                "@folio_contabilidad_1, @folio_contabilidad_2, @meses_gracias, @mes_fin_gracias, @observacion, @porcentaje_admin, @porcentaje_corretaje, @porcentaje_corretaje_prop, " +
                "@folio_contabilidad_3, @f_acta_recepcion, @b_aviso_renovacion, @arriendo_sugerido, @fecha_aviso_renovacion, @gastos_comunes, @valor_costo_renovacion," +
                "@monto_reserva, @id_forma_pago_reserva, @ldi_lp";

            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_propiedad_arriendo", id_propiedad_arriendo);
                cmd.Parameters.AddWithValue("@inicio_contrato", Convert.ToDateTime(inicio_contrato).ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@termino_contrato", Convert.ToDateTime(termino_contrato).ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@firma_contrato", Convert.ToDateTime(firma_contrato).ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@dia_pago", dia_pago);
                cmd.Parameters.AddWithValue("@fecha_renovacion", Convert.ToDateTime(fecha_renovacion).ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@valor_arriendo", valor_arriendo);
                cmd.Parameters.AddWithValue("@comision_corretaje", comision_corretaje);
                cmd.Parameters.AddWithValue("@valor_garantia", valor_garantia);
                cmd.Parameters.AddWithValue("@gastos_notariales", gastos_notariales);
                cmd.Parameters.AddWithValue("@costo_dicom", costo_dicom);
                cmd.Parameters.AddWithValue("@fraccion_mes", fraccion_mes);
                cmd.Parameters.AddWithValue("@forma_pago", forma_pago);
                cmd.Parameters.AddWithValue("@comision_administracion", comision_administracion);
                cmd.Parameters.AddWithValue("@folio_contabilidad_1", folio_contabilidad_1);
                cmd.Parameters.AddWithValue("@folio_contabilidad_2", folio_contabilidad_2);
                cmd.Parameters.AddWithValue("@meses_gracias", meses_gracias);
                cmd.Parameters.AddWithValue("@mes_fin_gracias", Convert.ToDateTime(mes_fin_gracias).ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@porcentaje_admin", porcentaje_admin);
                cmd.Parameters.AddWithValue("@porcentaje_corretaje", porcentaje_corretaje);
                cmd.Parameters.AddWithValue("@porcentaje_corretaje_prop", porcentaje_corretaje_prop);
                cmd.Parameters.AddWithValue("@folio_contabilidad_3", folio_contabilidad_3);
                cmd.Parameters.AddWithValue("@f_acta_recepcion", Convert.ToDateTime(f_acta_recepcion));
                cmd.Parameters.AddWithValue("@b_aviso_renovacion", b_aviso_renovacion);
                cmd.Parameters.AddWithValue("@arriendo_sugerido", arriendo_sugerido);
                cmd.Parameters.AddWithValue("@fecha_aviso_renovacion", Convert.ToDateTime(fecha_aviso_renovacion));
                cmd.Parameters.AddWithValue("@gastos_comunes", gastos_comunes);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@valor_costo_renovacion", valor_costo_renovacion);
                cmd.Parameters.AddWithValue("@monto_reserva", monto_reserva);
                cmd.Parameters.AddWithValue("@id_forma_pago_reserva", id_forma_pago_reserva);
                //cmd.Parameters.AddWithValue("@observacion_carta_devolucion", observacion_carta_devolucion);
                cmd.Parameters.AddWithValue("@ldi_lp", ldi_lp);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //lst.Add(new propiedad
                        //{
                        //    estado_2 = reader["estado"].ToString(),
                        //    id_contrato = reader["id_contrato"].ToString(),
                        //    mensaje_pa = reader["mensaje"].ToString()
                        //});
                        _id_contrato = int.Parse(reader["id"].ToString());
                    }
                }
                conn.Close();
            }
            return _id_contrato;
        }

        public static List<estados> Llamar_Pagos_Actualiza_Cuota(int id_pago, int cuota, string mes, string concepto, int monto,
            string vencimiento, int id_fpago, int id_banco, string g_titular, string g_rut_titular, string num_chk_ope, string observacion, string fecha_pago, int usuario,
            string com_corretaje_por, string com_admin_por, string cta_corriente)
        {
            List<estados> lst = new List<estados>();
            string Llama_PA = "EXEC Pagos_Actualiza_Cuota @id_pago, @cuota, @mes, @concepto, @monto, @vencimiento, @id_fpago, @id_banco, @g_titular, @g_rut_titular, @num_chk_ope, @observacion, @fecha_pago, @usuario, @com_corretaje_por, @com_admin_por, @cta_corriente";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                cmd.Parameters.AddWithValue("@cuota", cuota);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@concepto", concepto);
                cmd.Parameters.AddWithValue("@monto", monto);
                cmd.Parameters.AddWithValue("@vencimiento", vencimiento);
                cmd.Parameters.AddWithValue("@id_fpago", id_fpago);
                cmd.Parameters.AddWithValue("@id_banco", id_banco);
                cmd.Parameters.AddWithValue("@g_titular", g_titular);
                cmd.Parameters.AddWithValue("@g_rut_titular", g_rut_titular);
                cmd.Parameters.AddWithValue("@num_chk_ope", num_chk_ope);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@fecha_pago", fecha_pago);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@com_corretaje_por", com_corretaje_por);
                cmd.Parameters.AddWithValue("@com_admin_por", com_admin_por);
                cmd.Parameters.AddWithValue("@cta_corriente", cta_corriente);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        lst.Add(new estados
                        {
                            estado = reader["estado"].ToString(),
                            mensaje = reader["mensaje"].ToString(),
                            id = int.Parse(reader["id_cuota"].ToString())
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static bool Llama_Pagos_Existen_Cuotas(int id_contrato)
        {
            bool estado = false;
            string Llama_PA = "EXEC Pagos_Existen_Cuotas @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (int.Parse(reader["cuotas"].ToString()) >= 1)
                        {
                            estado = true;
                        }
                    }
                }
                conn.Close();
            }
            return estado;
        }

        public static List<ObservGenerales> TraeObservaciones(int id_propiedad, string tipo_observacion, int id_contrato = 0)
        {
            List<ObservGenerales> lst = new List<ObservGenerales>();
            string Llama_PA = "EXEC Observaciones_Carga_Lista @id_prop, @observ, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_prop", id_propiedad);
                cmd.Parameters.AddWithValue("@observ", tipo_observacion);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new ObservGenerales
                        {
                            fecha = reader["fecha"].ToString(),
                            nombre = reader["nombre"].ToString(),
                            observacion = reader["observacion"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<ObservGenerales> Solicitud_Devolucion_Express(int id_usu, int id_propiedad, int id_contrato = 0)
        {
            List<ObservGenerales> lst = new List<ObservGenerales>();
            string Llama_PA = "EXEC Finiquito_Envia_Garantia_Express @id_usu,@id_prop, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_prop", id_propiedad);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new ObservGenerales
                        {
                            //fecha = reader["fecha"].ToString(),
                            //nombre = reader["nombre"].ToString(),
                            observacion = reader["mensaje"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static bool AgregarObservacion(int id_usuario, int id_propiedad, string tipo_observ, string observacion, int id_contrato = 0)
        {
            string Llama_PA = "EXEC Observaciones_Ingresa @id_usuario, @id_propiedad, @tipo_observ, @observacion, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@id_propiedad", id_propiedad);
                cmd.Parameters.AddWithValue("@tipo_observ", tipo_observ);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }

        public static DataSet Llama_EXCEL_Genera_Descuentos(int id_usu, int id_prop, string periodo)
        {
            DataSet ds = new DataSet();
            string Llama_PA = "EXEC EXCEL_Genera_Descuentos @id_usu, @id_prop, @periodo";
            SqlConnection conn = new SqlConnection(connCorretaje);
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(Llama_PA, conn);

            adp.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@id_usu", id_usu);
            cmd.Parameters.AddWithValue("@id_prop", id_prop);
            cmd.Parameters.AddWithValue("@periodo", periodo);

            adp.Fill(ds);

            return ds;
        }

        public static DataSet TraePropiedadesExcel(int id_usuario, int id_pry, int c_tipologia, int n_mes_dis, int id_ejecutivo, int c_edo, int n_ven_con) //Trae una propiedad
        {
            DataSet ds = new DataSet();
            string Llama_PA = "EXEC EXCEL_Genera_Propiedades @id_usu, @id_pry, @c_tipologia, @n_mes_dis, @id_ejecutivo, @c_edo, @n_ven_con";
            SqlConnection conn = new SqlConnection(connCorretaje);
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(Llama_PA, conn);

            adp.SelectCommand = cmd;

            cmd.Parameters.AddWithValue("@id_usu", id_usuario);
            cmd.Parameters.AddWithValue("@id_pry", id_pry);
            cmd.Parameters.AddWithValue("@c_tipologia", c_tipologia);
            cmd.Parameters.AddWithValue("@n_mes_dis", n_mes_dis);
            cmd.Parameters.AddWithValue("@id_ejecutivo", id_ejecutivo);
            cmd.Parameters.AddWithValue("@c_edo", c_edo);
            cmd.Parameters.AddWithValue("@n_ven_con", n_ven_con);

            adp.Fill(ds);

            return ds;

            //using (SqlConnection conn = new SqlConnection(connCorretaje))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand(Llama_PA, conn);
            //    cmd.Parameters.AddWithValue("@id_usu", id_usuario);
            //    cmd.Parameters.AddWithValue("@id_pry", id_pry);
            //    cmd.Parameters.AddWithValue("@c_tipologia", c_tipologia);
            //    cmd.Parameters.AddWithValue("@n_mes_dis", n_mes_dis);
            //    cmd.Parameters.AddWithValue("@id_ejecutivo", id_ejecutivo);
            //    cmd.Parameters.AddWithValue("@c_edo", c_edo);
            //    cmd.Parameters.AddWithValue("@n_ven_con", n_ven_con);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            lst.Add(new ListadoExcel
            //            {
            //                direccion = reader["direccion"].ToString(),
            //                depto = reader["num_depto"].ToString(),
            //                arrendatario = reader["arrendatario"].ToString(),
            //                propietario = reader["propietario"].ToString(),
            //                tipologia = reader["tipologia"].ToString(),
            //                superficie = reader["superficie"].ToString(),
            //                orientacion = reader["orientacion"].ToString(),
            //                n_bodega = reader["num_bodega"].ToString(),
            //                n_estacionamiento = reader["num_estacionam"].ToString(),
            //                term_contrato = reader["termino_contrato"].ToString(),
            //                ejecutivo = reader["nombre_ejecutivo"].ToString(),
            //                arriendo = reader["arriendo"].ToString(),
            //                estado = reader["nombre_estado"].ToString(),
            //                folio = reader["id_prop_arriendo"].ToString(),
            //                proyecto = reader["proyecto"].ToString(),
            //                inmobiliaria = reader["inmobiliaria"].ToString(),
            //                comuna = reader["comuna"].ToString(),
            //                metro = reader["metro"].ToString(),
            //                fecha_inicio_contrato = reader["f_inicio_contrato"].ToString(),
            //                fecha_termino_contrato = reader["f_firma_contrato"].ToString()
            //            });
            //        }
            //    }
            //    conn.Close();
            //}
            //return lst;
        }

        public static DataSet TraeReciboDineroExcel(int id_usuario, int id_contrato) //Trae una propiedad
        {
            DataSet ds = new DataSet();
            string Llama_PA = "EXEC EXCEL_Genera_Recibo_Dinero @id_usu, @id_contrato";
            SqlConnection conn = new SqlConnection(connCorretaje);
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(Llama_PA, conn);

            adp.SelectCommand = cmd;

            cmd.Parameters.AddWithValue("@id_usu", id_usuario);
            cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

            adp.Fill(ds);

            return ds;
        }

        public static DataSet TraeReciboDineroExcelMan(int id_usuario, int id_contrato) //Trae una propiedad
        {
            DataSet ds = new DataSet();
            string Llama_PA = "EXEC EXCEL_Genera_Recibo_Dinero_MANAGER @id_usu, @id_contrato";
            SqlConnection conn = new SqlConnection(connCorretaje);
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(Llama_PA, conn);

            adp.SelectCommand = cmd;

            cmd.Parameters.AddWithValue("@id_usu", id_usuario);
            cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

            adp.Fill(ds);

            return ds;
        }

        public static DataSet TraeReciboDineroExcelMan_Multiple(int id_usuario, string ids_contrato) //Trae una propiedad
        {
            DataSet ds = new DataSet();
            string Llama_PA = "EXEC EXCEL_Genera_Recibo_Dinero_MANAGER_Multiple @id_usuario, @ids_contrato";
            SqlConnection conn = new SqlConnection(connCorretaje);
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(Llama_PA, conn);

            adp.SelectCommand = cmd;

            cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
            cmd.Parameters.AddWithValue("@ids_contrato", ids_contrato);

            adp.Fill(ds);

            return ds;
        }

        public static List<NuevaCuota> TraeInfoCuota(int id_pago)
        {
            List<NuevaCuota> lst = new List<NuevaCuota>();
            string Llama_PA = "EXEC Pagos_Carga_una_Cuota @id_pago";
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
                        lst.Add(new NuevaCuota
                        {
                            id_pago = reader["id_pago"].ToString(),
                            id_contrato = reader["id_contrato"].ToString(),
                            cuota = reader["cuota"].ToString(),
                            mes = reader["mes"].ToString(),
                            concepto = reader["concepto"].ToString(),
                            forma_pago = reader["forma_pago"].ToString(),
                            banco = reader["banco"].ToString(),
                            titular = reader["titular"].ToString(),
                            num_chk_ope = reader["num_chk_ope"].ToString(),
                            monto = reader["monto"].ToString(),
                            fecha_vencimiento = reader["fecha_vencimiento"].ToString(),
                            cheque_protestado = reader["cheque_protestado"].ToString(),
                            fecha_pago = reader["fecha_pago"].ToString(),
                            forma_pago_real = reader["forma_pago_real"].ToString(),
                            num_chk_ope_real = reader["num_chk_ope_real"].ToString(),
                            observacion = reader["observacion"].ToString(),
                            estado = reader["estado"].ToString(),
                            fecha_estado = reader["fecha_estado"].ToString(),
                            rut_titular = reader["rut_titular"].ToString(),
                            com_admin_por = reader["com_admin_por"].ToString(),
                            com_corretaje_por = reader["com_corretaje_por"].ToString(),
                            id_concepto = reader["id_concepto"].ToString(),
                            g_file = reader["g_file"].ToString(),
                            id_prop_arriendo = reader["id_prop_arriendo"].ToString(),
                            mes_cuota = reader["mes_cuota"].ToString(),
                            cta_corriente = reader["cta_corriente"].ToString(),
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<estados> Llama_Pagos_Cambia_Estado_En_Cuadro(int id_pago, int estado, string fecha, int usuario)
        {
            List<estados> lst = new List<estados>();
            string Llama_PA = "exec Pagos_Cambia_Estado_En_Cuadro @id_pago, @estado, @fecha, @usuario";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@usuario", usuario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new estados
                        {
                            estado = reader["estado"].ToString(),
                            mensaje = reader["mensaje"].ToString(),
                            id = int.Parse(reader["id_pago"].ToString())
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<caracteristicas> Llama_Propiedades_Caracteristica_Carga_Lista(int id_usu, int id_propiedad_arriendo, string clase)
        {
            List<caracteristicas> lst = new List<caracteristicas>();
            string Llama_PA = "exec Propiedades_Caracteristica_Carga_Lista @id_usu, @id_propiedad_arriendo, @clase";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_propiedad_arriendo", id_propiedad_arriendo);
                cmd.Parameters.AddWithValue("@clase", clase);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new caracteristicas
                        {
                            id_caracteristica = reader["id_caracteristica"].ToString(),
                            tipo = reader["tipo"].ToString(),
                            observacion = reader["descripcion"].ToString(),
                            g_modelo = reader["g_modelo"].ToString(),
                            g_marca = reader["g_marca"].ToString(),
                            b_garantia = reader["b_garantia"].ToString(),
                            f_mantencion = reader["f_mantencion"].ToString(),
                            f_proxima_mantencion = reader["f_proxima_mantencion"].ToString(),
                            g_clase = reader["g_clase"].ToString(),
                            g_archivo = reader["g_archivo"].ToString(),
                            id_propiedad_caracteristica = reader["id_propiedad_caracteristica"].ToString()

                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }
        public static List<comunidades> Llama_Propiedades_Comunidades(int id_usu, int id_propiedad_arriendo)
        {
            List<comunidades> lst = new List<comunidades>();
            string Llama_PA = "exec Comunidad_Carga_Lista @id_proyecto, @id_usu, @id_prop_arriendo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_proyecto", "0");
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_prop_arriendo", id_propiedad_arriendo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new comunidades
                        {
                            nombre = reader["nombre_comunidad"].ToString(),
                            direccion = reader["direccion"].ToString(),
                            rut = reader["rut"].ToString(),
                            cuenta_bancaria = reader["cuenta_bancaria"].ToString(),
                            tipo_cuenta = reader["tipo_cuenta"].ToString(),
                            banco = reader["banco"].ToString(),
                            correo = reader["correo"].ToString(),
                            fono = reader["telefono"].ToString(),
                            estado = reader["estado"].ToString(),
                            url = reader["url"].ToString(),
                            usuario = reader["usuario"].ToString(),
                            contrasena = reader["contrasena"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }
        public static List<comunidades> Llama_Propiedades_Datos_Comunidades(int id_usu, int id_propiedad_arriendo)
        {
            List<comunidades> lst = new List<comunidades>();
            string Llama_PA = "exec Comunidad_Datos_Carga_Lista @id_proyecto, @id_comunidad, @id_usu, @id_prop_arriendo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_proyecto", "0");
                cmd.Parameters.AddWithValue("@id_comunidad", "0");
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_prop_arriendo", id_propiedad_arriendo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new comunidades
                        {
                            correo = reader["correo"].ToString(),
                            fono = reader["telefono"].ToString(),
                            cargo = reader["tipo_comunidad"].ToString(),
                            estado = reader["estado"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<caracteristicas> Llama_Propiedades_Caracteristica_Elimina_Registro(int id_usu, int id_caracteristica, int id_propiedad_arriendo, string clase)
        {
            string Llama_PA = "exec Propiedades_Caracteristica_Elimina_Registro @id_usu, @id_caracteristica";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_caracteristica", id_caracteristica);
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return Llama_Propiedades_Caracteristica_Carga_Lista(id_usu, id_propiedad_arriendo, clase);
        }

        public static List<caracteristicas> Llama_Propiedades_Caracteristica_Ingresa_Registro_Propiedad(int id_usu, int id_propiedad_arriendo, int c_tipo, string g_descripcion, string modelo, string marca, int garantia, DateTime? fechMan, DateTime? fechProxMan, string g_clase)
        {
            string Llama_PA = "exec Propiedades_Caracteristica_Ingresa_Registro @id_usu, @id_propiedad_arriendo, @c_tipo, @g_descripcion, @g_clase,@g_modelo,@g_marca,@b_garantia,@f_mantencion,@f_proxima_mantencion";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_propiedad_arriendo", id_propiedad_arriendo);
                cmd.Parameters.AddWithValue("@c_tipo", c_tipo);
                cmd.Parameters.AddWithValue("@g_descripcion", g_descripcion);
                cmd.Parameters.AddWithValue("@g_clase", g_clase);
                cmd.Parameters.AddWithValue("@g_modelo", modelo);
                cmd.Parameters.AddWithValue("@g_marca", marca);
                cmd.Parameters.AddWithValue("@b_garantia", garantia);
                cmd.Parameters.AddWithValue("@f_mantencion", fechMan);
                cmd.Parameters.AddWithValue("@f_proxima_mantencion", fechProxMan);
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return Llama_Propiedades_Caracteristica_Carga_Lista(id_usu, id_propiedad_arriendo, g_clase);
        }

        public static List<caracteristicas> Llama_Propiedades_Caracteristica_Ingresa_Registro_Propiedad_Con_Adjunto(int id_usu, int id_propiedad_arriendo, int c_tipo, string g_descripcion, string modelo, string marca, int garantia, DateTime? fechMan, DateTime? fechProxMan, string g_clase, string nombrearchivo)
        {
            string Llama_PA = "exec Propiedades_Caracteristica_Ingresa_Registro_Con_Adjunto @id_usu, @id_propiedad_arriendo, @c_tipo, @g_descripcion, @g_clase,@g_modelo,@g_marca,@b_garantia,@f_mantencion,@f_proxima_mantencion,@g_archivo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_propiedad_arriendo", id_propiedad_arriendo);
                cmd.Parameters.AddWithValue("@c_tipo", c_tipo);
                cmd.Parameters.AddWithValue("@g_descripcion", g_descripcion);
                cmd.Parameters.AddWithValue("@g_clase", g_clase);
                cmd.Parameters.AddWithValue("@g_modelo", modelo);
                cmd.Parameters.AddWithValue("@g_marca", marca);
                cmd.Parameters.AddWithValue("@b_garantia", garantia);
                cmd.Parameters.AddWithValue("@f_mantencion", fechMan);
                cmd.Parameters.AddWithValue("@f_proxima_mantencion", fechProxMan);
                cmd.Parameters.AddWithValue("@g_archivo", nombrearchivo);

                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return Llama_Propiedades_Caracteristica_Carga_Lista(id_usu, id_propiedad_arriendo, g_clase);
        }

        public static List<caracteristicas> Llama_Propiedades_Caracteristica_Ingresa_Registro(int id_usu, int id_propiedad_arriendo, int c_tipo, string g_descripcion, string g_clase)
        {
            string Llama_PA = "exec Propiedades_Caracteristica_Ingresa_Registro_Proyecto @id_usu, @id_propiedad_arriendo, @c_tipo, @g_descripcion, @g_clase";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_propiedad_arriendo", id_propiedad_arriendo);
                cmd.Parameters.AddWithValue("@c_tipo", c_tipo);
                cmd.Parameters.AddWithValue("@g_descripcion", g_descripcion);
                cmd.Parameters.AddWithValue("@g_clase", g_clase);

                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return Llama_Propiedades_Caracteristica_Carga_Lista(id_usu, id_propiedad_arriendo, g_clase);
        }



        //[Propiedades_Calcula_Proporcional_Mes_Inicio] '2017/03/15', 120000
        public static string Llama_Propiedades_Calcula_Proporcional_Mes_Inicio(string FechaInicioContrato, float valorArriendo)
        {
            string ret = "0";
            string Llama_PA = "exec Propiedades_Calcula_Proporcional_Mes_Inicio @FechaInicioContrato, @valorArriendo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@FechaInicioContrato", FechaInicioContrato);
                cmd.Parameters.AddWithValue("@valorArriendo", valorArriendo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ret = reader["fraccionMesInicial"].ToString();
                    }
                }
                conn.Close();
            }
            return ret;
        }

        public static List<ProyYProps> Llama_Carga_Combo_Proyectos(int id_usu)
        {
            List<ProyYProps> lst = new List<ProyYProps>();
            string Llama_PA = "exec Carga_Combo_Proyectos @id_usu";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new ProyYProps
                        {
                            id_pry = reader["id_pry"].ToString(),
                            g_pry = reader["g_pry"].ToString(),
                            id_inmob = reader["id_inmob"].ToString(),
                            g_dir = reader["g_dir"].ToString(),
                            g_num = reader["g_num"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;

        }


        //Agregado Cristobal Alcayaga 16-06-2018
        public static List<ActualizaFechaGasto> Llama_Gastos_Actualiza(int id_descuento, string fecha_gasto, int usuario)
        {
            List<ActualizaFechaGasto> lst = new List<ActualizaFechaGasto>();
            string Llama_PA = "exec Gastos_Actualiza @id_descuento, @fecha_gasto, @usuario";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_descuento", id_descuento);
                cmd.Parameters.AddWithValue("@fecha_gasto", fecha_gasto);
                cmd.Parameters.AddWithValue("@usuario", usuario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new ActualizaFechaGasto
                        {
                            estado = reader["estado"].ToString(),
                            mensaje = reader["mensaje"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static CambiaEstadoPR CambiaEstadoPropiedad_35(int id_usu, int id_contrato, int estado)
        {
            string accion = "";
            var response = new CambiaEstadoPR();
            switch (estado)
            {
                case 0:
                    accion = "G"; break;
                case 10:
                    accion = "N"; break;
                case 20:
                    accion = "R"; break;
                case 30:
                    accion = "D"; break;
                case 35:
                    accion = "PR"; break;
                case 40:
                    accion = "VA"; break;
                case 50:
                    accion = "RA"; break;
                case 60:
                    accion = "OKA"; break;
                case 70:
                    accion = "RF"; break;
                case 80:
                    accion = "OKF"; break;
                case 90:
                    accion = "RG"; break;
                case 100:
                    accion = "OKG"; break;
                case 110:
                    accion = "FC"; break;
                case 120:
                    accion = "ND"; break;
                case 25:
                    accion = "EM"; break;
            }
            string Llama_PA = "EXEC Propiedades_Actualiza_Estado @id_usu, @id_contrato, @accion";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@accion", accion);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    response = new CambiaEstadoPR
                    {
                        mensaje = reader["mensaje"].ToString(),
                        estado = reader["estado"].ToString(),
                        id = reader["id"].ToString(),
                        id_nuevo_contrato = reader["id_nuevo_contrato"].ToString()
                    };
                }
                conn.Close();
            }

            return response;
        }

        public static ResHabilitarCheck Llama_Finiquitos_Habilita_Check(int id_usu, string check)
        {
            var resp = new ResHabilitarCheck();

            string Llama_PA = "EXEC Finiquitos_Habilita_Check @id_usu, @check";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@check", check);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resp = new ResHabilitarCheck
                    {
                        mensaje = reader["mensaje"].ToString(),
                        estado = reader["estado"].ToString(),
                    };
                }
                conn.Close();
            }

            return resp;
        }

        public static ConsultaConsumo Llama_ConsultaConsumo(string id_servicio, string id_cliente)
        {
            var resp = new ConsultaConsumo();

            string Llama_PA = "EXEC RBT_Consulta_Consumo @id_servicio, @id_cliente";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_servicio", id_servicio);
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resp = new ConsultaConsumo
                    {
                        direccion = reader["direccion"].ToString(),
                        estado = reader["estado"].ToString(),
                        fecha_consulta = reader["fecha_consulta"].ToString(),
                        fecha_corte = reader["fecha_corte"].ToString(),
                        fecha_ult_pago = reader["fecha_ult_pago"].ToString(),
                        fecha_vencimiento = reader["fecha_vencimiento"].ToString(),
                        monto_ult_pago = reader["monto_ult_pago"].ToString(),
                        numero_cliente = reader["numero_cliente"].ToString(),
                        total_a_pagar = reader["total_a_pagar"].ToString()
                    };
                }
                conn.Close();
            }

            return resp;
        }

        public static List<HistorialPagoConsumo> Llama_HistorialPagos(int id_usuario, string id_contrato)
        {
            var resp = new List<HistorialPagoConsumo>();

            string Llama_PA = "EXEC Pagos_Historial @id_usuario, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resp.Add(new HistorialPagoConsumo
                    {
                        banco = reader["banco"].ToString(),
                        cheque = reader["cheque"].ToString(),
                        concepto = reader["concepto"].ToString(),
                        direccion = reader["direccion"].ToString(),
                        estado = reader["estado"].ToString(),
                        fecha_vencimiento = reader["fecha_vencimiento"].ToString(),
                        fec_pago = reader["fec_pago"].ToString(),
                        fec_vcto = reader["fec_vcto"].ToString(),
                        forma_pago = reader["forma_pago"].ToString(),
                        id_contrato = reader["id_contrato"].ToString(),
                        id_prop = reader["id_prop"].ToString(),
                        inicio_contrato = reader["inicio_contrato"].ToString(),
                        mora = reader["mora"].ToString(),
                        rut_titular = reader["rut_titular"].ToString(),
                        termino_contrato = reader["termino_contrato"].ToString(),
                        titular_cheque = reader["titular_cheque"].ToString()
                    });
                }
                conn.Close();
            }

            return resp;
        }

        public static List<HistorialEstado> Llama_HistorialEstados(int id_usuario, string id_propiedad)
        {
            var resp = new List<HistorialEstado>();

            string Llama_PA = "EXEC Gestion_Propiedades_Estado @id_prop";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_prop", id_propiedad);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resp.Add(new HistorialEstado
                    {
                        direccion = reader["direccion"].ToString(),
                        f_estado = reader["f_estado"].ToString(),
                        g_f_estado = reader["g_f_estado"].ToString(),
                        g_estado = reader["g_estado"].ToString(),
                        g_nom_pry = reader["g_nom_pry"].ToString(),
                        id_estado = reader["id_estado"].ToString(),
                        id_prop = reader["id_prop"].ToString(),
                        id_pry = reader["id_pry"].ToString(),
                        numero = reader["numero"].ToString(),
                        num_depto = reader["num_depto"].ToString(),
                        usuario = reader["usuario"].ToString()
                    });
                }
                conn.Close();
            }

            return resp;
        }

        public static MercadoParametros Llama_MercadoParametros(int id_usuario, string id_prop)
        {
            var resp = new MercadoParametros();

            string Llama_PA = "EXEC Propiedades_Mercado_Parametros @id_usuario, @id_prop";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resp = new MercadoParametros
                    {
                        banosSP = reader["banosSP"].ToString(),
                        comunaSP = reader["comunaSP"].ToString(),
                        dormitoriosSP = reader["dormitoriosSP"].ToString(),
                        proc = reader["proc"].ToString(),
                        regionSP = reader["regionSP"].ToString(),
                        tipo_negociosp = reader["tipo_negociosp"].ToString(),
                        tipo_propiedadSP = reader["tipo_propiedadSP"].ToString(),
                        xexp = reader["xexp"].ToString(),
                        xini = reader["xini"].ToString(),
                        yexp = reader["yexp"].ToString(),
                        yini = reader["yini"].ToString()
                    };
                }
                conn.Close();
            }

            return resp;
        }

        public static MercadoConsulta Llama_MercadoConsulta(int usuario, string id_prop, string cantidad, string promedio, string minimo, string maximo, string dev_estandar, string var_estandar,
            string sup_total_prom)
        {
            var resp = new MercadoConsulta();

            string Llama_PA = "EXEC Propiedades_Mercado_Consulta @usuario, @id_prop, @cantidad, @promedio, @minimo, @maximo, @dev_estandar, @var_estandar, @sup_total_prom";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@promedio", promedio ?? "0");
                cmd.Parameters.AddWithValue("@minimo", minimo ?? "0");
                cmd.Parameters.AddWithValue("@maximo", maximo ?? "0");
                cmd.Parameters.AddWithValue("@dev_estandar", dev_estandar ?? "0");
                cmd.Parameters.AddWithValue("@var_estandar", var_estandar ?? "0");
                cmd.Parameters.AddWithValue("@sup_total_prom", sup_total_prom ?? "0");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resp = new MercadoConsulta
                    {
                        valor_arr_max_pe = reader["valor_arr_max_pe"].ToString(),
                        valor_arr_max_uf = reader["valor_arr_max_uf"].ToString(),
                        valor_arr_min_pe = reader["valor_arr_min_pe"].ToString(),
                        valor_arr_min_uf = reader["valor_arr_min_uf"].ToString(),
                        valor_arr_prom_pe = reader["valor_arr_prom_pe"].ToString(),
                        valor_arr_prom_uf = reader["valor_arr_prom_uf"].ToString(),
                        valor_desv_estandar = reader["valor_desv_estandar"].ToString(),
                        valor_m2_desv_estandar = reader["valor_m2_desv_estandar"].ToString(),
                        valor_m2_max = reader["valor_m2_max"].ToString(),
                        valor_m2_minimo = reader["valor_m2_minimo"].ToString(),
                        valor_m2_prom = reader["valor_m2_prom"].ToString(),
                        valor_max = reader["valor_max"].ToString(),
                        valor_minimo = reader["valor_minimo"].ToString(),
                        valor_prom = reader["valor_prom"].ToString()
                    };
                }
                conn.Close();
            }

            return resp;
        }

        public static List<ReciboDineroHeaderNew> Llama_ReciboDinero_Header(int id_usu, int id_contrato)
        {
            List<ReciboDineroHeaderNew> lst = new List<ReciboDineroHeaderNew>();
            string Llama_PA = "EXEC Propiedades_Genera_Recibo_Header @id_usu, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new ReciboDineroHeaderNew
                        {
                            descripcion = reader["descripcion"].ToString(),
                            valor = reader["valor"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }


        public static List<ReciboDineroDetalle> Llama_ReciboDinero_Detalle(int id_usu, int id_contrato)
        {
            List<ReciboDineroDetalle> lst = new List<ReciboDineroDetalle>();
            string Llama_PA = "EXEC Propiedades_Genera_Recibo_Detalle @id_usu, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new ReciboDineroDetalle
                        {
                            banco = reader["banco"].ToString(),
                            concepto = reader["concepto"].ToString(),
                            fecha_vcto = reader["fecha_vcto"].ToString(),
                            fecha_vencimiento = reader["fecha_vencimiento"].ToString(),
                            forma_pago = reader["forma_pago"].ToString(),
                            monto = reader["monto"].ToString(),
                            nombre_titular = reader["nombre_titular"].ToString(),
                            n_doc_ope = reader["n_doc_ope"].ToString(),
                            rut_titular = reader["rut_titular"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<HeaderExcelFormato> Llama_GeneraExcelHeader(int idUsuario, string sistema, string grilla, int id_proyecto, int id_tipologia, int id_disponibilidad,
            int id_ejecutivo, int id_estado, string periodo, int n_ven_con)
        {
            List<HeaderExcelFormato> lst = new List<HeaderExcelFormato>();
            string Llama_PA = "EXEC EXCEL_Genera @id_usu, 0 , @sistema, @grilla, @id_proyecto, @id_tipologia, @id_disponibilidad, @id_ejecutivo, @id_estado, @periodo, @n_ven_con";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", idUsuario);
                cmd.Parameters.AddWithValue("@sistema", sistema);
                cmd.Parameters.AddWithValue("@grilla", grilla);
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                cmd.Parameters.AddWithValue("@id_tipologia", id_tipologia);
                cmd.Parameters.AddWithValue("@id_disponibilidad", id_disponibilidad);
                cmd.Parameters.AddWithValue("@id_ejecutivo", id_ejecutivo);
                cmd.Parameters.AddWithValue("@id_estado", id_estado);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cmd.Parameters.AddWithValue("@n_ven_con", n_ven_con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new HeaderExcelFormato
                        {
                            id = (int)reader["ID"],
                            nombre = reader["Nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static DataSet Llama_GeneraExcelPagoOnLine(int idUsuario, int idFormato, string sistema, string grilla, int empresa, int tipoCon, DateTime fechaCon, DateTime fechaIni, DateTime fechaFin)
        {
            DataSet ds = new DataSet();
            //List<HeaderExcelFormato> lst = new List<HeaderExcelFormato>();
            //string Llama_PA = "EXEC  @id_usu, @tipo , @sistema, @grilla, @id_proyecto, @id_tipologia, @id_disponibilidad, @id_ejecutivo, @id_estado, @periodo, @n_ven_con, @sac_inversionista, @FechaPagoIni, @FechaPagoFin";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand("EXCEL_Genera_PagoOnLine", conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", idUsuario);
                cmd.Parameters.AddWithValue("@id_formato", idFormato);
                cmd.Parameters.AddWithValue("@sistema", sistema);
                cmd.Parameters.AddWithValue("@grilla", grilla);
                cmd.Parameters.AddWithValue("@id_empresa", empresa);
                cmd.Parameters.AddWithValue("@tipo_Consulta", tipoCon);
                cmd.Parameters.AddWithValue("@fecha_contable", fechaCon);
                cmd.Parameters.AddWithValue("@FechaPagoIni", fechaIni);
                cmd.Parameters.AddWithValue("@FechaPagoFin", fechaFin);
                conn.Open();

                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(ds);
            }
            return ds;
        }


        public static DataSet Llama_GeneraExcelPagoOnLineConc(int idUsuario, int idFormato, string sistema, string grilla, string FechaContable)
        {
            DataSet ds = new DataSet();
            //List<HeaderExcelFormato> lst = new List<HeaderExcelFormato>();
            //string Llama_PA = "EXEC  @id_usu, @tipo , @sistema, @grilla, @id_proyecto, @id_tipologia, @id_disponibilidad, @id_ejecutivo, @id_estado, @periodo, @n_ven_con, @sac_inversionista, @FechaPagoIni, @FechaPagoFin";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand("EXCEL_Genera_PagoOnLine", conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", idUsuario);
                cmd.Parameters.AddWithValue("@id_formato", idFormato);
                cmd.Parameters.AddWithValue("@sistema", sistema);
                cmd.Parameters.AddWithValue("@grilla", grilla);
                cmd.Parameters.AddWithValue("@fecha_contable", FechaContable);
                conn.Open();

                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(ds);
            }
            return ds;
        }

        public static DataSet Llama_GeneraExcel(int idUsuario, int tipo, string sistema, string grilla, int id_proyecto, int id_tipologia, int id_disponibilidad,
            int id_ejecutivo, int id_estado, string periodo, int n_ven_con, int sac_inversionista, DateTime? fechaIni, DateTime? fechaFin, int? id_estado_arriendo
            , int? id_estado_propietario, string etapa, int tipo_arriendo)
        {
            DataSet ds = new DataSet();
            //List<HeaderExcelFormato> lst = new List<HeaderExcelFormato>();
            //string Llama_PA = "EXEC  @id_usu, @tipo , @sistema, @grilla, @id_proyecto, @id_tipologia, @id_disponibilidad, @id_ejecutivo, @id_estado, @periodo, @n_ven_con, @sac_inversionista, @FechaPagoIni, @FechaPagoFin";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand("EXCEL_Genera", conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", idUsuario);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@sistema", sistema);
                cmd.Parameters.AddWithValue("@grilla", grilla);
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                cmd.Parameters.AddWithValue("@id_tipologia", id_tipologia);
                cmd.Parameters.AddWithValue("@id_disponibilidad", id_disponibilidad);
                cmd.Parameters.AddWithValue("@id_ejecutivo", id_ejecutivo);
                cmd.Parameters.AddWithValue("@id_estado", id_estado);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cmd.Parameters.AddWithValue("@n_ven_con", n_ven_con);
                cmd.Parameters.AddWithValue("@sac_inversionista", sac_inversionista);
                cmd.Parameters.AddWithValue("@tipo_arriendo", tipo_arriendo);
                if (fechaIni != null) cmd.Parameters.AddWithValue("@FechaPagoIni", fechaIni);
                if (fechaFin != null) cmd.Parameters.AddWithValue("@FechaPagoFin", fechaFin);
                if (id_estado_arriendo != null) cmd.Parameters.AddWithValue("@id_estado_arriendo", id_estado_arriendo);
                if (id_estado_propietario != null) cmd.Parameters.AddWithValue("@id_estado_propietario", id_estado_propietario);
                cmd.Parameters.AddWithValue("@desc_etapa", etapa);
                conn.Open();

                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(ds);
            }
            return ds;
        }

        public static DataSet Llama_GeneraExcelInterfazCobro(int idUsuario, string sistema, string grilla, int idFormato, DateTime? fechaIni, DateTime? fechaFin)
        {
            DataSet ds = new DataSet();
            //List<HeaderExcelFormato> lst = new List<HeaderExcelFormato>();
            //string Llama_PA = "EXEC  @id_usu, @tipo , @sistema, @grilla, @id_proyecto, @id_tipologia, @id_disponibilidad, @id_ejecutivo, @id_estado, @periodo, @n_ven_con, @sac_inversionista, @FechaPagoIni, @FechaPagoFin";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand("EXCEL_Genera_Interfaz_Cobros", conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", idUsuario);
                cmd.Parameters.AddWithValue("@tipo", idFormato);
                cmd.Parameters.AddWithValue("@sistema", sistema);
                cmd.Parameters.AddWithValue("@grilla", grilla);
                //cmd.Parameters.AddWithValue("@formato", idFormato);                
                if (fechaIni != null) cmd.Parameters.AddWithValue("@f_cobrosdesde", fechaIni);
                if (fechaFin != null) cmd.Parameters.AddWithValue("@f_cobroshasta", fechaFin);
                conn.Open();

                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(ds);
            }
            return ds;
        }


        public static bool RegistrarArchivoDBResuelto(int id_usu, int id_prop, string fecha_ing, int c_tipo, string descrip, bool resuelto, string fecha_act, string nombre_archivo)
        {
            string Llama_PA = "EXEC Catalogo_Ingresa_Registro_Reparos @id_usu, @id_prop, @fecha_ing, @c_tipo, @descrip, @id_estado, @fecha_act, @archivo";
            if (fecha_act == "")
            {
                fecha_act = "1900-01-01";
            }
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);
                cmd.Parameters.AddWithValue("@fecha_ing", Convert.ToDateTime(fecha_ing));
                cmd.Parameters.AddWithValue("@c_tipo", c_tipo);
                cmd.Parameters.AddWithValue("@descrip", descrip);
                cmd.Parameters.AddWithValue("@id_estado", resuelto ? 1 : 0);
                cmd.Parameters.AddWithValue("@fecha_act", Convert.ToDateTime(fecha_act));
                cmd.Parameters.AddWithValue("@archivo", nombre_archivo);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public static bool Llama_ActualizaReparacion(int usuario, int id_catalogo, string fecha_act, int c_estado, string g_archivo2, int tipo_archivo, string g_archivo)
        {
            bool response = false;
            string Llama_PA = "EXEC Catalogo_Actualiza_Registro_Reparos @id_usu, @id_catalogo, @fecha_act, @c_estado, @g_archivo2, @tipo_archivo, @g_archivo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", usuario);
                cmd.Parameters.AddWithValue("@id_catalogo", id_catalogo);
                cmd.Parameters.AddWithValue("@fecha_act", Convert.ToDateTime(fecha_act));
                cmd.Parameters.AddWithValue("@c_estado", c_estado);
                cmd.Parameters.AddWithValue("@g_archivo2", g_archivo2);
                cmd.Parameters.AddWithValue("@tipo_archivo", tipo_archivo);
                cmd.Parameters.AddWithValue("@g_archivo", g_archivo);
                conn.Open();

                cmd.ExecuteNonQuery();
                response = true;
            }
            return response;
        }

        public static List<DatosNuevaPropiedad> Llama_Propiedades_Cambia_Propietario(int id_usu, int id_prop_arriendo, int id_contrato, int rut1, int rut2, int tipo_cliente, string f_desde, string f_primer_mes, string por_com_1, string por_com_2, string por_coloc)
        {
            List<DatosNuevaPropiedad> lst = new List<DatosNuevaPropiedad>();
            string Llama_PA = "EXEC Propiedades_Cambia_Propietario @id_usu, @id_prop_arriendo, @id_contrato, @rut_cliente1, @rut_cliente2, @tipo_cliente, @f_desde, @f_primer_mes, @por_com_1, @por_com_2, @por_coloc";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_prop_arriendo", id_prop_arriendo);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@rut_cliente1", rut1);
                cmd.Parameters.AddWithValue("@rut_cliente2", rut2);
                cmd.Parameters.AddWithValue("@tipo_cliente", tipo_cliente);
                cmd.Parameters.AddWithValue("@f_desde", f_desde);
                cmd.Parameters.AddWithValue("@f_primer_mes", f_primer_mes);
                cmd.Parameters.AddWithValue("@por_com_1", por_com_1);
                cmd.Parameters.AddWithValue("@por_com_2", por_com_2);
                cmd.Parameters.AddWithValue("@por_coloc", por_coloc);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new DatosNuevaPropiedad
                        {
                            id_prop = int.Parse(reader["id_prop"].ToString()),
                            id_contrato = int.Parse(reader["id_contrato"].ToString()),
                            estado = int.Parse(reader["estado"].ToString()),
                            mensaje = reader["mensaje"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<DatosGGCC> Llama_Propiedades_Carga_GGCC(int id_pry)
        {
            List<DatosGGCC> lst = new List<DatosGGCC>();
            string Llama_PA = "EXEC Propiedades_Carga_GGCC @id_pry";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_pry", id_pry);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new DatosGGCC
                        {
                            ggcc_nombre = reader["ggcc_nombre"].ToString(),
                            ggcc_cta_deposito = reader["ggcc_cta_deposito"].ToString(),
                            ggcc_banco = int.Parse(reader["ggcc_banco"].ToString()),
                            ggcc_rut = reader["ggcc_rut"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<ticket> Llama_Devoluciones_Ticket_GGGG(int proc, int id_devol_ticket, int id_propiedad, int id_contrato, string observacion, int id_usu)
        {
            List<ticket> lst = new List<ticket>();
            string Llama_PA = "exec Devoluciones_Ticket_GGGG @proc,@id_devol_ticket,@id_propiedad,@id_contrato,@observacion,@id_usu";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@proc", proc);
                cmd.Parameters.AddWithValue("@id_devol_ticket", id_devol_ticket);
                cmd.Parameters.AddWithValue("@id_propiedad", id_propiedad);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@id_usu", id_usu);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new ticket
                        {
                            id_ticket = reader["id"].ToString(),
                            id_propiedad = reader["id_propiedad"].ToString(),
                            id_contrato = reader["id_contrato"].ToString(),
                            observacion = reader["observacion"].ToString(),
                            f_creacion = reader["f_creacion"].ToString(),
                            id_usu = reader["id_usu"].ToString(),
                            mensaje = reader["mensaje"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<Datos_Correo> Llama_TOOLS_Obtener_Datos_Cliente(int tipo_cliente, int id_contrato = 0, int id_propiedad = 0, int rut = 0)
        {
            List<Datos_Correo> lst = new List<Datos_Correo>();
            string Llama_PA = "EXEC TOOLS_Obtener_Datos_Cliente @tipo_cliente, @id_contrato,@id_propiedad,@rut";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@tipo_cliente", tipo_cliente);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@id_propiedad", id_propiedad);
                cmd.Parameters.AddWithValue("@rut", rut);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new Datos_Correo
                        {
                            mail_cliente = reader["mail_cliente"].ToString(),
                            nombre_cliente = reader["nombre_cliente"].ToString(),
                            tipo_cliente = reader["tipo_cliente"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;

        }


        public static List<ArchivoFiniquito> CargaArchivosFiniquito_con_ticket(int idUsuario, int idContrato, string tipo, int ticket)
        {
            List<ArchivoFiniquito> lst = new List<ArchivoFiniquito>();
            string Llama_PA = "";
            if (tipo == "FINIQUITO") Llama_PA = "EXEC Catalogo_Carga_Lista_Finiquito @usuario, 0, @tipo , 0, @idContrato";
            else if (tipo == "REPAROS") Llama_PA = "EXEC Catalogo_Carga_Lista @usuario, @idContrato, @tipo , 0, 0";
            else Llama_PA = "EXEC Catalogo_Carga_Lista @usuario, 0, @tipo , 0, @idContrato"; // ";

            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@usuario", idUsuario);
                cmd.Parameters.AddWithValue("@idContrato", idContrato);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                // cmd.Parameters.AddWithValue("@id_ticket", ticket);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (tipo != "REPAROS")
                        {
                            lst.Add(new ArchivoFiniquito
                            {
                                id_catalogo = reader["id_catalogo"].ToString(),
                                c_tipo = reader["c_tipo"].ToString(),
                                tipo = reader["tipo"].ToString(),
                                descripcion = reader["descripcion"].ToString(),
                                f_ini_per = reader["f_ini_per"].ToString(),
                                f_ter_per = reader["f_ter_per"].ToString(),
                                m_monto = reader["m_monto"].ToString(),
                                archivo = reader["archivo"].ToString(),
                                estado = reader["estado"].ToString()
                            });
                        }
                        else
                        {
                            lst.Add(new ArchivoFiniquito
                            {
                                id_catalogo = reader["id_catalogo"].ToString(),
                                f_ini_per = ((DateTime)reader["f_ing"]).ToString("dd-MM-yyyy"),
                                c_tipo = reader["c_tipo"].ToString(),
                                tipo = reader["tipo"].ToString(),
                                descripcion = reader["descripcion"].ToString(),
                                estado = reader["estado"].ToString(),
                                f_ter_per = ((DateTime)reader["f_act"]).ToString("dd-MM-yyyy"),
                                archivo = reader["archivo"].ToString(),
                                archivo2 = reader["archivo2"].ToString()
                            });
                        }
                    }
                }
                conn.Close();
            }
            if (tipo != "REPAROS")
            {
                if (tipo == "DEVOLUCION") return lst.Where(a => a.c_tipo == "55" || a.c_tipo == "56" || a.c_tipo == "57" || a.c_tipo == "58" || a.c_tipo == "82").ToList();
                else return lst.Where(a => a.c_tipo == "26" || a.c_tipo == "27" || a.c_tipo == "28" || a.c_tipo == "29" || a.c_tipo == "30" || a.c_tipo == "59" || a.c_tipo == "81").ToList();
            }
            else return lst;
        }

        public static List<ResultadoEnvioMail> Llama_Mail_Envia_Archivo(string nombre_destinatario, string mail_destinatario, int id_archivo, int tipo_cliente, int id_usu)
        {
            List<ResultadoEnvioMail> res = new List<ResultadoEnvioMail>();

            string Llama_PA = "EXEC Mail_Envia_Archivo @nombre_destinatario, @mail_destinatario, @id_archivo, @tipo_cliente, @id_usu";
            try
            {
                using (SqlConnection conn = new SqlConnection(connCorretaje))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Llama_PA, conn);    
                cmd.CommandTimeout = sqlTimeout;
                    cmd.Parameters.AddWithValue("@nombre_destinatario", nombre_destinatario);
                    cmd.Parameters.AddWithValue("@mail_destinatario", mail_destinatario);
                    cmd.Parameters.AddWithValue("@id_archivo", id_archivo);
                    cmd.Parameters.AddWithValue("@tipo_cliente", tipo_cliente);
                    cmd.Parameters.AddWithValue("@id_usu", id_usu);
                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                }
                res.Add(new ResultadoEnvioMail
                {
                    estado = "true",
                    mensaje = "Mail enviado a " + mail_destinatario,
                });
                return res;
            }
            catch (Exception ex)
            {
                res.Add(new ResultadoEnvioMail
                {
                    estado = "false",
                    mensaje = ex.ToString(),
                });
                return res;
            }

        }
        public static List<ok_op> Llama_Propiedades_OK_Arriendo_Operaciones(int id_usu, string f_okop, int b_okop, int id_contrato)
        {
            List<ok_op> lst = new List<ok_op>();
            string Llama_PA = "EXEC Propiedades_OK_Arriendo_Operaciones @id_usu, @f_okop, @b_okop, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@f_okop", f_okop);
                cmd.Parameters.AddWithValue("@b_okop", b_okop);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return lst;
        }
        public static Response CambiaEstado_NoDisponible(int id_usu, int id_contrato, string mensaje = "")
        {
            var response = new Response();
            string Llama_PA = "EXEC Propiedades_Cambia_Estado_No_Disponible @id_usu, @id_contrato, @mensaje";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@mensaje", mensaje);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    response = new Response
                    {
                        Mensaje = reader["mensaje"].ToString(),
                        EsValido = reader["estado"].ToString() == "true" ? true : false
                    };
                }
                conn.Close();
            }

            return response;
        }
        public static bool Enviar_Mail_Disponible(int id_usuario, int id_prop_arriendo, int id_contrato)
        {
            var response = false;
            string Llama_PA = "EXEC Mail_Envia_Alerta_Disponible @id_usuario, @id_prop_arriendo, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@id_prop_arriendo", id_prop_arriendo);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                SqlDataReader reader = cmd.ExecuteReader();
                response = true;
                conn.Close();
            }
            return response;
        }

        public static List<Prop_Contratos_Cliente> Llama_Propiedades_Carga_Contratos(int id_prop)
        {
            List<Prop_Contratos_Cliente> lst = new List<Prop_Contratos_Cliente>();
            string Llama_PA = "EXEC Propiedades_Carga_Contratos @id_prop";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_prop", id_prop);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new Prop_Contratos_Cliente
                        {
                            numero_registro = reader["numero_registro"].ToString(),
                            n_contrato = reader["n_contrato"].ToString(),
                            contrato_anterior = reader["contrato_anterior"].ToString(),
                            id_prop = reader["id_prop"].ToString(),
                            arrendatario = reader["arrendatario"].ToString(),
                            rut_arrendatario = reader["rut_arrendatario"].ToString(),
                            inicio_contrato = reader["inicio_contrato"].ToString(),
                            termino_contrato = reader["termino_contrato"].ToString(),
                            fecha_renovacion = reader["fecha_renovacion"].ToString(),
                            g_estado_contrato = reader["g_estado_contrato"].ToString(),
                            renovado = reader["renovado"].ToString(),
                            g_estado_propiedad = reader["g_estado_propiedad"].ToString(),
                            id_estado_propiedad = reader["id_estado_propiedad"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }
        public static List<elimina_contrato> Eliminar_Contrato(int proc, int id_contrato, int id_usuario)
        {
            List<elimina_contrato> lst = new List<elimina_contrato>();
            string Llama_PA = "EXEC Propiedades_Elimina_Contrato @proc,@id_contrato,@id_usuario";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@proc", proc);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new elimina_contrato
                        {
                            estado = reader["estado"].ToString(),
                            mensaje = reader["mensaje"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static List<IngresosDineroArrendatario> Ingresos_Dinero_Cliente(int id_usuario, int rut, int id_contrato) //Trae una propiedad
        {
            List<IngresosDineroArrendatario> lst = new List<IngresosDineroArrendatario>();
            string Llama_PA = "EXEC Pagos_Lista_Ingresos_Arrendatario_V2 @id_usu, @rut, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@rut", rut);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new IngresosDineroArrendatario
                        {
                            id_ing = reader["id_ing"].ToString(),
                            id_tipo = reader["id_tipo"].ToString(),
                            g_tipo = reader["g_tipo"].ToString(),
                            f_fecha = reader["f_fecha"].ToString(),
                            v_monto = reader["v_monto"].ToString(),
                            id_forma_pago = reader["id_forma_pago"].ToString(),
                            g_forma_pago = reader["g_forma_pago"].ToString(),
                            id_estado = reader["id_estado"].ToString(),
                            g_estado = reader["g_estado"].ToString(),
                            g_observacion = reader["g_observacion"].ToString(),
                            id_contrato = reader["id_contrato"].ToString(),
                            g_nombre = reader["g_nombre"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }



        public static bool Llama_Pagos_Ingresa2(int id_contrato, string mes, int id_concepto, float monto, string fecha_vencimiento, string fecha_pago, int id_fpago, int id_banco, string g_titular, string num_chk_ope,
            string g_rut_titular, int estado, string observacion, float com_admin_por, int proc, string concepto, int id_usu, int? id_pago_antiguo)
        {
            string Llama_PA = "EXEC Pagos_Ingresa2 @id_contrato,@mes,@id_concepto,@monto,@fecha_vencimiento,@fecha_pago,@id_fpago,@id_banco,@g_titular,@num_chk_ope,@g_rut_titular,@estado,@observacion,@com_admin_por,@proc,@concepto,@id_usu,@id_pago_antiguo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@id_concepto", id_concepto);
                cmd.Parameters.AddWithValue("@monto", monto);
                cmd.Parameters.AddWithValue("@fecha_vencimiento", fecha_vencimiento);
                cmd.Parameters.AddWithValue("@fecha_pago", fecha_pago);
                cmd.Parameters.AddWithValue("@id_fpago", id_fpago);
                cmd.Parameters.AddWithValue("@id_banco", id_banco);
                cmd.Parameters.AddWithValue("@g_titular", g_titular);
                cmd.Parameters.AddWithValue("@num_chk_ope", num_chk_ope);
                cmd.Parameters.AddWithValue("@g_rut_titular", g_rut_titular);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@com_admin_por", com_admin_por);
                cmd.Parameters.AddWithValue("@proc", proc);
                cmd.Parameters.AddWithValue("@concepto", concepto);
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_pago_antiguo", id_pago_antiguo);

                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }
        public static DataSet Llama_GeneraExcel_devoluciones(int idUsuario, int tipo, string sistema, string grilla, int id_proyecto, int id_tipologia, int id_disponibilidad,
            int id_ejecutivo, int id_estado, string periodo, int n_ven_con, int sac_inversionista, string fechaIni, string fechaFin, int? id_estado_arriendo
            , int? id_estado_propietario, string etapa, int? id_lote, string ldi_ilp, int motivo_excel_finiquito = 0)
        {
            DataSet ds = new DataSet();
            //List<HeaderExcelFormato> lst = new List<HeaderExcelFormato>();
            //string Llama_PA = "EXEC  @id_usu, @tipo , @sistema, @grilla, @id_proyecto, @id_tipologia, @id_disponibilidad, @id_ejecutivo, @id_estado, @periodo, @n_ven_con, @sac_inversionista, @FechaPagoIni, @FechaPagoFin";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand("EXCEL_Genera", conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", idUsuario);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@sistema", sistema);
                cmd.Parameters.AddWithValue("@grilla", grilla);
                cmd.Parameters.AddWithValue("@id_proyecto", id_proyecto);
                cmd.Parameters.AddWithValue("@id_tipologia", id_tipologia);
                cmd.Parameters.AddWithValue("@id_disponibilidad", id_disponibilidad);
                cmd.Parameters.AddWithValue("@id_ejecutivo", id_ejecutivo);
                cmd.Parameters.AddWithValue("@id_estado", id_estado);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cmd.Parameters.AddWithValue("@n_ven_con", n_ven_con);
                cmd.Parameters.AddWithValue("@sac_inversionista", sac_inversionista);
                cmd.Parameters.AddWithValue("@FechaPagoIni", fechaIni);
                if (fechaFin != null) cmd.Parameters.AddWithValue("@FechaPagoFin", fechaFin);
                if (id_estado_arriendo != null) cmd.Parameters.AddWithValue("@id_estado_arriendo", id_estado_arriendo);
                if (id_estado_propietario != null) cmd.Parameters.AddWithValue("@id_estado_propietario", id_estado_propietario);
                cmd.Parameters.AddWithValue("@desc_etapa", etapa);
                cmd.Parameters.AddWithValue("@id_lote", id_lote);
                cmd.Parameters.AddWithValue("@ldi_ilp", ldi_ilp);
                cmd.Parameters.AddWithValue("@motivo", motivo_excel_finiquito);

                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(ds);
            }
            return ds;
        }

        public static List<Observacion> Pago_Cuadro_Pago_Observaciones(int id_usu, int id_pago, int proc, int id_propiedad, int id_contrato, string g_comentario = "")
        {
            var lst = new List<Observacion>();
            string SP = "Observaciones_Pagos_Cuadro_Pago";

            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(SP, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                cmd.Parameters.AddWithValue("@proc", proc);
                cmd.Parameters.AddWithValue("@id_propiedad", id_propiedad);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@g_comentario", g_comentario);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    lst = reader.ToList<Observacion>();
                }
            }
            return lst;
        }

        public static bool Enviar_Mail_Val_Arriendo(int id_usuario, int id_prop_arriendo, int id_contrato)
        {
            var response = false;
            string Llama_PA = "EXEC Mail_Envia_Alerta_Validacion_Arriendo @id_usuario, @id_prop_arriendo, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@id_prop_arriendo", id_prop_arriendo);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                SqlDataReader reader = cmd.ExecuteReader();
                response = true;
                conn.Close();
            }
            return response;
        }

        public static bool Llama_Propiedades_Actualiza_Folio(int id_uduario, int id_prop, int id_cont, string folio)
        {
            string Llama_PA = "EXEC Propiedades_Actualiza_Folio @id_uduario, @id_prop, @id_cont, @folio";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_uduario", id_uduario);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);
                cmd.Parameters.AddWithValue("@id_cont", id_cont);
                cmd.Parameters.AddWithValue("@folio", folio);
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }

        public static List<elimina_contrato> Enviar_Firmar(int id_usuario, int id_prop, int id_contrato)
        {
            Int32 idSignTrx = 0;
            List<elimina_contrato> lst = new List<elimina_contrato>();
            string Llama_PA = "Propiedades_Enviar_Firmar";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new elimina_contrato
                        {
                            mensaje = reader["mensaje"].ToString()
                        });
                        idSignTrx = Convert.ToInt32(reader["id"]);
                    }
                }
            }

            if (idSignTrx > 0)
            {
                ProxyRestServices oProxy = new ProxyRestServices();



                SignTransacctionDetails oSignDetails = new SignTransacctionDetails { IdSignTransacction = idSignTrx };

                IList<SignTransacctionDetails> oListFirmantes = null;

                using (HttpResponseMessage resp = oProxy.CallService(Constant.UrlFirmaDigital + "SignTransacctionDetails/Find", Constant.Verbs.POST, oSignDetails, null))
                {
                    oListFirmantes = JsonConvert.DeserializeObject<IList<SignTransacctionDetails>>(resp.Content.ReadAsStringAsync().Result);
                }

                if (oListFirmantes != null && oListFirmantes.Count > 0)
                {

                    foreach (SignTransacctionDetails oTrxDetails in oListFirmantes)
                    {
                        Registration oRegFirmante = new Registration
                        {

                            RutUsuario = oTrxDetails.Rut,
                            Nombre = oTrxDetails.Nombre.Length > 20 ? oTrxDetails.Nombre.Substring(0, 20) : oTrxDetails.Nombre,
                            ApellidoPaterno = oTrxDetails.ApellidoPaterno,
                            ApellidoMaterno = oTrxDetails.ApellidoMaterno,
                            Email = oTrxDetails.CorreoNotificacion,
                            TipoFirma = oTrxDetails.IdTipoFirma.Value,
                            CantidadDoctos = oTrxDetails.NumDoc
                        };

                        //Registrar Firmantes en ecert
                        using (HttpResponseMessage resp = oProxy.CallService(Constant.UrlFirmaDigital + "FirmaElectronica/RegUser", Constant.Verbs.POST, oRegFirmante, null))
                        {
                            ResultRegistration oResultReg = JsonConvert.DeserializeObject<ResultRegistration>(resp.Content.ReadAsStringAsync().Result);
                            oTrxDetails.IdUsuarioCertificadora = oResultReg.IdUsuario;
                            oTrxDetails.UrlNotificacion = oResultReg.UrlLogin;
                        }

                        if (oTrxDetails.PrioridadFirma == 1)
                        {
                            NotificationSing oNotify = new NotificationSing
                            {
                                IdUsuario = oTrxDetails.IdUsuarioCertificadora.Value.ToString(),
                                RutUsuario = oTrxDetails.Rut
                            };
                            //Notificar Firmante inicial
                            using (HttpResponseMessage resp = oProxy.CallService(Constant.UrlFirmaDigital + "FirmaElectronica/NotifySign", Constant.Verbs.POST, oNotify, null))
                            {
                                ResultNotification oResultNotify = JsonConvert.DeserializeObject<ResultNotification>(resp.Content.ReadAsStringAsync().Result);
                                if (oResultNotify.Exito)
                                {
                                    oTrxDetails.IdEstadoFirma = (Int32)Constant.EnumEstadoFirma.Notificado;
                                    oTrxDetails.FchNotificacion = DateTime.Now;
                                }
                            }

                            //Obtener los documentos para firma y cargar en Ecert
                            foreach (String SP in Enum.GetNames(typeof(EnumSPFirmaArriendo)))
                            {
                                String DocumentoBase64 = "";

                                using (HttpResponseMessage resp = oProxy.CallService(Constant.UrlContratosPDF + "?con=" + Constant.contratoConexion + "&sp=" + Constant.GetSpDoc(SP) + "&id=" + id_contrato, Constant.Verbs.GET, null, null))
                                {
                                    try
                                    {
                                        DocumentoBase64 = JsonConvert.DeserializeObject<String>(resp.Content.ReadAsStringAsync().Result);

                                    }
                                    catch (Exception)
                                    {
                                        return new List<elimina_contrato>
                                        {
                                            new elimina_contrato
                                            {
                                                mensaje = "Error: " + resp.Content.ReadAsStringAsync().Result
                                            }
                                        };
                                    }
                                }
                                if (!String.IsNullOrEmpty(DocumentoBase64))
                                {
                                    Documento oDocLecarosSign = new Documento
                                    {
                                        IdSignTransaccion = oTrxDetails.IdSignTransacction,
                                        Nombre = id_contrato + "-" + SP,
                                        DocBase64 = DocumentoBase64,
                                        IdUsuarioCertificadora = oTrxDetails.IdUsuarioCertificadora,
                                        CustodiaExterna = false

                                    };
                                    Document oDocEcert = new Document
                                    {
                                        RutUsuario = oTrxDetails.Rut,
                                        IdUsuario = (Int32)oTrxDetails.IdUsuarioCertificadora.Value,
                                        DocumentoBase64 = DocumentoBase64,
                                        RequiereCustodia = false,
                                        NombreDocumento = id_contrato + "-" + SP
                                    };

                                    using (HttpResponseMessage resp = oProxy.CallService(Constant.UrlFirmaDigital + "FirmaElectronica/LoadDoc", Constant.Verbs.POST, oDocEcert, null))
                                    {
                                        oDocEcert = JsonConvert.DeserializeObject<Document>(resp.Content.ReadAsStringAsync().Result);
                                        oDocLecarosSign.IdDocEcertchile = oDocEcert.IdDocumento;
                                    }
                                    if (oDocLecarosSign.IdDocEcertchile > 0)
                                    {
                                        using (HttpResponseMessage resp = oProxy.CallService(Constant.UrlFirmaDigital + "Documento/Add", Constant.Verbs.POST, oDocLecarosSign, null))
                                        {
                                            oDocLecarosSign = JsonConvert.DeserializeObject<Documento>(resp.Content.ReadAsStringAsync().Result);

                                        }
                                    }
                                }

                            }


                            oTrxDetails.FchFirma = oTrxDetails.FchFirma == DateTime.MinValue ? null : oTrxDetails.FchFirma;

                        }

                        //Actualiza firmante
                        using (HttpResponseMessage resp = oProxy.CallService(Constant.UrlFirmaDigital + "SignTransacctionDetails/Upd", Constant.Verbs.POST, oTrxDetails, null))
                        {
                            Int32 ResultVal = JsonConvert.DeserializeObject<Int32>(resp.Content.ReadAsStringAsync().Result);

                        }

                    }





                }
            }
            return lst;
        }
        //public static List<propiedad> TraePropiedades_sel_mul(int id_usuario, string id_pry, string c_tipologia, string n_mes_dis, string id_ejecutivo, string c_edo, string n_ven_con, string sac_inversionista, string reparos) //Trae una propiedad
        //{
        //    List<propiedad> lst = new List<propiedad>();
        //    string Llama_PA = "Propiedades_Carga_Lista_V2";
        //    using (SqlConnection conn = new SqlConnection(connCorretaje))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(Llama_PA, conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id_usu", id_usuario);
        //        cmd.Parameters.AddWithValue("@id_pry", id_pry);
        //        cmd.Parameters.AddWithValue("@c_tipologia", c_tipologia);
        //        cmd.Parameters.AddWithValue("@n_mes_dis", n_mes_dis);
        //        cmd.Parameters.AddWithValue("@id_ejecutivo", id_ejecutivo);
        //        cmd.Parameters.AddWithValue("@c_edo", c_edo);
        //        cmd.Parameters.AddWithValue("@n_ven_con", n_ven_con);
        //        cmd.Parameters.AddWithValue("@sac_inversionista", sac_inversionista);
        //        cmd.Parameters.AddWithValue("@reparos", reparos);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            lst = reader.ToList<propiedad>();
        //        }
        //        conn.Close();
        //    }
        //    return lst;
        //}

        public static bool Contabilizar(int id_usuario, int id_contrato)
        {
            bool res = false;
            string Llama_PA = "Propiedades_Contabilizar";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                res = cmd.ExecuteNonQuery() > 0;

                conn.Close();
            }
            return res;
        }

        public static bool Llama_a_Propiedades_Actualiza_Acuerdos_Especiales(int id_usu, int id_prop, int id_contrato, string acuerdo_especial, int valor)
        {
            string Llama_PA = "EXEC Propiedades_Actualiza_Acuerdos_Especiales @id_usu, @id_prop, @id_contrato, @acuerdo_especial, @valor";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_prop", id_prop);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@acuerdo_especial", acuerdo_especial);
                cmd.Parameters.AddWithValue("@valor", valor);
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }

            return true;
        }

        public static bool Llama_a_MAIL_RECORDATORIO_PAGO_ARRIENDO()
        {
            string Llama_PA = "EXEC MAIL_RECORDATORIO_PAGO_ARRIENDO";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }

            return true;
        }

        public static Response Llama_a_MAIL_NOTIFICACION_ARRIENDO_PENDIENTE_INVERSIONISTA(int proc)
        {
            Response r = new Response();
            string Llama_PA = "EXEC MAIL_NOTIFICACION_ARRIENDO_PENDIENTE_INVERSIONISTA @ceroSendsMailsOneShowsInfo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@ceroSendsMailsOneShowsInfo", proc);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        r.EsValido = (reader["respuesta"].ToString().Equals("1") ? true : false);
                        r.Mensaje = reader["mensaje"].ToString();
                    }
                }
                conn.Close();
            }

            return r;
        }

        public static bool IngresaMotivoBloqueo(int bloqueo, string motivo_bloqueo, int usuario_bloqueo, int id_prop_arriendo)
        {
            string Llama_PA = "Exec Ingreso_Motivo_Bloqueo @id_propiedad,@b_bloqueado,@motivo_bloqueo,@usuario_bloqueo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_propiedad", id_prop_arriendo);
                cmd.Parameters.AddWithValue("@b_bloqueado", bloqueo);
                cmd.Parameters.AddWithValue("@motivo_bloqueo", motivo_bloqueo);
                cmd.Parameters.AddWithValue("@usuario_bloqueo", usuario_bloqueo);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public static bool IngresaMotivoBloqueoPagoSSBB(int bloqueo, string motivo_bloqueo, int usuario_bloqueo, int id_prop_arriendo)
        {
            string Llama_PA = "Exec Ingreso_Motivo_Bloqueo_PagoSSBB @id_propiedad,@b_bloqueado,@motivo_bloqueo,@usuario_bloqueo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_propiedad", id_prop_arriendo);
                cmd.Parameters.AddWithValue("@b_bloqueado", bloqueo);
                cmd.Parameters.AddWithValue("@motivo_bloqueo", motivo_bloqueo);
                cmd.Parameters.AddWithValue("@usuario_bloqueo", usuario_bloqueo);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public static bool _GenerarTicketRecepcion(int id_usuario, int id_contrato)
        {
            string Llama_PA = "Exec Propiedades_Generar_Ticket_Recepcion @id_usu, @id_contrato";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public static string MotivoBloqueo(int id_prop)
        {
            string lst = "";
            string Llama_PA = "EXEC Propiedades_Obtener_Motivo_Bloqueo @id_prop ";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(Llama_PA, conn);
                comando.Parameters.AddWithValue("@id_prop", id_prop);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        lst = reader["tooltip"].ToString();

                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static string MotivoBloqueoPagoSSBB(int id_prop)
        {
            string lst = "";
            string Llama_PA = "EXEC Propiedades_Obtener_Motivo_Bloqueo_Pago_SSBB @id_prop ";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(Llama_PA, conn);
                comando.Parameters.AddWithValue("@id_prop", id_prop);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        lst = reader["tooltip"].ToString();

                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static Mail Finiquitos_Obtener_Datos_Mail_Salvoconducto(int id_usu, int id_contrato, string base64)
        {
            Mail mail = new Mail();
            string Llama_PA = "EXEC Finiquitos_Obtener_Datos_Mail_Salvoconducto @id_usu, @id_contrato,@id_contrato_base64";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@id_contrato_base64", base64);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mail.idContrato = int.Parse(reader["id_contrato"].ToString());
                        mail.asunto = reader["asunto"].ToString();
                        mail.cuerpo = reader["cuerpo"].ToString();
                        mail.destinatario = reader["destinatario"].ToString();
                    }
                }
                conn.Close();
            }

            return mail;
        }

        public static bool Finiquitos_Enviar_Mail_Salvoconducto(int id_usuario, int id_contrato, string destinatarios, string con_copias, string asunto, string cuerpo_mail)
        {
            string Llama_PA = "Exec Finiquitos_Enviar_Mail_Salvoconducto @id_usu, @id_contrato, @destinatarios, @con_copias, @asunto, @cuerpo_mail";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@destinatarios", destinatarios);
                cmd.Parameters.AddWithValue("@con_copias", con_copias);
                cmd.Parameters.AddWithValue("@asunto", asunto);
                cmd.Parameters.AddWithValue("@cuerpo_mail", cuerpo_mail);

                conn.Open();

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }

        public static List<listas_caracteristica_editable> Propiedades_Editar_Multiple_Lista(int id_usu)
        {
            List<listas_caracteristica_editable> lst = new List<listas_caracteristica_editable>();
            string Llama_PA = "EXEC Propiedades_Editar_Multiple_Lista @id_usu";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usu);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(new listas_caracteristica_editable
                        {
                            id = int.Parse(reader["id"].ToString()),
                            descripcion = reader["descripcion"].ToString(),
                            etiqueta = reader["etiqueta"].ToString(),
                            tipo = reader["tipo"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return lst;
        }

        public static Resultado Propiedades_Editar_Multiple_Editar(int id_usuario, int id_contrato, int campo, string valor)
        {
            Resultado resultado = new Resultado();
            string Llama_PA = "EXEC Propiedades_Editar_Multiple_Actualizar @id_usu, @id_contrato, @campo, @valor";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@campo", campo);
                cmd.Parameters.AddWithValue("@valor", valor);

                conn.Open();


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultado.id = reader["id"].ToString();
                        resultado.descripcion = reader["descripcion"].ToString();
                    }
                }
                conn.Close();
            }
            return resultado;
        }

        public static Resultado _BloquearArrendatario(int id_usuario, int id_contrato, int b_bloqueo_arriendo, string g_motivo_bloqueo_arriendo)
        {
            Resultado resultado = new Resultado();
            string Llama_PA = "EXEC Finiquito_Bloquear_Arrendatario @id_usu, @id_contrato, @b_bloqueo_arriendo, @g_motivo_bloqueo_arriendo";
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                SqlCommand cmd = new SqlCommand(Llama_PA, conn);
                cmd.CommandTimeout = sqlTimeout;
                cmd.Parameters.AddWithValue("@id_usu", id_usuario);
                cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                cmd.Parameters.AddWithValue("@b_bloqueo_arriendo", b_bloqueo_arriendo);
                cmd.Parameters.AddWithValue("@g_motivo_bloqueo_arriendo", g_motivo_bloqueo_arriendo);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultado.id = reader["id"].ToString();
                        resultado.descripcion = reader["descripcion"].ToString();
                    }
                }
                conn.Close();
            }
            return resultado;
        }
    }

}