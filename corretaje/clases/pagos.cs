using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace corretaje.Clases
{
    public class pagos
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
        //public string estado { get; set; }
        public string b_cheque_rescatado { get; set; }
        public string calce_custodia { get; set; }
        public string nuevo_id { get; set; }
        public string b_repetido { get; set; }
        public string color_letra { get; set; }
        public string b_cuota_regularizacion { get; set; }
        public string id_estado_pago { get; set; }
        public string id_ingreso_dinero { get; set; }
        public string medio_pago { get; set; }
        public string g_kam { get; set; }
        public string g_vigencia { get; set; }
        public string cta_corriente { get; set; }
        public string g_concepto { get; set; }
    }

    public class subir_archivo
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
    }

    public class observaciones
    {
        public string periodo { get; set; }
        public string concepto { get; set; }
        public string propietario { get; set; }
        public string direccion { get; set; }
        public string num_depto { get; set; }
        public string observacion { get; set; }
        public string id_pago { get; set; }
    }

    public class estado_pago
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
        public string id_pago { get; set; }
        public string estado_anterior { get; set; }
        public string nuevo_estado { get; set; }
    }

    public class otros_cobros
    {
        public string concepto { get; set; }
        public string monto { get; set; }
        public string num_chk_ope { get; set; }
        public string banco { get; set; }
        public string titular { get; set; }
        public string rut_titular { get; set; }
        //public string dv_titular { get; set; }
        public string rut_cliente { get; set; }
        public string dv_cliente { get; set; }
        public string folio_contabilidad_1 { get; set; }
        public string folio_contabilidad_2 { get; set; }
        public string valor_garantia { get; set; }
        public string propiedad { get; set; }
    }

    public class cobros
    {
        public string cheque { get; set; }
        public string monto { get; set; }
        public string titular_cheque { get; set; }
        public string rut_titular { get; set; }
        public string dv_titular { get; set; }
        public string banco { get; set; }
    }

    public class caracteristicas
    {
        public string id_caracteristica { get; set; }
        public string tipo { get; set; }
        public string observacion { get; set; }
        public string g_modelo { get; set; }
        public string g_marca { get; set; }
        public string b_garantia { get; set; }
        public string f_mantencion { get; set; }
        public string f_proxima_mantencion { get; set; }
        public string g_clase { get; set; }
        public string g_archivo { get; set; }
        public string id_propiedad_caracteristica { get; set; }
    }

    public class comunidades
    {
        public string id { get; set; }
        public string id_proyecto { get; set; }
        public string proyecto { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string tipo_comunidad { get; set; }
        public string cuenta{ get; set; }
        public string tipo_cuenta{ get; set; }
        public string banco { get; set; }
        public string direccion { get; set; }
        public string rut { get; set; }
        public string cuenta_bancaria { get; set; }
        public string fono { get; set; }
        public string estado { get; set; }
        public string cargo{ get; set; }
        public string url { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }


    }

    public class ActualizaFechaGasto
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
    }

    public class ResuActuPorCuot
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
    }

    public class ProyYProps
    {
        public string id_pry { get; set; }
        public string g_pry { get; set; }
        public string id_inmob { get; set; }
        public string g_dir { get; set; }
        public string g_num { get; set; }
    }

    public class ResultadoCambioNoCobro
    {
        public string num_cuota { get; set; }
        public string pago { get; set; }
        public string contrato { get; set; }
        public string periodo_cuota { get; set; }
        public string concepto { get; set; }
        public string monto { get; set; }
        public string cheque { get; set; }
        public string banco { get; set; }
        public string forma_pago { get; set; }
        public string titular { get; set; }
        public string rut_titular { get; set; }

    }
    public class Lote {

        public string glosa { get; set; }
    }

    public class IngresosDineroArrendatario
    {
        public string id_ing { get; set; }
        public string id_tipo { get; set; }
        public string g_tipo { get; set; }
        public string f_fecha { get; set; }
        public string v_monto { get; set; }
        public string id_forma_pago { get; set; }
        public string g_forma_pago { get; set; }
        public string id_estado { get; set; }
        public string g_estado { get; set; }
        public string g_observacion { get; set; }
        public string id_contrato { get; set; }
        public string g_nombre { get; set; }


    }
}