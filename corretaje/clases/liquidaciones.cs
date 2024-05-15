using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace corretaje.Clases
{
    public class liquidaciones
    {
        public string id_liq { get; set; } = "0";
        public string id_pago { get; set; } = "0";
        public string id_contrato { get; set; } = "0";
        public string id_prop_arriendo { get; set; } = "0";
        public string mes { get; set; } = "";
        public string direccion { get; set; } = "";
        public string num_depto { get; set; } = "";
        public string propietario { get; set; } = "";
        public string arriendo { get; set; } = "0";
        public string estado_arriendo { get; set; } = "";
        public string com_admin_por { get; set; } = "0%";
        public string com_neta { get; set; } = "0";
        public string com_iva { get; set; } = "0";
        public string descuentos { get; set; } = "0";
        public string a_pagar { get; set; } = "0";
        public string estado_pago { get; set; } = "";
        public string forma_pago { get; set; } = "";
        public string ejecutivo { get; set; } = "";
        public string estado_factura { get; set; } = "";
        public string mail { get; set; } = "";
        public string observacion { get; set; } = "";
        public string periodo { get; set; } = "";
        public string concepto { get; set; } = "";
        public string rut_propietario { get; set; } = "";
        public string monto { get; set; } = "0";
        public string total_com { get; set; } = "0";
        public string g_file_factura { get; set; } = "";
        public string g_file_liquidacion { get; set; } = "";
        public string mes_liq { get; set; } = "";
        public string mes_gracia { get; set; } = "0";
        public string sac_inversionista { get; set; } = "";
        public string tf_fecha { get; set; } = "";
        public string b_pago_contra_garantia { get; set; } = "0";
        public string b_pago_seguro_arriendo { get; set; } = "0";
        public string f_mail_liquidacion { get; set; } = "0";
        public string g_tipologia { get; set; } = "";

        public string b_repetido { get; set; } = "0";
        public string color_letra { get; set; } = "";

        public string b_comentario { get; set; } = "0";
        public string id_forma_pago { get; set; } = "";
        public string g_archivo_factura { get; set; } = "";
        public string com_total { get; set; } = "0";
        public string folio_factura { get; set; } = "";
        public string icono_mostrar_ldi { get; set; } = "";

        public string g_archivo_factura_ilp { get; set; } = "";
        public string folio_factura_ilp { get; set; } = "";
        public string icono_mostrar_ilp { get; set; } = "";

        public string f_termino_contrato { get; set; } = "";
        public string color_f_termino { get; set; } = "";
        public string estado_propiedad { get; set; } = "";
        public string beneficios { get; set; } = "";
        public string tienebeneficios { get; set; } = "";
    }

    public class NuevoEstado
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
        public string id_pago { get; set; }
        public string estado_anterior { get; set; }
        public string nuevo_estado { get; set; }
        public string rut { get; set; }
        public string Usuario { get; set; }
        public string observacion { get; set; }
        public string monto { get; set; }
        public string mensaje2 { get; set; }
        public string color { get; set; }
        public string id_propiedad { get; set; }
        public string tipo_sol { get; set; }
        public string fecha_primer_pago { get; set; }
    }

    public class ExcelLiquidaciones
    {
        public string mes { get; set; }
        public string cuenta_destino { get; set; }
        public string banco_deposito { get; set; }
        public string rut_propietario { get; set; }
        public string propietario { get; set; }
        public string pago { get; set; }
        public string sac_inversionista { get; set; }
        public string monto { get; set; }
    }

    public  class ResultadoEnvioMails
    {
        public string rut { get; set; }
        public string fecha { get; set; }
        public string nombre { get; set; }
        public string archivo { get; set; }
        public string estado { get; set; }
        public string mensaje { get; set; }
    }

    public class ResultadoGeneracionPDFMasivo
    {
        public string rut { get; set; }
        public string cliente { get; set; }
        public string mensaje { get; set; }
        public string estado { get; set; }
        public string fecha { get; set; }
    }

    public class Aprobaciones_Comparativo
    {
        public string Dif { get; set; }
        public string id_pago { get; set; }
        public string contrato_act { get; set; }
        public string contrato_ant { get; set; }
        public string estado_pago { get; set; }
        public string arriendo_act { get; set; }
        public string arriendo_ant { get; set; }
        public string com_act { get; set; }
        public string com_ant { get; set; }
        public string descuento_act { get; set; }
        public string descuento_ant { get; set; }
        public string a_pagar_act { get; set; }
        public string a_pagar_ant { get; set; }
    }

    public class observacion_pago
    {
        public string id_pago { get; set; }
        public string id_usuario { get; set; }
        public string observacion { get; set; }
        public string fecha_obs { get; set; }
        public string nom_usuario { get; set; }
    }

    public class retorno_obs
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
        public string id_cuota { get; set; }
    }

    public class HistorialEstadoPago
    {
        public string id_pago { get; set; }
        public string usuario { get; set; }
        public string fecha { get; set; }
        public string fecha_sin_formato { get; set; }
        public string estado_anterior { get; set; }
        public string estado_nuevo { get; set; }
    }
    public class perfilamiento
    {
        public string g_estado_arriendo { get; set; }
        public string g_estado_propietario { get; set; }
        public string sac_inversionista { get; set; }
    }

    public class verificador_cartera 
    { 
        public string direccion { get; set; }
        public string num_depto { get; set; }
        public string id_pago { get; set; }
        public string registros_cobrados { get; set; }
        public string registros_pendientes { get; set; }
        public string registros_totales { get; set; }
        public string estado_propiedad { get; set; }
        public string num_contrato { get; set; }
        public string estado_pago { get; set; }
        public string periodo { get; set; }
        public string count_prop { get; set; }
        public string observacion { get; set; }
        public string nombre_propietario { get; set; }
        public string id_propiedad{ get; set; }
    }

    public class KPIInversionista
    {
        public string column1 { get; set; }
        public string column2 { get; set; }
        public string column3 { get; set; }
    }
    public class KPIInversionista2
    {
        public string id_pago { get; set; }
        public string id_contrato { get; set; }
        public string concepto { get; set; }
        public string rut_propietario { get; set; }
        public string propietario { get; set; }
        public string direccion { get; set; }
        public string num_depto { get; set; }
        public string forma_pago { get; set; }
        public string numero_cheque { get; set; }
        public string id_prop_arriendo { get; set; }
        public string mes { get; set; }
        public string arriendo { get; set; }
        public string estado_arriendo { get; set; }
        public string com_admin_por { get; set; }
        public string com_neta { get; set; }
        public string com_iva { get; set; }
        public string com_total { get; set; }
        public string descuentos { get; set; }
        public string mes_gracia { get; set; }
        public string a_pagar { get; set; }
        public string estado_pago { get; set; }
        public string fecha_pago { get; set; }
        public string ejecutivo { get; set; }
        public string kam_inversionista { get; set; }
        public string id_kam_inversionista { get; set; }
        public string estado_factura { get; set; }
        public string mail { get; set; }
        public string observacion { get; set; }
        public string pago_contra_garantia { get; set; }
    }
}