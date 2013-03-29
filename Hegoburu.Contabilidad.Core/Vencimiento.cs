using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hegoburu.Contabilidad.Core
{
    public class Vencimiento
    {
        public virtual DateTime Fecha { get; set; }
        public virtual double Incremento { get; set; }
    }
}
