using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace corretaje.Helpers
{
    public static class Constant
    {
        public enum Verbs
        {
            GET = 1,
            POST = 2
        }

        public enum NumDocFirma
        {
            Contrato = 3,
            Promesa = 1
        }

        public enum EnumEstadoFirma
        {
            Firmado = 1,
            Notificado = 2,
            Pendiente = 3
        }

        public enum EnumSPFirmaArriendo
        {
            Contrato,
            Mandato,
            Anexo
        }

        public static string GetSpDoc(String SpType)
        {
            return ConfigurationManager.AppSettings.Get(SpType);

        }

      

        public static string UrlFirmaDigital
        {
            get{ return ConfigurationManager.AppSettings.Get("UrlFirmaDigital"); }
        }

        public static string UrlContratosPDF
        {
            get { return ConfigurationManager.AppSettings.Get("UrlContratosPDF"); }
        }

        public static string contratoConexion
        {
            get { return ConfigurationManager.AppSettings.Get("contratoConexion"); }
        }
    }
}