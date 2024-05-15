using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using corretaje.Clases;
using corretaje.Models;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Xml.Linq;
using System.Drawing.Printing;
using System.Data;
using Newtonsoft.Json.Linq;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Web.Script.Serialization;

namespace corretaje.Controllers
{
    public class LiquidacionController : Controller
    {
        string DirectorioDocumentos = ConfigurationManager.AppSettings.Get("directoriodocumentos");

        public ActionResult Index()
        {
            if (Request.Cookies["cookiePerfil"] != null)
            {
                int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
                DateTime ahora = DateTime.Today;
                string fecha = ahora.Year.ToString() + "-" + ahora.Month.ToString() + "-01";
                return View();
            }
            else
            {
                return Redirect(Url.Action("Login", "Home") + "?url=" + Url.Action("Index"));
            }
        }


        [HttpPost]
        public ActionResult _FiltraLiquidaciones(string fecha, string fecha2, string estado_arriendo, string estado_pago, string sac_inversionista, int filtros, string forma_pago_liq, string rut)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            return PartialView(LiquidacionModels.Liquidacion_Carga_Lista_2(IdUsuario, fecha, estado_arriendo, estado_pago, 0, fecha2, sac_inversionista, filtros, forma_pago_liq, rut));
        }

        [HttpPost]
        public ActionResult _FiltraAprobaciones(string fecha, string fecha2, string estado_arriendo, string estado_pago, string sac_inversionista)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            ViewBag.fec = fecha;
            return PartialView(LiquidacionModels.Liquidacion_Carga_Lista_2(IdUsuario, fecha, estado_arriendo, estado_pago, 1, fecha2, sac_inversionista, 0, "0", "0"));
        }

        [HttpPost]
        public ActionResult _ListadoLiquidadas(string fecha, string fecha2, string estado_arriendo, string estado_pago, string sac_inversionista, string rut)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            ViewBag.fec = fecha;
            ViewBag.fecha2 = fecha2;
            ViewBag.estado_arriendo = estado_arriendo;
            ViewBag.estado_pago = estado_pago;
            ViewBag.sac_inversionista = sac_inversionista;
            ViewBag.rut = rut;
            return PartialView(LiquidacionModels.Liquidacion_Carga_Lista_2(IdUsuario, fecha, estado_arriendo, estado_pago, 2, fecha2, sac_inversionista, 0, "0", rut));
        }

        [HttpPost]
        public ActionResult _ListadoFacturas(string fecha, string fecha2, string estado_arriendo, string estado_pago, string sac_inversionista, string rut)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            ViewBag.fec = fecha;
            ViewBag.fecha2 = fecha2;
            ViewBag.estado_arriendo = estado_arriendo;
            ViewBag.estado_pago = estado_pago;
            ViewBag.sac_inversionista = sac_inversionista;
            ViewBag.rut = rut;
            return PartialView(LiquidacionModels.Liquidacion_Carga_Lista_2(IdUsuario, fecha, estado_arriendo, estado_pago, 3, fecha2, sac_inversionista, 0, "0", rut));
        }

        [HttpPost]
        public ActionResult _GeneracionMasivaLiquidacionPDF(string fecha)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            string[] fec = fecha.Replace('/', '-').Split('-');
            string fec1 = fec[0] + "-" + fec[1] + "-01";
            bool estado = true;
            string mensaje = ""; 
            List<ResultadoGeneracionPDFMasivo> res = new List<ResultadoGeneracionPDFMasivo>();
            List<liquidaciones> liq = LiquidacionModels.Liquidaciones(IdUsuario, fec1, "0", "0", 1, fecha, 0, 0, 0, 0);
            foreach(var x in liq)
            {
                try
                {
                    _Guarda_PDF_Liquidacion(0, int.Parse(x.rut_propietario), x.mes, 1);
                    estado = true;
                    mensaje = "Liquidación Generada con Exito.";
                }
                catch( Exception ex)
                {
                    estado = false;
                    mensaje = ex.ToString();
                }
                res.Add(new ResultadoGeneracionPDFMasivo
                {
                    rut = x.rut_propietario,
                    cliente = x.propietario,
                    mensaje = mensaje,
                    estado = estado.ToString(),
                    fecha = DateTime.Now.ToString("dd-MM-yyyy")
                });
            }

            return PartialView(res);
        }

        [HttpGet]
        public ActionResult GenerarLiquidacion(int id_liq, int rut, string fecha)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            string contentType = "application/pdf";
            string[] paso = fecha.Split('-');
            string ano = (int.Parse(paso[1])).ToString();
            string mes = "01";
            switch ( paso[0].Replace(".","") )
            {
                case "feb":
                    mes = "02";
                    break;
                case "mar":
                    mes = "03";
                    break;
                case "abr":
                    mes = "04";
                    break;
                case "may":
                    mes = "05";
                    break;
                case "jun":
                    mes = "06";
                    break;
                case "jul":
                    mes = "07";
                    break;
                case "ago":
                    mes = "08";
                    break;
                case "sept":
                    mes = "09";
                    break;
                case "oct":
                    mes = "10";
                    break;
                case "nov":
                    mes = "11";
                    break;
                case "dic":
                    mes = "12";
                    break;
            }
            string fecha_final = ano + "-" + mes + "-01";
            //string directorio = "PDF_" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            string extension;
            string encoding;
            string mimeType;
            string[] streams;
            //List<string> lstArchivos = new List<string>();
            Warning[] warnings;
            System.IO.Directory.CreateDirectory(Server.MapPath("~/Documentos/" + rut.ToString()));

            //string FileName = "Liquidacion_" + rut.ToString() + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf";
            string FileName = "Liquidacion_" + rut.ToString() + "_" + fecha_final + ".pdf";
            if (id_liq == 0)
            {
                FileName = "PRE_Liquidacion_" + rut.ToString() + "_" + fecha_final + ".pdf";
            }

            string outPutFilePath = Server.MapPath("~/Documentos/" + rut.ToString() + "/" + FileName);

            LocalReport liquidacion = new LocalReport();
            liquidacion.ReportPath = Server.MapPath("~/Liquidaciones/Liquidacion_v5.rdlc"); //Liquidacion_v4.rdlc

            ReportDataSource rds0 = new ReportDataSource();
            rds0.Name = "Cabecera";
            rds0.Value = LiquidacionModels.Llama_Liquidacion_PDF_Header(IdUsuario, id_liq, rut, fecha_final,0);

            ReportDataSource rds1 = new ReportDataSource();
            rds1.Name = "Coloc4";
            rds1.Value = LiquidacionModels.Llama_Liquidacion_PDF_Arriendos_Por_Propietario_Colocaciones(IdUsuario, id_liq, rut, fecha_final,0);

            ReportDataSource rds2 = new ReportDataSource();
            rds2.Name = "Descuentos";
            rds2.Value = LiquidacionModels.Llama_Liquidacion_PDF_Descuentos_Por_Propietario(IdUsuario, id_liq, rut, fecha_final,0);

            ReportDataSource rds3 = new ReportDataSource();
            rds3.Name = "Admin3";
            rds3.Value = LiquidacionModels.Llama_Liquidacion_PDF_Arriendos_Por_Propietario_Administracion(IdUsuario, id_liq, rut, fecha_final,0);

            ReportDataSource rds4 = new ReportDataSource();
            rds4.Name = "Cabecera2";
            rds4.Value = LiquidacionModels.Llama_Liquidacion_PDF_Header(IdUsuario, id_liq, rut, fecha_final,0);

            ReportDataSource rds5 = new ReportDataSource();
            rds5.Name = "PropiedadesNoLiquidadas";
            rds5.Value = LiquidacionModels.Llama_Liquidacion_PDF_Propiedades_No_Liquidadas(IdUsuario, id_liq, rut, fecha_final,0);

            ReportDataSource rds6 = new ReportDataSource();
            rds6.Name = "PropiedadesObservaciones";
            rds6.Value = LiquidacionModels.Llama_Liquidacion_PDF_Propiedades_Observaciones(IdUsuario, id_liq, rut, fecha_final, 0);

            liquidacion.DataSources.Add(rds0);
            liquidacion.DataSources.Add(rds1);
            liquidacion.DataSources.Add(rds2);
            liquidacion.DataSources.Add(rds3);
            liquidacion.DataSources.Add(rds4);
            liquidacion.DataSources.Add(rds5);
            liquidacion.DataSources.Add(rds6);

            Byte[] mybytesResumen = liquidacion.Render("PDF", null,
                out extension, out encoding,
                out mimeType, out streams, out warnings); //for exporting to PDF  

            using (FileStream fs = System.IO.File.Create(outPutFilePath))
            {
                fs.Write(mybytesResumen, 0, mybytesResumen.Length);
            }

                Response.ClearHeaders();
                Response.ClearContent();
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = contentType;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
                Response.WriteFile(outPutFilePath);
                Response.Flush();
                Response.Close();
                Response.End();
                return View();
        }

        [HttpPost]
        public ActionResult _Guarda_PDF_Liquidacion(int id_liq, int rut, string fecha, int? almacenar)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            string contentType = "application/pdf";
            string[] paso = fecha.Split('-');
            string ano = (int.Parse(paso[1])).ToString();
            string ahora = DateTime.Now.ToString("HHmm");
            string mes = "01";
            switch (paso[0].Replace(".", ""))
            {
                case "feb":
                    mes = "02";
                    break;
                case "mar":
                    mes = "03";
                    break;
                case "abr":
                    mes = "04";
                    break;
                case "may":
                    mes = "05";
                    break;
                case "jun":
                    mes = "06";
                    break;
                case "jul":
                    mes = "07";
                    break;
                case "ago":
                    mes = "08";
                    break;
                case "sept":
                    mes = "09";
                    break;
                case "oct":
                    mes = "10";
                    break;
                case "nov":
                    mes = "11";
                    break;
                case "dic":
                    mes = "12";
                    break;
            }
            string fecha_final = ano + "-" + mes + "-01";
            //string directorio = "PDF_" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            string extension;
            string encoding;
            string mimeType;
            string[] streams;
            //List<string> lstArchivos = new List<string>();
            Warning[] warnings;
            System.IO.Directory.CreateDirectory(Server.MapPath("~/Documentos/" + rut.ToString()));

            //string FileName = "Liquidacion_" + rut.ToString() + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf";
            string FileName = "Liquidacion_" + rut.ToString() + "_" + fecha_final + "_" + ahora + ".pdf";
            if (id_liq == 0)
            {
                FileName = "Liquidacion_" + rut.ToString() + "_" + fecha_final + "_" + ahora + ".pdf";
            }

            string outPutFilePath = Server.MapPath("~/Documentos/" + rut.ToString() + "/" + FileName);

            LocalReport liquidacion = new LocalReport();
            liquidacion.ReportPath = Server.MapPath("~/Liquidaciones/Liquidacion_v4.rdlc");

            ReportDataSource rds0 = new ReportDataSource();
            rds0.Name = "Cabecera";
            rds0.Value = LiquidacionModels.Llama_Liquidacion_PDF_Header(IdUsuario, id_liq, rut, fecha_final,1);

            ReportDataSource rds1 = new ReportDataSource();
            rds1.Name = "Coloc4";
            rds1.Value = LiquidacionModels.Llama_Liquidacion_PDF_Arriendos_Por_Propietario_Colocaciones(IdUsuario, id_liq, rut, fecha_final,1);

            ReportDataSource rds2 = new ReportDataSource();
            rds2.Name = "Descuentos";
            rds2.Value = LiquidacionModels.Llama_Liquidacion_PDF_Descuentos_Por_Propietario(IdUsuario, id_liq, rut, fecha_final,1);

            ReportDataSource rds3 = new ReportDataSource();
            rds3.Name = "Admin3";
            rds3.Value = LiquidacionModels.Llama_Liquidacion_PDF_Arriendos_Por_Propietario_Administracion(IdUsuario, id_liq, rut, fecha_final,1);

            ReportDataSource rds4 = new ReportDataSource();
            rds4.Name = "Cabecera2";
            rds4.Value = LiquidacionModels.Llama_Liquidacion_PDF_Header(IdUsuario, id_liq, rut, fecha_final,1);

            ReportDataSource rds5 = new ReportDataSource();
            rds5.Name = "PropiedadesNoLiquidadas";
            rds5.Value = LiquidacionModels.Llama_Liquidacion_PDF_Propiedades_No_Liquidadas(IdUsuario, id_liq, rut, fecha_final,1);

            liquidacion.DataSources.Add(rds0);
            liquidacion.DataSources.Add(rds1);
            liquidacion.DataSources.Add(rds2);
            liquidacion.DataSources.Add(rds3);
            liquidacion.DataSources.Add(rds4);
            liquidacion.DataSources.Add(rds5);

            Byte[] mybytesResumen = liquidacion.Render("PDF", null,
                out extension, out encoding,
                out mimeType, out streams, out warnings); //for exporting to PDF  

            using (FileStream fs = System.IO.File.Create(outPutFilePath))
            {
                fs.Write(mybytesResumen, 0, mybytesResumen.Length);
            }

            /*
            Document doc = new Document(PageSize.LETTER,0,0,0,0);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(outPutFilePath, FileMode.Create));
            doc.Open();
            doc.Close();
            */

            if (almacenar == null)
            {
                Response.ClearHeaders();
                Response.ClearContent();
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = contentType;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
                Response.WriteFile(outPutFilePath);
                Response.Flush();
                Response.Close();
                Response.End();
                return View();
            }
            else
            {
                LiquidacionModels.Llama_Liquidacion_Liquida_Arriendos_Propietario(rut, fecha_final, FileName, IdUsuario);
                return null;
            }

        }



        [HttpPost]
        public ActionResult _Reliquidar(string[] data) //(string fecha, int rut)
        {
            List<NuevoEstado> lst = new List<NuevoEstado>();
            
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            foreach (var item in data)
            {
                if ( item != "")
                {
                    string[] paso1 = item.ToString().Split('|');
                    string fecha = paso1[1];
                    int rut = int.Parse(paso1[0]);
                    string[] paso = fecha.Split('-');
                    string ano = (int.Parse(paso[1])).ToString();
                    string mes = "01";
                    switch (paso[0])
                    {
                        case "feb": mes = "02"; break;
                        case "mar": mes = "03"; break;
                        case "abr": mes = "04"; break;
                        case "may": mes = "05"; break;
                        case "jun": mes = "06"; break;
                        case "jul": mes = "07"; break;
                        case "ago": mes = "08"; break;
                        case "sep": mes = "09"; break;
                        case "oct": mes = "10"; break;
                        case "nov": mes = "11"; break;
                        case "dic": mes = "12"; break;
                    }
                    string fecha_final = ano + "-" + mes + "-01";
                    string res = LiquidacionModels.Llama_Liquidacion_RELiquidar_Propietario_Mes(fecha_final, rut, IdUsuario).ToString();
                    string[] pat = res.Split('|');
                    lst.Add(new NuevoEstado
                    {
                        estado = pat[0],
                        rut = rut.ToString(),
                        mensaje = pat[1]

                    });
                }
            }            
            return PartialView(lst);
        }

        [HttpPost]
        public ActionResult ExportarExcel(FormCollection f)
        {
            string mes = f["mes_excel"].ToString();
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            //List<ExcelLiquidaciones> prop = LiquidacionModels.Llama_Liquidacion_Genera_Excel_TF(IdUsuario, mes);
            DataTable dt = LiquidacionModels.Llama_Liquidacion_Genera_Excel_TF_V2(IdUsuario, mes);
            
            GridView gv = new GridView();
            gv.DataSource = dt;//prop.ToList(); //busqueda.ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=ListadoLiquidaciones_"+mes+".xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            return null;
        }

        [HttpPost]
        public ActionResult ExportarExcelAprobaciones(FormCollection f)
        {
            string mes = f["mes_excel"].ToString();
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            //List<ExcelLiquidaciones> prop = LiquidacionModels.Llama_Liquidacion_Genera_Excel_TF(IdUsuario, mes);
            DataTable dt = LiquidacionModels.Llama_Liquidacion_Genera_Excel_Aprobaciones(IdUsuario, f["mes_excel"], f["mes_excel_2"]);

            GridView gv = new GridView();
            gv.DataSource = dt;//prop.ToList(); //busqueda.ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=ListadoAprobaciones_" + f["mes_excel"] + "---A---" + f["mes_excel_2"] + ".xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            return null;
        }

        [HttpPost]
        public ActionResult ExportarExcelLiquidaciones(FormCollection f)
        {
            string mes = f["mes_excel"].ToString();
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            //List<ExcelLiquidaciones> prop = LiquidacionModels.Llama_Liquidacion_Genera_Excel_TF(IdUsuario, mes);
            DataTable dt = LiquidacionModels.Llama_Liquidacion_Genera_Excel_Liquidaciones(IdUsuario, f["mes_excel"], f["mes_excel_2"]);

            GridView gv = new GridView();
            gv.DataSource = dt;//prop.ToList(); //busqueda.ToList();
            gv.DataBind();

            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=ListadoLiquidaciones_" + f["mes_excel"] + "---A---" + f["mes_excel_2"] + ".xls");
            Response.ContentType = "application/vnd.ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            return null;
        }


        [HttpPost]
        public ActionResult _TraeObservacionesPago(int id_pago)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            ViewBag.id_pago = id_pago;
            return PartialView(LiquidacionModels.Llama_Liquidacion_Observacion_Carga(id_pago,IdUsuario));
            
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult _ModificaObservacionPago(int id_pago, string observacion)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            return Content(LiquidacionModels.Llama_Liquidacion_Observacion_Actualiza(id_pago,observacion,IdUsuario));
        }

        [HttpPost]
        public ActionResult _TraeFacturaPago(int id)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            return Content("numero de factura");
        }

        [HttpPost]
        public ActionResult _ModificaNumeroFactura(int id, string numero_factura)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            return Content("true");
        }

        [HttpPost]
        public ActionResult _SubirArchivo(int id_liq, HttpPostedFileBase archivo)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            if (!System.IO.Directory.Exists(Server.MapPath("~/" + DirectorioDocumentos + "/liq_" + id_liq.ToString())))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("~/" + DirectorioDocumentos + "/liq_" + id_liq.ToString()));
            }

            if (archivo != null && archivo.ContentLength > 0)
            {

                var path = "";
                var nombreArchivo = Path.GetFileName(archivo.FileName);
                nombreArchivo = nombreArchivo.Replace(' ', '_');
                nombreArchivo = "factural_liquidacion_" + id_liq.ToString() + "_" + nombreArchivo;

                path = Path.Combine(Server.MapPath("~/" + DirectorioDocumentos + "/liq_" + id_liq.ToString()), nombreArchivo);
                try
                {
                    archivo.SaveAs(path);
                    //PropiedadesModels.RegistrarArchivoDB(IdUsuario, int.Parse(id_propiedad), int.Parse(tipo_doc), desc_doc, nombreArchivo);
                    return Content(LiquidacionModels.Llama_Liquidacion_Factura_Adjuntar(id_liq,nombreArchivo,IdUsuario));
                }
                catch (Exception ex)
                {
                    return Content("false|Error al subir archivo al servidor. ("+ex.ToString()+")|" + id_liq.ToString());
                }

            }
            else
            {
                return Content("false|No ha adjuntado un archivo.|" + id_liq.ToString());
            }
        }

        [HttpPost]
        public ActionResult _EliminarArchivo(int id_liq)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            return Content(LiquidacionModels.Llama_liquidacion_Factura_Eliminar(id_liq, IdUsuario));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult _CambiarEstadoLiquidacion(int[] id_pago, int estado, DateTime fecha, int pago_c_gar, int id_banco, string tf_num, string observacion, string fecha_proceso = "")
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            List<NuevoEstado> lst = new List<NuevoEstado>();
            //fecha = fecha.Tstring("yyyy-MM-dd hh:mm:ss");
            //string[] fec = fecha.Split('-');
            //string fecha_p = fec[2] + "-" + fec[1] + "-" + fec[0];

            foreach ( var item in id_pago)
            {
                if ( item.ToString() != "1" && item.ToString() != "0")
                {
                    //Resultados["estado"] + Resultados["mensaje"] + Resultados["id_pago"] + Resultados["estado_anterior"] + Resultados["nuevo_estado"];
                    
                    string[] cambio = LiquidacionModels.Llama_Liquidacion_CambiarEstado_Cuota(item, estado, fecha, pago_c_gar, id_banco, tf_num, IdUsuario, observacion, fecha_proceso).Split('|');
                    lst.Add(new NuevoEstado {
                        estado = cambio[0].ToString(),
                        mensaje = cambio[1].ToString(),
                        id_pago = cambio[2].ToString(),
                        estado_anterior = cambio[3].ToString(),
                        nuevo_estado = cambio[4].ToString(),
                        Usuario = cambio[5].ToString(),
                        monto = cambio[6].ToString()
                    });
                    
                    /*
                    lst.Add(new NuevoEstado
                    {
                        id_pago = item.ToString(),
                        mensaje = "Pruebas",
                        estado = estado.ToString()
                    });
                    */
                }
            }
            return PartialView(lst);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult _CambiarEstadoLiquidacionMasivo(int[] id_pago, int estado, DateTime fecha, int pago_c_gar, int id_banco, string tf_num, string[] observacion, string fecha_proceso = "")
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            List<NuevoEstado> lst = new List<NuevoEstado>();
            int x = 0;
            //string[] fec = fecha.Split('-');
            //string fecha_p = fec[2] + "-" + fec[1] + "-" + fec[0];

            foreach (var item in id_pago)
            {
                if (item.ToString() != "1" && item.ToString() != "0")
                {
                    string[] cambio = LiquidacionModels.Llama_Liquidacion_CambiarEstado_Cuota(item, estado, fecha, pago_c_gar, id_banco, tf_num, IdUsuario, observacion[x], fecha_proceso).Split('|');
                    lst.Add(new NuevoEstado
                    {
                        estado = cambio[0].ToString(),
                        mensaje = cambio[1].ToString(),
                        id_pago = cambio[2].ToString(),
                        estado_anterior = cambio[3].ToString(),
                        nuevo_estado = cambio[4].ToString(),
                        Usuario = cambio[5].ToString(),
                        monto = cambio[6].ToString()
                    });
                }
                x++;
            }
            return PartialView(lst);
        }

        [HttpPost]
        public ActionResult _Marca_Pago_Contra_Garantia(int id_pago, int b_pago_contra_garantia)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            LiquidacionModels.Llama_Liquidacion_Marca_PagoContraGarantia(id_pago, b_pago_contra_garantia, IdUsuario);
            return null;
        }

        [HttpPost]
        public ActionResult _Marca_Pago_Seguro_Arriendo(int id_pago, int b_pago_seguro_arriendo)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            LiquidacionModels.Llama_Liquidacion_Marca_PagoSeguroArriendo(id_pago, b_pago_seguro_arriendo, IdUsuario);
            return null;
        }

        [HttpPost]
        public ActionResult _EnvioLiquidacionPorMail(string m_g_file_liquidacion)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            var res = LiquidacionModels.Llama_Liquidacion_Enviar_Por_Mail(IdUsuario, m_g_file_liquidacion, 0);
            return PartialView(res);
        }

        [HttpPost]
        public ActionResult _EnvioFacturasPorMail(string m_rut, string m_mes)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            var res = LiquidacionModels.Llama_Liquidacion_Factura_Enviar_Por_Mail(IdUsuario, m_rut, m_mes, 0);
            return PartialView("_EnvioLiquidacionPorMail", res);
        }

        [HttpPost]
        public ActionResult _Aprobaciones_Comparativo(string mes, int id_estado_arriendo, int id_estado_propietario, string mes_hasta, int sac_inversionista)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            return PartialView(LiquidacionModels.Llama_Liquidacion_Genera_Excel_Aprobaciones_Comparativo(IdUsuario,mes,id_estado_arriendo,id_estado_propietario,mes_hasta,sac_inversionista,1));
        }

        [HttpPost] 
        public ActionResult _Envia_Mail_Cuando_Cambio_Estado_Cuotas(string fecha)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            LiquidacionModels.Llama_Mail_Envia_Alerta_Cambio_Estado_Cuota(0, 0, 0, IdUsuario, "", fecha, "", "", 1);
            //EXEC Mail_Envia_Alerta_Cambio_Estado_Cuota 0,0,0,10008,'','2019-12-09 12:23:29','cristobal.alcayaga@gmail.com','SGO',1
            return null;
        }
        [HttpPost]
        public ActionResult _Beneficios_Propiedad(int proc, int id_prop, int id_contrato)
        {
            ViewBag.id_prop = id_prop;
            ViewBag.id_contrato = id_contrato;
            //ViewBag.id_promesa = id_promesa;

            int id_usu = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            return PartialView(LiquidacionModels.Cargar_Beneficios_Propiedad(proc));
        }
        [HttpPost]
        public ActionResult Actualiza_Beneficios_Propiedad(int id_contrato, int id_prop, string chk_seleccionados, string chk_NO_seleccionados)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            LiquidacionModels.Llama_Actualiza_Beneficios_Propiedad(IdUsuario, id_prop, chk_seleccionados, chk_NO_seleccionados, id_contrato);
            return null;
        }

        [HttpPost]
        public ActionResult Beneficios_Propiedad_Posee(int proc, int id_prop, int id_contrato)
        {
            //int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            //PromesasModels.Llama_Promesas_Documentos2(3, id_promesa, tipo_doc, IdUsuario, "", descripcion, id_documento);
            //return null;
            return Json(new { Response = LiquidacionModels.Llama_Beneficios_Propiedad_Posee(proc, id_prop, id_contrato) }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult _Envia_Alerta_Atencion_Gerencia(string[] ids_pago, string mensaje, int tipo_correo)
        //{
        //    string pagos = "";
        //    foreach (var x in ids_pago)
        //    {
        //        pagos += x + "|";
        //    }
        //    pagos = pagos.TrimEnd('|');
        //    LiquidacionModels.Llama_Mail_Envia_Alerta_Atencion_Gerencia(pagos, mensaje, tipo_correo);
        //    return null;
        //}
        [HttpPost]
        public ActionResult _Envia_Alerta_Atencion_Gerencia_Nuevo(int tipo_correo,string fecha,string periodo)
        {
            LiquidacionModels.Llama_Mail_Envia_Alerta_Atencion_Gerencia_Nuevo(tipo_correo,fecha,periodo);
            return null;
        }

        [HttpPost]
        public ActionResult _Mail_Envia_Alerta_Atencion_Finanzas(int tipo_correo, string fecha, string periodo)
        {
            LiquidacionModels.Llama_Mail_Envia_Alerta_Atencion_Finanzas(tipo_correo, fecha, periodo);
            return null;
        }

        //[HttpPost]
        //public ActionResult _Marca_Cheque_Rescatado(int id_pago, int cheque_rescatado)
        //{
        //    int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
        //    LiquidacionModels.Llama_Liquidacion_Marca_Cheque_Rescatado(id_pago, cheque_rescatado, IdUsuario);
        //    return null;
        //} 

        [HttpPost]
        public ActionResult _Agregar_Observacion_Pago(int proc, int id_pago, string observacion)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            return Json(new { Resultado = LiquidacionModels.Llama_Pagos_Actualiza_Observacion_Graba(proc,id_pago, IdUsuario,observacion) });
        }
        [HttpGet]
        public JsonResult HistorialEstados(string id_pago)
        {
            int usuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            return Json(new { resp = LiquidacionModels.Llama_HistorialEstados(usuario, id_pago) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult VerificadorCartera(string id_propiedad, string fecha_desde, string fecha_hasta)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            //string[] fec = fecha.Split('-');
            //string la_fecha = fec[1] + "-" + fec[0] + "-28";
            // return PartialView(LiquidacionModels.Llama_Liquidacion_Carga_Lista(IdUsuario, fecha, estado_arriendo, estado_pago,0, fecha2, sac_inversionista));
            return Json(LiquidacionModels.Llama_Liquidacion_Verificador_Cartera(IdUsuario, id_propiedad,fecha_desde,fecha_hasta));
        }

        [HttpPost]
        public ActionResult VerificadorCarteraObservaciones(string id_propiedad, string fecha_desde, string fecha_hasta)
        {
            int IdUsuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            //string[] fec = fecha.Split('-');
            //string la_fecha = fec[1] + "-" + fec[0] + "-28";
            // return PartialView(LiquidacionModels.Llama_Liquidacion_Carga_Lista(IdUsuario, fecha, estado_arriendo, estado_pago,0, fecha2, sac_inversionista));
            return Json(LiquidacionModels.Llama_Liquidacion_Verificador_Cartera_Obs(IdUsuario, id_propiedad, fecha_desde, fecha_hasta));
        }

        [HttpPost]
        public JsonResult exportarExcelPersoKPIPlanilla(DateTime mes, DateTime mes_hasta)
        {
            int id_usuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            return Json(LiquidacionModels.KPI_Pago_Inversionista_Excel_Planilla(id_usuario, mes, mes_hasta));
        }

        [HttpPost]
        public JsonResult exportarExcelPersoKPIPlanilla2(DateTime mes, DateTime mes_hasta)
        {
            int id_usuario = int.Parse(Request.Cookies["cookiePerfil"]["usuario"].ToString());
            return Json(LiquidacionModels.KPI_Pago_Inversionista_Excel_Planilla2(id_usuario, mes, mes_hasta));
        }

        [HttpGet]
        public ActionResult ExportarExcelPerso1(string mes, string mes_hasta)
        {
            ///Se definene las variabkes para el uso de OfficeOpenXML


            var fecha_desde = DateTime.Parse(mes);
            var fecha_hasta = DateTime.Parse(mes_hasta);
            var format_fecha = (fecha_desde.ToString("MMMM-yy"));
            String filePath = Server.MapPath("~/Content/Plantilla/Plantilla.xlsx");
            String filePath2 = Server.MapPath("~/Content/Plantilla/Plantilla2.xlsx");
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage p = new ExcelPackage(fileInfo);
            ExcelWorksheet myWorksheet = p.Workbook.Worksheets["KPI INVERSIONISTA"];
            ExcelWorksheet myWorksheet2 = p.Workbook.Worksheets["ListadoPropiedades"];



            JsonResult jKPIPlanilla, jKPIPlanilla2;
            JArray sKPIPlanilla, sKPIPlanilla2;


            ///Se definen las variabes sacadas desde la BD

            jKPIPlanilla = exportarExcelPersoKPIPlanilla(fecha_desde, fecha_hasta);
            sKPIPlanilla = JArray.Parse(new JavaScriptSerializer().Serialize(jKPIPlanilla.Data));


            jKPIPlanilla2 = exportarExcelPersoKPIPlanilla2(fecha_desde, fecha_hasta);
            sKPIPlanilla2 = JArray.Parse(new JavaScriptSerializer().Serialize(jKPIPlanilla2.Data));

            //Variables de colores
            System.Drawing.Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#44546A");
            //Color colFromHex2 = System.Drawing.ColorTranslator.FromHtml("#E7E6E6");
            //Color colFromHex3 = System.Drawing.ColorTranslator.FromHtml("#BFBFBF");

            ///Calculo el monto mensual asignado al mes en base a los datos en la BD
            ///

            myWorksheet.Cells["A2"].Value = "KPI PAGO INVERSIONISTA";
            myWorksheet.Cells["A2"].Style.Font.Bold = true;
            myWorksheet.Cells["A2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet.Cells["A2"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet.Cells["A2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet.Cells["A2"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet.Cells["A2"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet.Cells["A2"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet.Cells["A2"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet.Cells["B2"].Value = "" + fecha_desde.ToString("MMMM-yyyy") + "";
            myWorksheet.Cells["B2"].Value = myWorksheet.Cells["B1"].Text.Trim().ToUpper();
            myWorksheet.Cells["B2"].Style.Font.Bold = true;
            myWorksheet.Cells["B2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet.Cells["B2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet.Cells["B2"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet.Cells["B2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet.Cells["B2"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet.Cells["B2"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet.Cells["B2"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet.Cells["B2"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            myWorksheet.Cells["C2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet.Cells["C2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet.Cells["C2"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet.Cells["C2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet.Cells["C2"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet.Cells["C2"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet.Cells["C2"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet.Cells["C2"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet.Cells["B2:C2"].Merge = true;

            int cont = 4;
            for (int i = 0; i < sKPIPlanilla.Count; i++)
            {
                //System.Diagnostics.Debug.WriteLine(sKPIPlanilla);
                myWorksheet.Cells[cont, 1].Value = sKPIPlanilla[i]["column1"].ToString();
                myWorksheet.Cells[cont, 2].Value = sKPIPlanilla[i]["column2"].ToString();
                myWorksheet.Cells[cont, 3].Value = float.Parse(sKPIPlanilla[i]["column3"].ToString());

                myWorksheet.Cells[myWorksheet.Dimension.Address].AutoFitColumns();
                myWorksheet.Cells[cont, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                myWorksheet.Cells[cont, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                myWorksheet.Cells[cont, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                /*
                myWorksheet.Cells[cont, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                myWorksheet.Cells[cont, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;*/

                myWorksheet.Cells[cont, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                myWorksheet.Cells[cont, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                myWorksheet.Cells[cont, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                myWorksheet.Cells[cont, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                myWorksheet.Cells[cont, 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                myWorksheet.Cells[cont, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                myWorksheet.Cells[cont, 3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                myWorksheet.Cells[cont, 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                //myWorksheet.Cells[cont, 4].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 4].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 4].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 3].Style.WrapText = true;

                //myWorksheet.Cells[cont, 2].Style.Numberformat.Format = "$#,##0";


                cont++;
            }

            myWorksheet.Cells[cont + 2, 1].Value = "REPORTE AL (" + (DateTime.Today).ToString("dd-MM-yyyy") + ")";
            myWorksheet.Cells[cont + 2, 1].Style.Font.Bold = true;
            myWorksheet.Cells[cont + 3, 1].Value = "VALIDADO POR OPERACIONES COMERCIALES";
            myWorksheet.Cells[cont + 3, 1].Style.Font.Bold = true;

            myWorksheet.Cells[myWorksheet.Dimension.Address].AutoFitColumns();


            myWorksheet2.Cells["A1"].Value = "id_pago";
            myWorksheet2.Cells["A1"].Style.Font.Bold = true;
            myWorksheet2.Cells["A1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["A1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["A1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["A1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["A1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["A1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["A1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            myWorksheet2.Cells["B1"].Value = "id_contrato";
            myWorksheet2.Cells["B1"].Style.Font.Bold = true;
            myWorksheet2.Cells["B1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["B1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["B1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["B1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["B1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["B1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["B1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["B1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            myWorksheet2.Cells["C1"].Value = "concepto";
            myWorksheet2.Cells["C1"].Style.Font.Bold = true;
            myWorksheet2.Cells["C1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["C1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["C1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["C1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["C1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["C1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["C1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["C1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            myWorksheet2.Cells["D1"].Value = "rut_propietario";
            myWorksheet2.Cells["D1"].Style.Font.Bold = true;
            myWorksheet2.Cells["D1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["D1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["D1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["D1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["D1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["D1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["D1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["D1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["E1"].Value = "propietario";
            myWorksheet2.Cells["E1"].Style.Font.Bold = true;
            myWorksheet2.Cells["E1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["E1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["E1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["E1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["E1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["E1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["E1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["E1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["F1"].Value = "direccion";
            myWorksheet2.Cells["F1"].Style.Font.Bold = true;
            myWorksheet2.Cells["F1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["F1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["F1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["F1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["F1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["F1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["F1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["F1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["G1"].Value = "num_depto";
            myWorksheet2.Cells["G1"].Style.Font.Bold = true;
            myWorksheet2.Cells["G1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["G1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["G1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["G1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["G1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["G1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["G1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["G1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            myWorksheet2.Cells["H1"].Value = "concepto1";
            myWorksheet2.Cells["H1"].Style.Font.Bold = true;
            myWorksheet2.Cells["H1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["H1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["H1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["H1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["H1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["H1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["H1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["H1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["I1"].Value = "forma_pago";
            myWorksheet2.Cells["I1"].Style.Font.Bold = true;
            myWorksheet2.Cells["I1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["I1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["I1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["I1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["I1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["I1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["I1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["I1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["J1"].Value = "numero_cheque";
            myWorksheet2.Cells["J1"].Style.Font.Bold = true;
            myWorksheet2.Cells["J1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["J1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["J1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["J1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["J1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["J1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["J1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["J1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["K1"].Value = "id_prop_arriendo";
            myWorksheet2.Cells["K1"].Style.Font.Bold = true;
            myWorksheet2.Cells["K1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["K1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["K1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["K1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["K1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["K1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["K1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["K1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["L1"].Value = "mes";
            myWorksheet2.Cells["L1"].Style.Font.Bold = true;
            myWorksheet2.Cells["L1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["L1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["L1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["L1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["L1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["L1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["L1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["L1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["M1"].Value = "arriendo";
            myWorksheet2.Cells["M1"].Style.Font.Bold = true;
            myWorksheet2.Cells["M1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["M1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["M1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["M1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["M1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["M1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["M1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["M1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["N1"].Value = "estado_arrriendo";
            myWorksheet2.Cells["N1"].Style.Font.Bold = true;
            myWorksheet2.Cells["N1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["N1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["N1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["N1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["N1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["N1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["N1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["N1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            myWorksheet2.Cells["O1"].Value = "com_admin_por";
            myWorksheet2.Cells["O1"].Style.Font.Bold = true;
            myWorksheet2.Cells["O1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["O1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["O1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["O1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["O1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["O1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["O1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["O1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            myWorksheet2.Cells["P1"].Value = "com_neta";
            myWorksheet2.Cells["P1"].Style.Font.Bold = true;
            myWorksheet2.Cells["P1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["P1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["P1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["P1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["P1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["P1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["P1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["P1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["Q1"].Value = "com_iva";
            myWorksheet2.Cells["Q1"].Style.Font.Bold = true;
            myWorksheet2.Cells["Q1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["Q1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["Q1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["Q1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["Q1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["Q1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["Q1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["Q1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["R1"].Value = "com_total";
            myWorksheet2.Cells["R1"].Style.Font.Bold = true;
            myWorksheet2.Cells["R1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["R1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["R1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["R1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["R1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["R1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["R1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["R1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["S1"].Value = "descuentos";
            myWorksheet2.Cells["S1"].Style.Font.Bold = true;
            myWorksheet2.Cells["S1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["S1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["S1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["S1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["S1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["S1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["S1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["S1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["T1"].Value = "mes_gracia";
            myWorksheet2.Cells["T1"].Style.Font.Bold = true;
            myWorksheet2.Cells["T1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["T1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["T1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["T1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["T1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["T1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["T1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["T1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["U1"].Value = "a_pagar";
            myWorksheet2.Cells["U1"].Style.Font.Bold = true;
            myWorksheet2.Cells["U1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["U1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["U1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["U1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["U1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["U1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["U1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["U1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["V1"].Value = "estado_pago";
            myWorksheet2.Cells["V1"].Style.Font.Bold = true;
            myWorksheet2.Cells["V1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["V1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["V1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["V1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["V1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["V1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["V1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["V1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["W1"].Value = "fecha_pago";
            myWorksheet2.Cells["W1"].Style.Font.Bold = true;
            myWorksheet2.Cells["W1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["W1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["W1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["W1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["W1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["W1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["W1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["W1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["X1"].Value = "ejecutivo";
            myWorksheet2.Cells["X1"].Style.Font.Bold = true;
            myWorksheet2.Cells["X1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["X1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["X1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["X1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["X1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["X1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["X1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["X1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            myWorksheet2.Cells["Y1"].Value = "kam_inversionista";
            myWorksheet2.Cells["Y1"].Style.Font.Bold = true;
            myWorksheet2.Cells["Y1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["Y1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["Y1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["Y1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["Y1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["Y1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["Y1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["Y1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["Z1"].Value = "id_kam_inversionista";
            myWorksheet2.Cells["Z1"].Style.Font.Bold = true;
            myWorksheet2.Cells["Z1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["Z1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["Z1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["Z1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["Z1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["Z1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["Z1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["Z1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            myWorksheet2.Cells["AA1"].Value = "estado_factura";
            myWorksheet2.Cells["AA1"].Style.Font.Bold = true;
            myWorksheet2.Cells["AA1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["AA1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["AA1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["AA1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["AA1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AA1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AA1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AA1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["AB1"].Value = "mail";
            myWorksheet2.Cells["AB1"].Style.Font.Bold = true;
            myWorksheet2.Cells["AB1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["AB1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["AB1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["AB1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["AB1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AB1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AB1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AB1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            myWorksheet2.Cells["AC1"].Value = "observacion";
            myWorksheet2.Cells["AC1"].Style.Font.Bold = true;
            myWorksheet2.Cells["AC1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["AC1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["AC1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["AC1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["AC1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AC1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AC1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AC1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            myWorksheet2.Cells["AD1"].Value = "pago_contra_garantia";
            myWorksheet2.Cells["AD1"].Style.Font.Bold = true;
            myWorksheet2.Cells["AD1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            myWorksheet2.Cells["AD1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            myWorksheet2.Cells["AD1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
            myWorksheet2.Cells["AD1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
            myWorksheet2.Cells["AD1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AD1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AD1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            myWorksheet2.Cells["AD1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            int cont2 = 2;
            for (int i = 0; i < sKPIPlanilla2.Count; i++)
            {
                //System.Diagnostics.Debug.WriteLine(sKPIPlanilla2);
                myWorksheet2.Cells[cont2, 1].Value = sKPIPlanilla2[i]["id_pago"].ToString();
                myWorksheet2.Cells[cont2, 2].Value = sKPIPlanilla2[i]["id_contrato"].ToString();
                myWorksheet2.Cells[cont2, 3].Value = sKPIPlanilla2[i]["concepto"].ToString();
                myWorksheet2.Cells[cont2, 4].Value = sKPIPlanilla2[i]["rut_propietario"].ToString();
                myWorksheet2.Cells[cont2, 5].Value = sKPIPlanilla2[i]["propietario"].ToString();
                myWorksheet2.Cells[cont2, 6].Value = sKPIPlanilla2[i]["direccion"].ToString();
                myWorksheet2.Cells[cont2, 7].Value = sKPIPlanilla2[i]["num_depto"].ToString();
                myWorksheet2.Cells[cont2, 8].Value = sKPIPlanilla2[i]["concepto"].ToString();
                myWorksheet2.Cells[cont2, 9].Value = sKPIPlanilla2[i]["forma_pago"].ToString();
                myWorksheet2.Cells[cont2, 10].Value = sKPIPlanilla2[i]["numero_cheque"].ToString();
                myWorksheet2.Cells[cont2, 11].Value = sKPIPlanilla2[i]["id_prop_arriendo"].ToString();
                myWorksheet2.Cells[cont2, 12].Value = sKPIPlanilla2[i]["mes"].ToString();
                myWorksheet2.Cells[cont2, 13].Value = sKPIPlanilla2[i]["arriendo"].ToString();
                myWorksheet2.Cells[cont2, 14].Value = sKPIPlanilla2[i]["estado_arriendo"].ToString();
                myWorksheet2.Cells[cont2, 15].Value = sKPIPlanilla2[i]["com_admin_por"].ToString();
                myWorksheet2.Cells[cont2, 16].Value = sKPIPlanilla2[i]["com_neta"].ToString();
                myWorksheet2.Cells[cont2, 17].Value = sKPIPlanilla2[i]["com_iva"].ToString();
                myWorksheet2.Cells[cont2, 18].Value = sKPIPlanilla2[i]["com_total"].ToString();
                myWorksheet2.Cells[cont2, 19].Value = sKPIPlanilla2[i]["descuentos"].ToString();
                myWorksheet2.Cells[cont2, 20].Value = sKPIPlanilla2[i]["mes_gracia"].ToString();
                myWorksheet2.Cells[cont2, 21].Value = sKPIPlanilla2[i]["a_pagar"].ToString();
                myWorksheet2.Cells[cont2, 22].Value = sKPIPlanilla2[i]["estado_pago"].ToString();
                myWorksheet2.Cells[cont2, 23].Value = sKPIPlanilla2[i]["fecha_pago"].ToString();
                myWorksheet2.Cells[cont2, 24].Value = sKPIPlanilla2[i]["ejecutivo"].ToString();
                myWorksheet2.Cells[cont2, 25].Value = sKPIPlanilla2[i]["kam_inversionista"].ToString();
                myWorksheet2.Cells[cont2, 26].Value = sKPIPlanilla2[i]["id_kam_inversionista"].ToString();
                myWorksheet2.Cells[cont2, 27].Value = sKPIPlanilla2[i]["estado_factura"].ToString();
                myWorksheet2.Cells[cont2, 28].Value = sKPIPlanilla2[i]["mail"].ToString();
                myWorksheet2.Cells[cont2, 29].Value = sKPIPlanilla2[i]["observacion"].ToString();
                myWorksheet2.Cells[cont2, 30].Value = sKPIPlanilla2[i]["pago_contra_garantia"].ToString();

                myWorksheet2.Cells[myWorksheet.Dimension.Address].AutoFitColumns();
                myWorksheet2.Cells[cont2, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                myWorksheet2.Cells[cont2, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                myWorksheet2.Cells[cont2, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                /*
                myWorksheet.Cells[cont, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                myWorksheet.Cells[cont, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;*/

                //myWorksheet.Cells[cont, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                //myWorksheet.Cells[cont, 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                //myWorksheet.Cells[cont, 4].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 4].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 4].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                //myWorksheet.Cells[cont, 3].Style.WrapText = true;

                //myWorksheet.Cells[cont, 2].Style.Numberformat.Format = "$#,##0";


                cont2++;
            }

            myWorksheet2.Cells[myWorksheet.Dimension.Address].AutoFitColumns();

            ///Guardamos el archivo
            FileInfo doc = new FileInfo(filePath2);
            p.SaveAs(doc);

            ///Devolvemos el archivo ya guardado
            return File(filePath2, "Application/x-msexcel", "KPI INVERSIONISTA " + format_fecha + ".xlsx");
        }

    }

}