using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INSTITUCION_ACADEMIA_XTUDIA.Models
{
    public class Estudiante
    {
        public System.Guid estudianteid { get; set; }
        public string matricula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public System.DateTime fechanacimiento { get; set; }
        public int lugarnacimientoid { get; set; }
        public string correo { get; set; }
        public string fotografia { get; set; }
        public int cursoid { get; set; }
        public string seccion { get; set; }
        public int nacionalidadid { get; set; }
        public int tiposangreid { get; set; }
    }
}