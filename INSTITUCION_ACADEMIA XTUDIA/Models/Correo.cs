using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INSTITUCION_ACADEMIA_XTUDIA.Models
{
    public class Correo
    {
        public int correoid { get; set; }
        public string correoelectronico { get; set; }
        public System.Guid tutorid { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public int Tutor { get; set; }
    }
}