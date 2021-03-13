using Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvcLab1.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            if (!IApp.UsuarioSesion.IdUsuario.HasValue) return Redirect("/Login");
            var Empresas = IApp.empresaService.ObtenerLista(null);
            if (TempData.ContainsKey("msg")) ViewData["msg"] = TempData["msg"].ToString();
            return View(Empresas);
        }

        public ActionResult Edit(int? id)
        {
            if (!IApp.UsuarioSesion.IdUsuario.HasValue) return Redirect("/Login");
            var entity = new EmpresaEntity();
            try
            {
                ViewBag.Form = false;
                if (id.HasValue)
                {
                    ViewBag.Form = true;
                    entity = IApp.empresaService.ObtenerLista(id).FirstOrDefault();
                
                }
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

            return View(entity);
        
        }

        [HttpPost]
        public ActionResult Save(EmpresaEntity entity)
        {

            
            try
            {

                var result = new DBEntity();
                if(entity.IdEmpresa.HasValue)
                {

                    result = IApp.empresaService.Actualizar(entity);
                    TempData["msg"] = "Se actualizo el registro con exito!";


                }
                else
                {
                    result = IApp.empresaService.Insertar(entity);
                    TempData["msg"] = "Se inserto el registro con exito!";

                }

                if (result.CodeError != 0) throw new Exception(result.MsgError);

                return RedirectToAction("index");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

            
        }

        [HttpGet]
        public ActionResult Delete(int id) {

            try
            {
                var result = IApp.empresaService.Eliminar(new EmpresaEntity { IdEmpresa = id });
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