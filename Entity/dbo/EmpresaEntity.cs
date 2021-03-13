using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EmpresaEntity: En
    {
        public int? IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }

        public bool Estado { get; set; }
    }
}
