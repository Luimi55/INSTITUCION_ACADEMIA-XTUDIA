using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INSTITUCION_ACADEMIA_XTUDIA.Models
{
    public class Tutores
    {
        public System.Guid tutorid { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public System.DateTime fechanacimiento { get; set; }
        public int lugarnacimientoid { get; set; }
        public string fotografia { get; set; }
        public int estadocivilid { get; set; }
        public string lugartrabajo { get; set; }
        public string direccion { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public int tipotutorid { get; set; }
    }
}