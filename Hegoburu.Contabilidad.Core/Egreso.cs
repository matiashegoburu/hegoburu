using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hegoburu.Contabilidad.Core
{
    public class Egreso
    {
        public virtual string Codigo { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual double Monto { get; set; }
        public virtual List<Pagable> Pagables { get; set; } 
        public virtual string Descripcion { get; set; }
        public virtual string Comentarios { get; set; }
        public virtual bool Cancelado { get; set; }
    }
}
