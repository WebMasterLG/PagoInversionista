using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using ClosedXML.Excel;
using System.Globalization;

namespace corretaje.clases
{
    public class Funciones
    {
        CultureInfo provider = CultureInfo.InvariantCulture;

        public string Archivo;
        public void SetArchivo(string valor) { Archivo = valor; }

        public void ProcesaExcel()
        {
            string pp = "";
            string fecha = "";
            string cta = "";
            string rut = "";
            var excel = new XLWorkbook(Archivo);
            foreach (IXLWorksheet pestana in excel.Worksheets)
            {
                pp = pestana.Name;
                if (pp != "ESCANEADOS" && pp != "CALENDARIO")
                {
                    fecha = DateTime.ParseExact(pp, "ddMMyyyy", provider).ToString("yyyy-MM-dd");
                    var filas = excel.Worksheet(pp).RowsUsed();
                    foreach (var fila in filas)
                    {
                        if (fila.RowNumber() >= 2)
                        {
                            cta = fila.Cell(2).Value.ToString();
                            rut = fila.Cell(11).Value.ToString();
                        }
                    }
                }
                pp = "";

            }
            //ESCANEADOS
            //CALENDARIO
            //var excel = new ExcelQueryFactory(Archivo);
            //var hojas = excel.GetWorksheetNames();

        }

    }
}