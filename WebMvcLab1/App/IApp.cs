using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WBL;

namespace WebMvcLab1
{
    public struct IApp
    {

        public static IEmpresaService empresaService => new EmpresaService();

        public static ITipoIdentificacionService tipoIdentificacionService => new TipoIdentificacionService();

        public static IEmpleadoService empleadoService => new EmpleadoService();

        public static UsuarioEntity UsuarioSesion => HttpContext.Current.Session["UsuarioSession"] as UsuarioEntity ?? new UsuarioEntity();

    }
}