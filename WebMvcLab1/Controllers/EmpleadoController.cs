using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBL;
using WebMvcLab1.Models;

namespace WebMvcLab1.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado

        private IEmpleadoService EmpleadoService;
        private IEmpresaService EmpresaService;
        private ITipoIdentificacionService TipoIdentificacionService;

        public EmpleadoController(IEmpleadoService empleadoService, IEmpresaService empresaService, ITipoIdentificacionService tipoIdentificacionService)
        {
            EmpleadoService = empleadoService;
            EmpresaService = empresaService;
            TipoIdentificacionService = tipoIdentificacionService;
        }

        public ActionResult Index()
        {
            if (!IApp.UsuarioSesion.IdUsuario.HasValue) return Redirect("/Login");

            var Empleados = EmpleadoService.ObtenerLista(null);
            if (TempData.ContainsKey("msg")) ViewData["msg"] = TempData["msg"].ToString();
            return View(Empleados);
        }

        public ActionResult Edit(int? id) {


            if (!IApp.UsuarioSesion.IdUsuario.HasValue) return Redirect("/Login");
            var entity = new EmpleadoEdit() { empleado = new EmpleadoEntity() };


            try
            {
                ViewBag.Form = false;
                if (id.HasValue)
                {
                    ViewBag.Form = true;
                    entity.empleado = EmpleadoService.ObtenerDetalle(id);

                }

                entity.ddlTipoIdentificacion = TipoIdentificacionService.Obtenerddl();
                entity.ddlEmpresa = EmpresaService.Obtenerddl();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

            return View(entity);
        }

        [HttpPost]
        public ActionResult Save(EmpleadoEntity entity) {

            try
            {
                var result = new DBEntity();

                if (entity.IdEmpleado.HasValue) {

                    result = EmpleadoService.Actualizar(entity);


                }

                else
                {
                    result = EmpleadoService.Insertar(entity);
                }

                return Json(result);

            }
            catch (Exception ex)
            {

                return Json(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            try
            {
                var result = EmpleadoService.Eliminar(new EmpleadoEntity { IdEmpleado = id });
                TempData["msg"] = "0";

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