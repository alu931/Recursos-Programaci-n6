using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBL;

namespace WebMvcLab1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Usuario
        private IUsuarioService UsuarioService;

        public LoginController(IUsuarioService usuarioService) {

            UsuarioService = usuarioService;
        
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginUser(UsuarioEntity entity)
        {
            try
            {
                var result = UsuarioService.UsuarioLogin(entity);

                if (result.CodeError == 0)
                {
                    Session["UsuarioSession"] = result;
                }

                return Json(result);

            }
            catch (Exception ex)
            {

                return Json(new UsuarioEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }


        [HttpPost]
        public JsonResult RegistrarUsuario(UsuarioEntity entity)
        {
            try
            {
                var result = UsuarioService.Insertar(entity);


                return Json(result);

            }
            catch (Exception ex)
            {

                return Json(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return Redirect("/Login");
        }



    }
}