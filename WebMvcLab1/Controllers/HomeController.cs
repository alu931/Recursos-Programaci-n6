using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvcLab1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (!IApp.UsuarioSesion.IdUsuario.HasValue) return Redirect("/Login");
            return View();
        }
    }
}