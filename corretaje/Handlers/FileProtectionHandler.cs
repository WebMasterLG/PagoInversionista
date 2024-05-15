using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace corretaje.Handlers
{
    public class FileProtectionHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Cookies["cookiePerfil"] == null && context.Request.Cookies["coneccionIF"] == null)
            {
                context.Response.Redirect("~/");
                return;
            }
            else
            {
                string requestedFile = context.Server.MapPath(context.Request.FilePath);
                SendContentTypeAndFi1e(context, requestedFile);
            }
        }

        private HttpContext SendContentTypeAndFi1e(HttpContext context, string strFile)
        {
            context.Response.ContentType = MimeMapping.GetMimeMapping(strFile);
            context.Response.TransmitFile(strFile);
            context.Response.End();
            return context;
        }
    }
}
