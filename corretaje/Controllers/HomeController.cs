using System;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using corretaje.Clases;
using corretaje.Models;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Configuration;

namespace Cotizaciones.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                string ip = HttpContext.Request.UserHostAddress;
                string[] rutUsuario = User.Identity.Name.Split('-');
                //bool estado = LogModels.GuardarLOG(1, int.Parse(rutUsuario[0]), ip, "LOGIN");

                return RedirectToAction("index", "propiedades");
            }
            else { return RedirectToAction("Login"); }
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            return View("~/Shared/Error.cshtml");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.Cookies["cookiePerfil"] != null)
            {
                return RedirectToAction("Index", "propiedades");
            }
            else
            {
                return View();
            }                
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios Usuario)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(Usuario.Rut)) ModelState.AddModelError("", "Debe ingresar un Rut");
                if (String.IsNullOrEmpty(Usuario.Pass)) ModelState.AddModelError("", "Debe ingresar una contraseña");
                if (!String.IsNullOrEmpty(Usuario.Rut) && !String.IsNullOrEmpty(Usuario.Pass))
                {
                    if (UsuariosModels.ValidaUsuario(Usuario.Rut, Usuario.Pass))
                    {
                        string[] rut = Usuario.Rut.Split('-');
                        List<Usuarios> lst = UsuariosModels.CargarUsuarios(int.Parse(rut[0]));//.Where(u => u.Rut == Usuario.Rut).ToList()[0].IdPerfil.ToString();

                        double hrsCookiesExpiration = double.Parse(ConfigurationManager.AppSettings["hrsCookiesExpiration"]);
                        DateTime expires = DateTime.Now.AddHours(hrsCookiesExpiration).AddSeconds(30);

                        HttpCookie addCookie = new HttpCookie("cookiePerfil");
                        foreach (var item in lst)
                        {
                            addCookie["estado"] = "true";
                            addCookie["usuario"] = item.Id.ToString();
                            addCookie["nombre_usuario"] = item.Nombre.ToString();

                            // Asignar perfil, subperfil y área específicos a usuarios seleccionados
                            if (item.Id == 110508 || item.Id == 140663 || item.Id == 120617 || item.Id == 120609)
                            {
                                addCookie["perfil"] = "14"; // Perfil específico
                                addCookie["idArea"] = "6"; // Área específica
                                addCookie["idSubper"] = "2"; // Subperfil específico
                            }
                            else
                            {
                                addCookie["perfil"] = item.IdPerfil.ToString();
                                addCookie["idArea"] = item.IdArea.ToString();
                                addCookie["idSubper"] = item.IdSubPerfil.ToString();
                            }
                        }
                        //, UsuariosModels.CargarUsuarios(0).Where(u => u.Rut == Usuario.Rut).ToList()[0].IdPerfil.ToString());
                        addCookie.Expires = expires;
                        Response.Cookies.Add(addCookie);

                        FormsAuthentication.SetAuthCookie(Usuario.Rut, false);

                        //string ip = HttpContext.Request.UserHostAddress;
                        //bool estado = LogModels.GuardarLOG(1, Usuario.Rut, ip, "LOGIN");

                        //#region Login para E-Ticketing
                        //using (WebClient client = new WebClient())
                        //{
                        //    byte[] response = client.UploadValues(ConfigurationManager.AppSettings["urlAPI"] + "api/token", new NameValueCollection()
                        //    {
                        //        { "userName", Usuario.Rut.Replace("-", "") },
                        //        { "password", Usuario.originalPassword },
                        //        { "rememberMe", "false" },
                        //        { "grant_type", "password" },
                        //    });
                        //    ETicketingToken token = JsonConvert.DeserializeObject<ETicketingToken>(Encoding.UTF8.GetString(response));

                        //    HttpCookie eticketingCookie = new HttpCookie("eticketingCookie");
                        //    eticketingCookie["accessToken"] = token.access_token;
                        //    eticketingCookie["refresh_token"] = token.refresh_token;
                        //    eticketingCookie.Expires = expires;
                        //    Response.Cookies.Add(eticketingCookie);

                        //    HttpCookie accessToken = new HttpCookie("accessToken", token.access_token);
                        //    accessToken.Expires = expires;
                        //    Response.Cookies.Add(accessToken);

                        //    HttpCookie refreshToken = new HttpCookie("refresh_token", token.refresh_token);
                        //    refreshToken.Expires = expires;
                        //    Response.Cookies.Add(refreshToken);
                        //}
                        //#endregion

                        if (string.IsNullOrEmpty(Request.Form["redirect_url"]))
                            return RedirectToAction("Index", "propiedades");
                        else
                            return Redirect(Request.Form["redirect_url"]);
                    }
                }

            }
            return View(Usuario);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult CerrarSesion()
        {

            FormsAuthentication.SignOut();
            //return RedirectToAction("Login");

            HttpCookie galletita = new HttpCookie("cookiePerfil");

            galletita["estado"] = "";
            galletita["usuario"] = "";
            galletita["perfil"] = "";
            galletita["nombre_usuario"] = "";
            galletita.Expires = DateTime.Now.AddDays(-1d);

            Response.Cookies.Add(galletita);

            #region Logout para E-Ticketing
            HttpCookie eticketingCookie = new HttpCookie("eticketingCookie");
            eticketingCookie["accessToken"] = "";
            eticketingCookie["refresh_token"] = "";
            eticketingCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(eticketingCookie);

            HttpCookie accessToken = new HttpCookie("accessToken", "");
            accessToken.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(accessToken);

            HttpCookie refreshToken = new HttpCookie("refresh_token", "");
            refreshToken.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(refreshToken);
            #endregion

            System.Threading.Thread.Sleep(1000);

            //return RedirectToAction("index", "home");
            return RedirectToAction("Login");


        }

        [HttpPost]
        public JsonResult CargaPerfilUsuario() { return Json(new { Usuario = UsuariosModels.CargarPerfilUsuario(new Usuarios { Rut = User.Identity.Name }) }); }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ExcelExport(string TablaExport)
        {
            //Response.AddHeader("content-disposition", "attachment; filename=Export.xls");
            //this.Response.ContentType = "application/vnd.ms-excel";
            //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(TablaExport);
            //return File(buffer, "application/vnd.ms-excel");

            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment; filename=Export.xls");
            //Response.ContentType = "application/ms-excel";

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Export.xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            Response.Write(TablaExport);
            Response.End();

            //Response.Output.Write(TablaExport);
            //Response.Flush();
            //Response.End();
            return View();
        }

        public ActionResult salir()
        {
            //FormsAuthentication.SignOut();
            //return RedirectToAction("Login");


            HttpCookie galletita = new HttpCookie("cookiePerfil");

            galletita["estado"] = "";
            galletita["usuario"] = "";
            galletita["perfil"] = "";
            galletita["nombre_usuario"] = "";
            galletita.Expires = DateTime.Now.AddDays(-1d);

            Response.Cookies.Add(galletita);

            #region Logout para E-Ticketing
            HttpCookie eticketingCookie = new HttpCookie("eticketingCookie");
            eticketingCookie["accessToken"] = "";
            eticketingCookie["refresh_token"] = "";
            eticketingCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(eticketingCookie);

            HttpCookie accessToken = new HttpCookie("accessToken", "");
            accessToken.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(accessToken);

            HttpCookie refreshToken = new HttpCookie("refresh_token", "");
            refreshToken.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(refreshToken);
            #endregion

            System.Threading.Thread.Sleep(1000);


            return RedirectToAction("index", "home");
        }
    }
}
