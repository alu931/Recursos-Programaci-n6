using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvcLab1.Models
{
    public class EmpleadoEdit
    {
        public EmpleadoEntity empleado { get; set; }
        public List<TipoIdentificacionEntity> ddlTipoIdentificacion { get; set; }

        public List<EmpresaEntity> ddlEmpresa{ get; set; }
    }
}