using corretaje.Liquidaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace corretaje.Clases
{
    public class PropiedadGrilla
    {
        public int id_prop_arriendo { get; set; }
        public int id_contrato { get; set; }
        public int estado { get; set; }
        public string direccion { get; set; }
        public string num_depto { get; set; }
        public string num_estacionam { get; set; }
        public string num_bodega { get; set; }
        public string rut_arrendatario { get; set; }
        public string rut_complemento { get; set; }
        public string rut_dv_aval_1 { get; set; }
        public string rut_dv_aval_2 { get; set; }
        public string arrendatario { get; set; }
        public string rut_propietario { get; set; }
        public string propietario { get; set; }
        public string termino_contrato { get; set; }
        public string arriendo { get; set; }
        public string nombre_estado { get; set; }
        public string nombre_ejecutivo { get; set; }
        public string dias_sin_arrendar { get; set; }
        public int n_mes_gracia_arr { get; set; }
        public string mes_ini_pago_inv { get; set; }
        public string sac_inversionista { get; set; }
        public int num_reparos { get; set; }
        public string b_okop { get; set; }
        public string proyecto { get; set; }
        public string inicio_contrato { get; set; }
        public string color_semaforo { get; set; }
        public int b_contabilizado { get; set; }
        public int b_enfiniquito { get; set; }
        public int reservado { get; set; }
        public int b_internet { get; set; }
        public int b_arriendouf { get; set; }
        public int b_amoblado { get; set; }
        public int bloqueo { get; set; }
        public int bloqueo_pago_ssbb { get; set; }
        public int b_soc_unipersonal { get; set; }
        public string f_desde_soc_unipersonal { get; set; }
        public int b_family_office { get; set; }
        public int b_amoblados { get; set; }

    }
    public class ArchivoGenerado
    {
        public byte[] Bytes { get; set; }
        public string RutaArchivo { get; set; }
    }
    public class propiedad
    {
        public string id_prop_arriendo { get; set; }
        public string ultimo_mes_pagado { get; set; }
        public string mes_renovacion { get; set; }
        public string fecha_estado { get; set; }
        public int estado { get; set; }
        public string glosa_estado { get; set; }
        public string direccion { get; set; }
        public string numero { get; set; }
        public int comuna { get; set; }
        public int id_metro { get; set; }
        public int tipo_bien { get; set; }
        public int id_pry { get; set; }
        public string g_pry { get; set; }
        public int id_inmob { get; set; }
        public int id_formato { get; set; }
        public string g_inmob { get; set; }
        public int id_ejecutivo { get; set; }
        public string f_recepcion { get; set; }
        public string rol_propiedad { get; set; }
        public string num_depto { get; set; }
        public string num_estacionam { get; set; }
        public string num_bodega { get; set; }
        public string tipologia { get; set; }
        public string superficie { get; set; }
        public string observacion { get; set; }
        public string estado_pa { get; set; }
        public string mensaje_pa { get; set; }
        public string id_estado { get; set; }
        public string rut_arrendatario { get; set; }
        public string rut_dv_aval_1 { get; set; }
        public string rut_dv_aval_2 { get; set; }
        public string arrendatario { get; set; }
        public string rut_propietario { get; set; }
        public string propietario { get; set; }
        public string orientacion { get; set; }
        public string termino_contrato { get; set; }
        public string ejecutivo { get; set; }
        public string arriendo { get; set; }
        public string nombre_estado { get; set; }
        public string observacion_finanzas { get; set; }
        public string nombre_ejecutivo { get; set; }
        public string id_contrato { get; set; }
        public string estado_2 { get; set; }
        public string titular { get; set; }
        public string comision_administracion { get; set; }
        public string comision_corretaje { get; set; }
        public string meses_gracia { get; set; }
        public string banco { get; set; }
        public string cae { get; set; }
        public string tasa { get; set; }
        public string dividendo { get; set; }
        public string escritura { get; set; }
        public string plazo { get; set; }
        public string seguro_muerte { get; set; }
        public string seguro_incendio { get; set; }
        public string seguro_sismo { get; set; }
        public string seguro_incendio_sismo { get; set; }
        public string f_primer_dividendo { get; set; }
        public string luz { get; set; }
        public string agua { get; set; }
        public string gas { get; set; }
        public string firma_contrato { get; set; }
        public string f_ent_inmob { get; set; }
        public string f_postventa { get; set; }
        public string f_ent_eje { get; set; }
        public string f_acta_recepcion { get; set; }
        public string dias_sin_arrendar { get; set; }
        public string n_mes_gracia_arr { get; set; }
        public string mes_ini_pago_inv { get; set; }
        public string f_recep_inmob { get; set; }
        public string otra_informacion { get; set; }
        public string etapa { get; set; }
        public string tiene_check { get; set; }

        public string b_dfl2 { get; set; }
        public string n_sup_m2_utiles { get; set; }
        public string n_sup_m2_terraza { get; set; }
        public string chk_contado { get; set; }
        public string porcentaje_comision_adm { get; set; }
        public string com_adm_2do { get; set; }
        public string com_adm_vigente { get; set; }
        public string com_corretaje { get; set; }
        public string sac_inversionista { get; set; }

        public string ei_chk_pago_saldos { get; set; }
        public string ei_f_pago_saldos { get; set; }
        public string ei_chk_pago_ajustes { get; set; }
        public string ei_f_pago_ajustes { get; set; }
        public string ei_chk_pago_fondo { get; set; }
        public string ei_f_pago_fondo { get; set; }
        public string ei_chk_finiquito { get; set; }
        public string ei_f_finiquito { get; set; }
        public string ei_chk_otros { get; set; }
        public string ei_g_otros { get; set; }
        public string ei_f_otros { get; set; }
        public string ei_chk_otros2 { get; set; }
        public string ei_g_otros2 { get; set; }
        public string ei_f_otros2 { get; set; }
        public string num_reparos { get; set; }
        public string ggcc_nombre { get; set; }
        public string ggcc_cta_deposito { get; set; }
        public int ggcc_banco { get; set; }
        public string ggcc_rut { get; set; }
        public string ggcc_monto { get; set; }
        public string ch_mto_escritura { get; set; }
        public string ch_mto_financiamiento { get; set; }
        public string ch_por_financiamiento { get; set; }
        public string nombre_sac { get; set; }


        public string id_usu { get; set; } //ADD 04-11-2019
        public string c_tipologia { get; set; }//ADD 04-11-2019
        public string n_mes_dis { get; set; }//ADD 04-11-2019
        public string c_edo_prop { get; set; }//ADD 04-11-2019
        public string n_ven_con { get; set; }//ADD 04-11-2019
        public string c_edo_cont { get; set; }//ADD 04-11-2019

        public string g_estado_contrato { get; set; } //add 23-12-2019

        public string b_okop { get; set; }
        public string f_okop { get; set; }
        public string id_us_okop { get; set; }

        public string proyecto { get; set; }
        public string diferencia_dias { get; set; }
        public string ci_fecha_inicio_adm { get; set; }
        public string b_renovacion { get; set; }

        public string fecha_recepcion_prop { get; set; }
        public string id_estado_fin { get; set; }
        public string g_estado_fin { get; set; }

        public string color_columna { get; set; }
        public string dias_count { get; set; }
        public string f_dias_count { get; set; }

        public string b_nueva { get; set; }
        public string f_fecha_disponible { get; set; }

        public string inicio_contrato { get; set; }
        public string color_semaforo { get; set; }
        public string link_recorrido_virtual { get; set; }

        public string b_contabilizado { get; set; }

        public string rol_estacionam { get; set; }
        public string rol_bodega { get; set; }
        public string num_estacionam_2 { get; set; }
        public string num_bodega_2 { get; set; }
        public string rol_estacionam_2 { get; set; }
        public string rol_bodega_2 { get; set; }
        public string v_uf_estacionam { get; set; }
        public string v_uf_bodega { get; set; }
        public string v_uf_estacionam_2 { get; set; }
        public string v_uf_bodega_2 { get; set; }
        public string b_enfiniquito { get; set; }
        public string n_piso { get; set; }
        public string b_bloqueado { get; set; }
        public string ci_f_1er_dividendo { get; set; }

        public string b_soc_unipersonal { get; set; }
        public string f_desde_soc_unipersonal { get; set; }
        public string g_cuenta_deposito_soc_unipersonal { get; set; }
        public string id_banco_deposito_soc_unipersonal { get; set; }
        public string g_giro_soc_unipersonal { get; set; }
        public string correo_comunidad { get; set; }
        public string ci_f_desde_com_vigente { get; set; }
        public int id_plan { get; set; }
        public string motivo_fin { get; set; }
    }

    public class ok_op
    {
        public string b_okop { get; set; }
        public string f_okop { get; set; }
        public string id_us_okop { get; set; }
    }

    public class estados
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
        public int id { get; set; }
    }

    public class listascombobox
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string periodo_dia { get; set; }
        public string periodo_mes { get; set; }
    }
    public class listas_caracteristica_editable
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string etiqueta { get; set; }
        public string tipo { get; set; }
    }
    public class listaCliente
    {
        public int rut { get; set; }
        public string g_dv { get; set; }
        public string nombre { get; set; }
    }

    public class listascomboboxDocumento
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string inicio_contrato { get; set; }
        public string termino_contrato { get; set; }
        public string id_prop_arriendo { get; set; }
        public string rut_propietario_1 { get; set; }
        public string rut_arrendatario_1 { get; set; }
    }

    public class DocumentosGrilla
    {
        public string seccion { get; set; }
        public string id_catalogo { get; set; }
        public string c_tipo { get; set; }
        public string tipo { get; set; }
        public string propiedad { get; set; }
        public string propietario { get; set; }
        public string arrendatario { get; set; }
        public string archivo { get; set; }
        public string descripcion { get; set; }
    }

    public class CatalogoLista
    {
        public int id_catalogo { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public string archivo { get; set; }
        public int id { get; set; }
        public string glosa { get; set; }
    }

    public class TipoArchivo
    {
        public string id { get; set; }
        public string glosa { get; set; }
    }

    public class ArchivoFiniquito
    {
        public string id_catalogo { get; set; }
        public string c_tipo { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public string f_ini_per { get; set; }
        public string f_ter_per { get; set; }
        public string m_monto { get; set; }
        public string archivo { get; set; }
        public string estado { get; set; }
        public string archivo2 { get; set; }
        public string tipo_devolucion { get; set; }
    }

    public class GastosLista
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public string concepto { get; set; }
        public int id_concepto { get; set; }
        public string observacion { get; set; }
        public string inversionista { get; set; }
        public string total { get; set; }
        public string archivo { get; set; }
        public string estado { get; set; }
        public string mensaje { get; set; }
        public string id_solicitud { get; set; }
        public string id_contrato { get; set; }
    }

    public class DatosEmpresa
    {
        public string n_rut_emp { get; set; }
        public string g_dv_emp { get; set; }
        public string g_nom_emp { get; set; }
        public string g_dom_emp { get; set; }
        public string id_dom_emp_com { get; set; }
        public string n_rut_rep_leg { get; set; }
        public string g_dv_rep_leg { get; set; }
        public string g_nom_rep_leg { get; set; }
        public string g_dom_rep_leg { get; set; }
        public string id_dom_com_rep_leg { get; set; }
    }

    public class DatosPersona
    {
        public string n_rut { get; set; }
        public string g_dv { get; set; }
        public string g_nom { get; set; }
        public string g_ape_pat { get; set; }
        public string g_ape_mat { get; set; }
        public string g_fon_par { get; set; }
        public string g_fon_cel { get; set; }
        public string g_mail_per { get; set; }
        public string id_est_civ { get; set; }
        public string id_prof { get; set; }
        public string g_prof_otra { get; set; }
        public string n_ant_lab { get; set; }
        public string id_nac { get; set; }
    }

    public class DatosCliente
    {
        public string n_rut { get; set; }
        public string g_dv { get; set; }
        public string g_nom { get; set; }
        public string g_ape_pat { get; set; }
        public string g_ape_mat { get; set; }
        public string g_fon_par { get; set; }
        public string g_fon_cel { get; set; }
        public string g_mail_per { get; set; }
        public string g_dom_par { get; set; }
        public string g_num_casa { get; set; }
        public string g_num_dep { get; set; }
        public string id_dom_com { get; set; }
        public string id_est_civ { get; set; }
        public string id_prof { get; set; }
        public string g_prof_otra { get; set; }
        public string n_ant_lab { get; set; }
        public string id_nac { get; set; }
        public string v_prom_liq { get; set; }
        public string g_pob_villa { get; set; }
        public string sac_inversionista { get; set; }
        public string p_col { get; set; }
        public string p_adm_1er { get; set; }
        public string p_adm_2do { get; set; }
        public string mail_copia_liquidacion { get; set; }
    }

    public class DatosEmpresa2
    {
        public string n_rut_emp { get; set; }
        public string g_nom_emp { get; set; }
        public string g_dom_emp { get; set; }
        public string id_dom_emp_com { get; set; }
        public string n_rut_rep_leg { get; set; }
        public string g_nom_rep_leg { get; set; }
        public string g_dom_rep_leg { get; set; }
        public string id_dom_com_rep_leg { get; set; }

        public string g_ape_pat_rep_leg { get; set; }
        public string g_ape_mat_rep_leg { get; set; }
        public string g_num_casa_rep_leg { get; set; }
        public string g_num_dep_rep_leg { get; set; }
        public string id_est_civ_rep_leg { get; set; }
        public string id_nac_rep_leg { get; set; }
        public string id_prof_rep_leg { get; set; }
        public string g_prof_otra_rep_leg { get; set; }
        public string sac_inversionista { get; set; }
        public string fono_contacto { get; set; }

    }

    public class Orientacion
    {
        public string id { get; set; }
        public string glosa { get; set; }
    }

    public class Arrendatario
    {
        public string id_prop { get; set; }
        public string tipo_propietario { get; set; }
        public string n_rut { get; set; }
        public string g_dv { get; set; }
        public string g_nom { get; set; }
        public string g_ape_pat { get; set; }
        public string g_ape_mat { get; set; }
        public string g_fon_par { get; set; }
        public string g_fon_cel { get; set; }
        public string g_mail_per { get; set; }
        public string id_est_civ { get; set; }
        public string id_prof { get; set; }
        public string g_prof_otra { get; set; }
        public string id_nac { get; set; }
        public string n_rut_arr2 { get; set; }
        public string g_dv_arr2 { get; set; }
        public string n_nom_arr2 { get; set; }
        public string g_ape_pat_arr2 { get; set; }
        public string g_ape_mat_arr2 { get; set; }
        public string g_fon_par_arr2 { get; set; }
        public string g_fon_cel_arr2 { get; set; }
        public string g_mail_per_arr2 { get; set; }
        public string id_est_civ_arr2 { get; set; }
        public string id_prof2 { get; set; }
        public string g_prof_otra2 { get; set; }
        public string id_nac2 { get; set; }
        public string n_rut_emp { get; set; }
        public string g_dv_emp { get; set; }
        public string g_nom_emp { get; set; }
        public string g_dom_emp { get; set; }
        public string id_dom_emp_com { get; set; }
        public string n_rut_rep_leg { get; set; }
        public string g_dv_rep_leg { get; set; }
        public string g_nom_rep_leg { get; set; }

        public string g_ape_pat_rep_leg { get; set; }
        public string g_ape_mat_rep_leg { get; set; }
        public string id_nac_rep_leg { get; set; }
        public string id_est_civ_rep_leg { get; set; }
        public string id_prof_rep_leg { get; set; }
        public string g_prof_otra_rep_leg { get; set; }

        public string g_dom_rep_leg { get; set; }
        public string id_dom_com_rep_leg { get; set; }
        public string cuenta_deposito { get; set; }
        public string id_banco_deposito { get; set; }
        public string otro_titular { get; set; }
        public string rut_otro_titular { get; set; }
        public string dv_otro_titular { get; set; }
        public string nombre_otro_titular { get; set; }
        public string mail_otro_titular { get; set; }
        public string rut_aval_1 { get; set; }
        public string dv_rut_aval_1 { get; set; }
        public string rut_aval_2 { get; set; }
        public string dv_rut_aval_2 { get; set; }
        public string observacion { get; set; }
        public string v_prom_liq { get; set; }
        public string v_prom_liq2 { get; set; }
        public string direccionArrendatario { get; set; }
        public string comunaArrendatario { get; set; }
        public string n_casa_primer_arr { get; set; }
        public string n_depto_primer_arr { get; set; }
        public string poblacion_primer_arr { get; set; }

        public string direccionArrendatario2 { get; set; }
        public string comunaArrendatario2 { get; set; }
        public string n_casa_segundo_arr { get; set; }
        public string n_depto_segundo_arr { get; set; }
        public string poblacion_segundo_arr { get; set; }

        public string n_ant_lab { get; set; }
        public string n_ant_lab2 { get; set; }
        public string id_contrato { get; set; }

        public string tipo_cta_dep { get; set; } //ADD CAA 27-05-2018
        public string g_mail_contacto_emp { get; set; } //ADD CAA 16-06-2018

        public string g_pasaporte { get; set; } //ADD CAA 03-09-2019
        public string g_pasaporte2 { get; set; } //ADD CAA 03-09-2019
        public string fono_contacto_empresa { get; set; }

        public string enrolamiento { get; set; }

        public string estadoprop { get; set; }
    }

    public class Propietario
    {
        public string id_prop { get; set; }
        public string tipo_propietario { get; set; }
        public string n_rut { get; set; }
        public string g_dv { get; set; }
        public string g_nom { get; set; }
        public string g_ape_pat { get; set; }
        public string g_ape_mat { get; set; }
        public string g_fon_par { get; set; }
        public string g_fon_cel { get; set; }
        public string g_mail_per { get; set; }
        public string id_est_civ { get; set; }
        public string n_rut_2 { get; set; }
        public string g_dv_2 { get; set; }
        public string g_nom_2 { get; set; }
        public string g_ape_pat_2 { get; set; }
        public string g_ape_mat_2 { get; set; }
        public string g_fon_par_2 { get; set; }
        public string g_fon_cel_2 { get; set; }
        public string g_mail_per_2 { get; set; }
        public string id_est_civ_2 { get; set; }
        public string n_rut_emp { get; set; }
        public string g_dv_emp { get; set; }
        public string g_nom_emp { get; set; }
        public string g_dom_emp { get; set; }
        public string id_dom_emp_com { get; set; }
        public string n_rut_rep_leg { get; set; }
        public string g_dv_rep_leg { get; set; }
        public string g_nom_rep_leg { get; set; }

        public string g_ape_pat_rep_leg { get; set; }
        public string g_ape_mat_rep_leg { get; set; }
        public string id_nac_rep_leg { get; set; }
        public string id_est_civ_rep_leg { get; set; }
        public string id_prof_rep_leg { get; set; }
        public string g_prof_otra_rep_leg { get; set; }

        public string g_dom_rep_leg { get; set; }
        public string tipo_cuenta { get; set; }
        public string id_dom_com_rep_leg { get; set; }
        public string cuenta_deposito { get; set; }
        public string id_banco_deposito { get; set; }
        public string otro_titular { get; set; }
        public string rut_otro_titular { get; set; }
        public string dv_otro_titular { get; set; }
        public string nombre_otro_titular { get; set; }
        public string mail_otro_titular { get; set; }

        public string direcciontitular { get; set; }
        public string comunatitular { get; set; }
        public string n_casa_titular { get; set; }
        public string n_depto_titular { get; set; }
        public string poblacion_titular { get; set; }

        public string direccioncotitular { get; set; }
        public string comunacotitular { get; set; }
        public string n_casa_cotitular { get; set; }
        public string n_depto_cotitular { get; set; }
        public string poblacion_cotitular { get; set; }
        public string g_mail_contacto_emp { get; set; }
        public string sac_inversionista { get; set; }
        public string sac_inversionista_empresa { get; set; }

        public string enrolamiento { get; set; }

        public string c_giro { get; set; }
        public string mail_copia_liquidacion { get; set; }
        public string fono_contacto_empresa { get; set; }

        public string cuenta_deposito_principal { get; set; }
        public string id_banco_deposito_principal { get; set; }
    }

    public class ListadoArchivos
    {
        public string id_catalogo { get; set; }
        public string descripcion { get; set; }
        public string archivo { get; set; }
        public string tipo { get; set; }
        public string fecha { get; set; }
        public string id_tipo { get; set; }
        public string f_mail { get; set; }
        public string g_mail { get; set; }
        public string id_usu_mail { get; set; }
        public string nom_usu_mail { get; set; }
        public string monto { get; set; }
    }

    public class Arriendo
    {
        public string id_prop_arriendo { get; set; }
        public string id_contrato { get; set; }
        public string inicio_contrato { get; set; }
        public string termino_contrato { get; set; }
        public string firma_contrato { get; set; }
        public string dia_pago { get; set; }
        public string f_renovacion { get; set; }
        public string valor_arriendo { get; set; }
        public string com_corretaje_con_iva { get; set; }
        public string valor_garantia { get; set; }
        public string gastos_notariales { get; set; }
        public string costo_dicom { get; set; }
        public string fraccion_mes { get; set; }
        public string forma_pago { get; set; }
        public string com_admin_con_iva { get; set; }
        public string folio_contabilidad_1 { get; set; }
        public string folio_contabilidad_2 { get; set; }
        public string folio_contabilidad_3 { get; set; }
        public string observacion_general { get; set; }
        public string n_meses_gracia { get; set; }
        public string f_1er_dividendo { get; set; }
        public string estado { get; set; }
        public string id_banco_deposito { get; set; }
        public string com_corretaje_arrendatario_por { get; set; }
        public string com_corretaje_propietario_por { get; set; }
        public string comision_administracion_por { get; set; }
        public string f_acta_recepcion { get; set; }
        public string b_aviso_renovacion { get; set; }
        public string arriendo_sugerido { get; set; }
        public string gastos_comunes { get; set; }
        public string fecha_aviso_renovacion { get; set; }
        public string b_finiquito { get; set; }


        public string b_mail_bienvenida { get; set; }
        public string f_mail_bienvenida { get; set; }
        public string b_dev_dev { get; set; }
        public string b_dev_gen_sol { get; set; }
        public string b_dev_gen_carta { get; set; }
        public string f_dev_gen_sol { get; set; }
        public string b_dev_pagada { get; set; }
        public string f_dev_pagada { get; set; }
        public string b_dev_mail_env { get; set; }
        public string f_dev_mail_env { get; set; }
        public string b_dev_consumo { get; set; }
        public string valor_costo_renovacion { get; set; }
        public string monto_reserva { get; set; }
        public string id_forma_pago_reserva { get; set; }
        public string b_renovacion { get; set; }
        public string observacion_carta_devolucion { get; set; }
        public string ldi_lp { get; set; }
        public string devolucion_garantia { get; set; }
        public string f_rec_cont_ant { get; set; }

        public string tipo_bien { get; set; }
        public string monto_reserva_garantia { get; set; }
        public string b_internet { get; set; }
        public string b_arriendouf { get; set; }
        public string b_amoblado { get; set; }
    }

    public class ObservGenerales
    {
        public string fecha { get; set; }
        public string nombre { get; set; }
        public string observacion { get; set; }
    }

    public class Avales
    {
        public string n_rut { get; set; }
        public string g_dv { get; set; }
        public string g_nom { get; set; }
        public string g_ape_pat { get; set; }
        public string g_ape_mat { get; set; }
        public string g_fon_par { get; set; }
        public string g_fon_cel { get; set; }
        public string g_mail_per { get; set; }
        public string id_est_civ { get; set; }
        public string id_prof { get; set; }
        public string g_prof_otra { get; set; }
        public string n_ant_lab { get; set; }
        public string id_nac { get; set; }
        public string direccion { get; set; }
        public string comuna { get; set; }
        public string n_casa { get; set; }
        public string n_depto { get; set; }
        public string poblacion { get; set; }
        public string v_prom_liq { get; set; }
    }

    public class ListadoExcel
    {
        public string folio { get; set; }
        public string direccion { get; set; }
        public string depto { get; set; }
        public string arrendatario { get; set; }
        public string propietario { get; set; }
        public string tipologia { get; set; }
        public string superficie { get; set; }
        public string orientacion { get; set; }
        public string n_bodega { get; set; }
        public string n_estacionamiento { get; set; }
        public string term_contrato { get; set; }
        public string ejecutivo { get; set; }
        public string arriendo { get; set; }
        public string estado { get; set; }
        public string proyecto { get; set; }
        public string inmobiliaria { get; set; }
        public string metro { get; set; }
        public string comuna { get; set; }
        public string fecha_inicio_contrato { get; set; }
        public string fecha_termino_contrato { get; set; }
    }

    public class MesesGastos
    {
        public string periodo { get; set; }
        public string muestra { get; set; }
    }

    public class NuevaCuota
    {
        public string id_pago { get; set; }
        public string id_contrato { get; set; }
        public string cuota { get; set; }
        public string mes { get; set; }
        public string concepto { get; set; }
        public string forma_pago { get; set; }
        public string banco { get; set; }
        public string titular { get; set; }
        public string num_chk_ope { get; set; }
        public string monto { get; set; }
        public string fecha_vencimiento { get; set; }
        public string fecha_venc_formato { get; set; }
        public string cheque_protestado { get; set; }
        public string fecha_pago { get; set; }
        public string forma_pago_real { get; set; }
        public string num_chk_ope_real { get; set; }
        public string observacion { get; set; }
        public string estado { get; set; }
        public string id_estado { get; set; }
        public string fecha_estado { get; set; }
        public string rut_titular { get; set; }
        public string direccion { get; set; }
        public string num_depto { get; set; }
        public string nom_arrendatario { get; set; }
        public string nom_propietario { get; set; }
        public string id_formapago { get; set; }
        public string nom_formapago { get; set; }
        public string nom_titular_cheque { get; set; }
        public string rut_titular_cheque { get; set; }
        public string dv_titular_cheque { get; set; }
        public string nom_banco { get; set; }
        public string num_cheque { get; set; }
        public string id_prop_arriendo { get; set; }
        public string g_file { get; set; }
        public string arriendo { get; set; }
        public string mensaje { get; set; }
        public string custodia { get; set; }
        public string com_admin_por { get; set; }
        public string com_corretaje_por { get; set; }
        public string id_concepto { get; set; }
        public string mes_cuota { get; set; }
        public string cta_corriente { get; set; }
    }

    public class DatosFiniquito
    {
        public string id_prop_arriendo { get; set; }
        public string id_contrato { get; set; }
        public string b_f_ent { get; set; }
        public string f_ent { get; set; }
        public string b_f_ent_llaves { get; set; }
        public string f_ent_llaves { get; set; }
        public string b_aviso { get; set; }
        public string id_origen { get; set; }
        public string id_motivo { get; set; }
        public string g_observacion { get; set; }
        public string b_mail_aviso { get; set; }
        public string f_mail_aviso { get; set; }
        public string b_salvo { get; set; }
        public string b_cuentas { get; set; }
        public string b_cheques { get; set; }
        public string b_medidores { get; set; }
        public string b_generar_salvo { get; set; }
        public string b_adjuntar_salvo { get; set; }
        public string b_enviar_salvo { get; set; }
        public string b_f_enviar_salvo { get; set; }
        public string f_enviar_salvo { get; set; }
        public string b_acta { get; set; }
        public string b_generar_acta { get; set; }
        public string b_adjuntar_acta { get; set; }
        public string b_f_recepcion { get; set; }
        public string f_recepcion { get; set; }
        public string id_usu { get; set; }
        public string b_gar_dev { get; set; }
        public string b_gar_gen_sol { get; set; }
        public string f_gar_gen_sol { get; set; }
        public string b_gar_gen_carta { get; set; }
        public string b_gar_pagada { get; set; }
        public string f_gar_pagada { get; set; }
        public string b_gar_mail_env { get; set; }
        public string f_gar_mail_env { get; set; }
        public string id_gar_pagada_ticket { get; set; }
        public string observacion_carta_finiquito { get; set; }
        public string devolucion_garantia { get; set; }
        public string f_ter_contrato { get; set; }

        public string b_motivo { get; set; }
        public string b_observacion { get; set; }
        public string b_gen_sol_dev { get; set; }
        public string b_aviso_finanzas { get; set; }
        public string obs_aviso_finanzas { get; set; }
        public string f_aviso_finanzas { get; set; }
        public string b_cheque_reg { get; set; }
        public string f_cheque_reg { get; set; }
        public string f_gen_sol_dev { get; set; }

        public string id_estado_fin { get; set; }
        public string g_estado_fin { get; set; }
        public string tipo_garantia { get; set; }
        public string  ticket_f_recepcion { get; set; }
        public string ticket_f_acta { get; set; }
        public string id_ticket { get; set; }
        public int b_bloqueo_arriendo { get; set; }
        public string g_motivo_bloqueo_arriendo { get; set; }
        public string g_usu_bloqueo_arriendo { get; set; }

    }

    public class ArriendoFiniquito
    {
        public string id_prop_arriendo { get; set; }
        public string id_contrato { get; set; }
        public string inicio_contrato { get; set; }
        public string termino_contrato { get; set; }
        public string firma_contrato { get; set; }
        public string dia_pago { get; set; }
        public string f_renovacion { get; set; }
        public string valor_arriendo { get; set; }
        public string com_corretaje_con_iva { get; set; }
        public string valor_garantia { get; set; }
        public string gastos_notariales { get; set; }
        public string costo_dicom { get; set; }
        public string fraccion_mes { get; set; }
        public string forma_pago { get; set; }
        public string id_banco_deposito { get; set; }
        public string com_admin_con_iva { get; set; }
        public string folio_contabilidad_1 { get; set; }
        public string folio_contabilidad_2 { get; set; }
        public string folio_contabilidad_3 { get; set; }
        public string f_acta_recepcion { get; set; }
        public string observacion_general { get; set; }
        public string n_meses_gracia { get; set; }
        public string f_1er_dividendo { get; set; }
        public string estado { get; set; }
        public string com_corretaje_arrendatario_por { get; set; }
        public string com_corretaje_propietario_por { get; set; }
        public string comision_administracion_por { get; set; }
        public string b_aviso_renovacion { get; set; }
        public string arriendo_sugerido { get; set; }
        public string fecha_aviso_renovacion { get; set; }
        public string b_finiquito { get; set; }

    }

    public class Response
    {
        public bool EsValido { get; set; }
        public string Mensaje { get; set; }

        public Response()
        {
            EsValido = false;
        }
    }

    public class CambiaEstadoPR
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
        public string id { get; set; }
        public string id_nuevo_contrato { get; set; }
    }

    public class CartaDevolucionHeader
    {
        public string id_prop { get; set; }
        public string id_contrato { get; set; }
        public string propiedad { get; set; }
        public string arrendatario { get; set; }
        public string rut { get; set; }
        public string fecha_termino { get; set; }
        public string fecha_entrega { get; set; }
        public string cuenta_deposito { get; set; }
        public string banco_deposito { get; set; }
        public string titular_cuenta { get; set; }
        public string rut_cuenta { get; set; }
        public string mail_cuenta { get; set; }
        public string garantia { get; set; }
        public string folio_propiedad { get; set; }
        public string fecha_solicitud { get; set; }
        public string nombre_propietario { get; set; }
        public string rut_propietario { get; set; }
        public string nombre_arr_ant { get; set; }
        public string rut_arr_ant { get; set; }
        public string observacion_carta_devolucion { get; set; }
        public string observacion_carta_finiquito { get; set; }
        public string observacion_cargo_propietario { get; set; }
        public string url_cuenta_deposito { get; set; }
        public string mail_arrendatarios { get; set; }
    }

    public class CartaDevolucionResumen
    {
        public string garantia { get; set; }
        public string luz { get; set; }
        public string gas { get; set; }
        public string agua { get; set; }
        public string ggcc { get; set; }
        public string ggaa { get; set; }
        public string ggcc_sig { get; set; }
        public string dias_prop { get; set; }
        public string otros_desc { get; set; }
        public string total_descuentos { get; set; }
        public string abono_ggcc { get; set; }
        public string abono_ssbb { get; set; }
        public string total_abonos { get; set; }
        public string total_devolucion { get; set; }
        public string tot_arr_act { get; set; }
        public string tot_arr_ant { get; set; }
        public string tot_prop { get; set; }
        public string gop { get; set; }
        public string cg { get; set; }
        public string total { get; set; }
        public string garantia_mas_abono { get; set; }
        public string aseo_municipal { get; set; }
        public string traspaso_inv { get; set; }
    }

    public class CartaDevolucionDetalle
    {
        public string f_ini { get; set; }
        public string f_ter { get; set; }
        public string m_monto { get; set; }
        public string pagada { get; set; }
        public string valor_diario { get; set; }
        public string dias { get; set; }
        public string monto { get; set; }
        public string tot_act { get; set; }
        public string tot_ant { get; set; }
        public string tot_pro { get; set; }
    }

    public class ResponseEstadoDevolucion
    {
        public string id_contrato { get; set; }
        public string mensaje { get; set; }
    }

    public class ResHabilitarCheck
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
    }

    public class ConsultaConsumo
    {
        public string estado { get; set; }
        public string numero_cliente { get; set; }
        public string direccion { get; set; }
        public string fecha_consulta { get; set; }
        public string total_a_pagar { get; set; }
        public string fecha_vencimiento { get; set; }
        public string fecha_corte { get; set; }
        public string monto_ult_pago { get; set; }
        public string fecha_ult_pago { get; set; }
    }

    public class HistorialPagoConsumo
    {
        public string direccion { get; set; }
        public string id_prop { get; set; }
        public string id_contrato { get; set; }
        public string inicio_contrato { get; set; }
        public string termino_contrato { get; set; }
        public string concepto { get; set; }
        public string fecha_vencimiento { get; set; }
        public string fec_vcto { get; set; }
        public string fec_pago { get; set; }
        public string mora { get; set; }
        public string forma_pago { get; set; }
        public string titular_cheque { get; set; }
        public string rut_titular { get; set; }
        public string banco { get; set; }
        public string cheque { get; set; }
        public string estado { get; set; }
    }

    public class HistorialEstado
    {
        public string id_prop { get; set; }
        public string id_estado { get; set; }
        public string g_estado { get; set; }
        public string f_estado { get; set; }
        public string g_f_estado { get; set; }
        public string direccion { get; set; }
        public string numero { get; set; }
        public string num_depto { get; set; }
        public string id_pry { get; set; }
        public string g_nom_pry { get; set; }
        public string usuario { get; set; }
    }

    public class ReciboDineroHeader
    {
        public string direccion { get; set; }
        public string arrendatario_nombre { get; set; }
        public string arrendatario_rut { get; set; }
        public string inversionista_nombre { get; set; }
        public string inversionista_rut { get; set; }
        public string inicio_arriendo { get; set; }
        public string termino_arriendo { get; set; }
        public string valor_arriendo { get; set; }
        public string gastos_notariales { get; set; }
        public string garantia { get; set; }
        public string informe_especial { get; set; }
        public string fraccion_mes { get; set; }
        public string folio { get; set; }
        public string ejecutivo { get; set; }
        public string fecha { get; set; }
        public string tipo_documento { get; set; }
        public string com_corretaje { get; set; }
        public string total { get; set; }
    }

    public class ReciboDineroHeaderNew
    {
        public string descripcion { get; set; }
        public string valor { get; set; }
    }
    public class ReciboDineroDetalle
    {
        public string concepto { get; set; }
        public string monto { get; set; }
        public string fecha_vcto { get; set; }
        public string forma_pago { get; set; }
        public string banco { get; set; }
        public string nombre_titular { get; set; }
        public string rut_titular { get; set; }
        public string n_doc_ope { get; set; }
        public string fecha_vencimiento { get; set; }
    }

    public class MercadoParametros
    {
        public string proc { get; set; }
        public string xini { get; set; }
        public string yini { get; set; }
        public string xexp { get; set; }
        public string yexp { get; set; }
        public string tipo_negociosp { get; set; }
        public string tipo_propiedadSP { get; set; }
        public string comunaSP { get; set; }
        public string regionSP { get; set; }
        public string dormitoriosSP { get; set; }
        public string banosSP { get; set; }
    }

    public class ApiData
    {
        public string cantidad { get; set; }
        public string promedio { get; set; }
        public string minimo { get; set; }
        public string maximo { get; set; }
        public string dev_estandar { get; set; }
        public string var_estandar { get; set; }
        public string sup_total_prom { get; set; }
        public string mediana { get; set; }
    }

    public class MercadoConsulta
    {
        public string coordenada_x { get; set; }
        public string coordenada_y { get; set; }
        public string cantidad { get; set; }
        public string valor_prom { get; set; }
        public string valor_max { get; set; }
        public string valor_minimo { get; set; }
        public string valor_desv_estandar { get; set; }
        public string valor_m2_prom { get; set; }
        public string valor_m2_max { get; set; }
        public string valor_m2_minimo { get; set; }
        public string valor_m2_desv_estandar { get; set; }
        public string valor_arr_prom_uf { get; set; }
        public string valor_arr_max_uf { get; set; }
        public string valor_arr_min_uf { get; set; }
        public string valor_arr_prom_pe { get; set; }
        public string valor_arr_max_pe { get; set; }
        public string valor_arr_min_pe { get; set; }
        public string mediana { get; set; }
    }

    public class HeaderExcelFormato
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class DatosNuevaPropiedad
    {
        public int id_prop { get; set; }
        public int id_contrato { get; set; }
        public int estado { get; set; }
        public string mensaje { get; set; }
    }

    public class DatosGGCC
    {
        public string ggcc_nombre { get; set; }
        public string ggcc_cta_deposito { get; set; }
        public int ggcc_banco { get; set; }
        public string ggcc_rut { get; set; }
    }

    public class ticket
    {
        public string proc { get; set; }
        public string id_devol_ticket { get; set; }
        public string id_propiedad { get; set; }
        public string id_contrato { get; set; }
        public string observacion { get; set; }
        public string id_usu { get; set; }
        public string f_creacion { get; set; }
        public string mensaje { get; set; }
        public string id_ticket { get; set; }
        public string estado { get; set; }
    }
    public class Datos_Correo
    {
        public string mail_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public string tipo_cliente { get; set; }
    }

    public class ResultadoEnvioMail
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
    }

    public class Dev_Contratos_Cliente
    {
        public string n_contrato { get; set; }
        public string id_prop { get; set; }
        public string arrendatario { get; set; }
        public string rut_arrendatario { get; set; }
        public string inicio_contrato { get; set; }
        public string termino_contrato { get; set; }
        public string g_estado_contrato { get; set; }
        public string b_bloqueado { get; set; }
        
    }

    public class Devoluciones
    {
        public string id_sol { get; set; }
        public string fecha { get; set; }
        public string id_tipo { get; set; }
        public string id_prop { get; set; }
        public string tipo { get; set; }
        public string contrato { get; set; }
        public string ldi_lp { get; set; }
        public string direccion { get; set; }
        public string depto { get; set; }
        public string arrendatario { get; set; }
        public string propietario { get; set; }
        public string inicio_contrato { get; set; }
        public string termino_contrato_fmt { get; set; }
        public string fecha_cto_ant { get; set; }
        public string monto_arr_ant { get; set; }
        public string monto_propietario { get; set; }
        public string monto_arr_act { get; set; }
        public string monto_devolucion { get; set; }
        public string dias { get; set; }
        public string SLA { get; set; }
        public string id_estado { get; set; }
        public string estado { get; set; }
        public string f_estado { get; set; }
        public string SAC { get; set; }
        public string id_SAC { get; set; }
        public string c_tipo { get; set; }
        public string b_no_proporcional { get; set; }
        public string g_motivo { get; set; }
    }
    public class Contenido_Devolucion {
        public string id_catalogo { get; set; }
        public string c_tipo { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public string f_ini_per { get; set; }
        public string f_ter_per { get; set; }
        public string m_monto { get; set; }
        public string archivo { get; set; }
        public string archivo2 { get; set; }
        public string estado { get; set; }
        public string observacion { get; set; }
        public string procedencia { get; set; }
        public string b_incluir_obs { get; set; }
    }

    public class MigracionArchivos
    {
        public string g_archivo { get; set; }
        public string id_contrato { get; set; }
        public string id_prop { get; set; }
    }

    public class ListadoRelaciones
    {
        public string id_relacion { get; set; }
        public string rut_principal { get; set; }
        public string rut_relacion { get; set; }
        public string fecha { get; set; }
        public string nombre_principal { get; set; }
        public string nombre_relacion { get; set; }
        public string estado { get; set; }
        public string mensaje { get; set; }
    }

    public class Prop_Contratos_Cliente
    {
        public string numero_registro { get; set; }
        public string n_contrato { get; set; }
        public string contrato_anterior { get; set; }
        public string id_prop { get; set; }
        public string arrendatario { get; set; }
        public string rut_arrendatario { get; set; }
        public string inicio_contrato { get; set; }
        public string termino_contrato { get; set; }
        public string fecha_renovacion { get; set; }
        public string g_estado_contrato { get; set; }
        public string renovado { get; set; }
        public string id_estado_propiedad { get; set; }
        public string g_estado_propiedad { get; set; }
    }

    public class elimina_contrato
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
    }
    public class agregar_cuota
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
    }
    public class ListadoClientesCuentas
    {
        public string nombre_cliente { get; set; }
        public string rut_formateado { get; set; }
        public string n_rut { get; set; }
    }

    public class HistorialEstadoFiniquito
    {
        public string id_propiedad { get; set; }
        public string responsable { get; set; }
        public string fecha { get; set; }
        public string fecha_sin_formato { get; set; }
        public string estado_anterior { get; set; }
        public string estado_nuevo { get; set; }
    }

    public class BeneficiosPropiedad
    {
        public string c_item { get; set; }
        public string g_glosa1 { get; set; }
        public string n_valor1 { get; set; }
        public string id_ben { get; set; }
    }
    public class CotizacionMantencion
    {
        public int id_cotizacion { get; set; }
        public string cot_glosa { get; set; }
        public string cot_estado { get; set; }
        public string cot_total { get; set; }
        public string cot_para { get; set; }
        public string cot_fecha { get; set; }
    }
    public class CotizacionRendicion
    {
        public int id_rendicion { get; set; }
        public string glosa { get; set; }
        public string estado { get; set; }
        public string monto_actual { get; set; }
        public string monto_anterior { get; set; }
        public string fecha_desde { get; set; }
        public string fecha_hasta { get; set; }
        public string nom_documento { get; set; }
        public string id_contrato { get; set; }

    }
    public class RegistroMulta {
        public int id_pago { get; set; }
        public int id_contrato { get; set; }
        public int id_tipo { get; set; }
        public int id_prop_arriendo { get; set; }
        public string direccion { get; set; }
        public string num_depto { get; set; }
        public string arrendatario { get; set; }
        public string propietario { get; set; }
        public string mes { get; set; }
        public string fecha_mes { get; set; }
        public string fecha_pago { get; set; }
        public float monto { get; set; }
        public int id_estado { get; set; }
        public string estado { get; set; }
        public string concepto { get; set; }
        public string g_file { get; set; }
        public string forma_pago { get; set; }
        public int medio_pago { get; set; }

    }

    public class Mail {
        public int idContrato { get; set; }
        public string asunto { get; set; }
        public string destinatario { get; set; }
        public string cuerpo { get; set; }
    }

    public class  DetallePagoGarantia
    {
        public int id_prop { get; set; }
        public int id_contrato { get; set; }
        public string concepto { get; set; }
        public float monto { get; set; }
        public string fecha_vencimiento { get; set; }
        public string fecha_pago { get; set; }
        public string estado { get; set; }
        public string arrendatario { get; set; }
        public string inicio_contrato { get; set; }
        public string termino_contrato { get; set; }
        public int b_cambio_titular { get; set; }
        public int b_cambio_propietario { get; set; }
        public string observacion { get; set; }
        public int id_concepto { get; set; }
        public string glosa_concepto { get; set; }
    }

    public class ObservacionDevolucion
    {
        public int id_obs { get; set; }
        public int id_sol { get; set; }
        public int id_estado { get; set; }
        public string g_estado { get; set; }
        public int id_usuario { get; set; }
        public string g_usuario { get; set; }
        public string observacion { get; set; }
        public string fecha { get; set; }
    }
    public class Resultado {
        public string id { get; set; }
        public string descripcion { get; set; }
    }


}  