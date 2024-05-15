using System.Web.Mvc;
using corretaje.Clases;
using corretaje.Models;

namespace Cotizaciones.Controllers
{
   
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/
        public ActionResult Index()
        {
            if (Request.Cookies["cookiePerfil"] != null)
            {
                return View(UsuariosModels.CargarUsuarios(0));
            }
            else
            {
                //return RedirectToAction("home", "index");
                return Redirect(Url.Action("Login", "Home") + "?url=" + Url.Action("Index"));
            }            
        }

        [HttpPost]
        public JsonResult IngresarUsuario(Usuarios Usuario) { return Json(new { Exitoso = UsuariosModels.IngresarUsuario(Usuario) }); }

        [HttpPost]
        public JsonResult ActualizarUsuario(Usuarios Usuario) { return Json(new { Exitoso = UsuariosModels.ActualizarUsuario(Usuario) }); }

        [HttpPost]
        public JsonResult EliminarUsuario(int Usuario) { return Json(new { Exitoso = UsuariosModels.EliminarUsuario(Usuario) }); }

        [HttpPost]
        public JsonResult CargarUsuario(int Usuario) { return Json(new { Usuario = UsuariosModels.CargarUsuario(Usuario) }); }

        [HttpPost]
        public JsonResult CargarUsuarios()
        {
            string[] rutUsuario = User.Identity.Name.Split('-');
            return Json(new { Usuarios = UsuariosModels.CargarUsuarios(int.Parse(rutUsuario[0])) });
        }

    }
}
