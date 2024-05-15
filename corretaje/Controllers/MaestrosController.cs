using System.Web.Mvc;
using corretaje.Clases;
using corretaje.Models;
using System.IO;
using System.Configuration;
using System;

namespace corretaje.Controllers
{
    public class MaestrosController : Controller
    {
        [HttpPost]
        public JsonResult CargarLista(int idLista)
        {
            //if (Request.Cookies["cookiePerfil"].Value == "1")
            //{
                return Json(new { Listas = MaestrosModel.CargarLista(idLista) });
            //}
            //else
            //{
            //    if (idLista != 1 && idLista != 2 && idLista != 3 && idLista != 4 && idLista != 5 && idLista != 6 && idLista != 7 && idLista != 8 && idLista != 13 && idLista != 12 && idLista != 14)
            //    {
            //        string[] rutUsuario = User.Identity.Name.Split('-');
            //        return Json(new { Listas = MaestrosModel.CargaInmobAsesor(int.Parse(rutUsuario[0])) });
            //    }
            //    else
            //    {
            //        return Json(new { Listas = MaestrosModel.CargarLista(idLista) });
            //    }
            //}

        }

        //[HttpPost]
        //public JsonResult CargaComunas(int idRegion)
        //{
        //    return Json(new { Comunas = MaestrosModel.CargaComunas(idRegion) });           
        //}

        //[HttpPost]
        //public JsonResult CargaProyectos(int idInmobiliaria)
        //{
        //    if (Request.Cookies["cookiePerfil"].Value == "1")
        //    {
        //        return Json(new { Proyectos = MaestrosModel.CargaProyectos(idInmobiliaria) });
        //    }
        //    else
        //    {
        //        string[] rutUsuario = User.Identity.Name.Split('-');
        //        return Json(new { Proyectos = MaestrosModel.CargaProyectosUsuario(idInmobiliaria, int.Parse(rutUsuario[0])) });
        //    }            
        //}

        //[HttpPost]
        //public JsonResult CargaUnidades(int idProyecto) { return Json(new { Unidades = MaestrosModel.CargaUnidades(idProyecto) }); }


        //[HttpPost]
        //public JsonResult CargaClientes()
        //{
        //    string[] rut = User.Identity.Name.Split('-');
        //    return Json(new { Clientes = ClientesModel.CargarClientes(rut[0]) });
        //}
        
    }
}
