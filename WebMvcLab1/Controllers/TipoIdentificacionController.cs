using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvcLab1.Controllers
{
    public class TipoIdentificacionController : Controller
    {
        // GET: TipoIdentificacion
        public ActionResult Index()
        {
            if (!IApp.UsuarioSesion.IdUsuario.HasValue) return Redirect("/Login");
            var TiposIdentificaciones = IApp.tipoIdentificacionService.ObtenerLista(null);

            if (TempData.ContainsKey("msg")) ViewData["msg"] = TempData["msg"].ToString();

            return View(TiposIdentificaciones);

        }
        public ActionResult Edit(int? id)
        {
            if (!IApp.UsuarioSesion.IdUsuario.HasValue) return Redirect("/Login");
            var entity = new TipoIdentificacionEntity();
            try
            {
                ViewBag.Form = false;
                if (id.HasValue)
                {
                    //editar
                    ViewBag.Form = true;

                    entity = IApp.tipoIdentificacionService.ObtenerLista(id).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


            return View(entity);
        }

        [HttpPost]
        public ActionResult Save(TipoIdentificacionEntity entity)
        {
            try
            {
                var result = new DBEntity();

                if (entity.IdTipoIdentificacion.HasValue)
                {

                    result = IApp.tipoIdentificacionService.Actualizar(entity);
                    TempData["msg"] = "Se actualizo el registro con exito!";

                }
                else
                {
                    result = IApp.tipoIdentificacionService.Insertar(entity);

                    TempData["msg"] = "Se agrego el registro con exito!";
                }

                if (result.CodeError != 0) throw new Exception(result.MsgError);


                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = IApp.tipoIdentificacionService.Eliminar(new TipoIdentificacionEntity { IdTipoIdentificacion = id });
                TempData["msg"] = "Se elimino el registro con exito!";

                if (result.CodeError != 0) throw new Exception(result.MsgError);

                return RedirectToAction("index");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }
    }
}