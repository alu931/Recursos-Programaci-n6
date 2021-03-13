using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EmpleadoEntity: En
    {
        public int? IdEmpleado { get; set; }

        public int? IdTipoIdentificacion { get; set; }

        //foreign Key

        public TipoIdentificacionEntity TipoIdentificacion { get; set; }

        public int? IdEmpresa { get; set; }

        //Foreign Key

        public EmpresaEntity Empresa { get; set; }

        public string Identificacion { get; set; }

        public string NombreEmpleado { get; set; }

        public int Edad { get; set; }

        public string Sexo { get; set; }

        public bool Estado { get; set; }

        public bool TieneVehiculo { get; set; }

        public string Vehiculos { get; set; }

        public EmpleadoEntity()
        {
            Empresa = Empresa ?? new EmpresaEntity();
            TipoIdentificacion = TipoIdentificacion ?? new TipoIdentificacionEntity();

        }

    }
}
