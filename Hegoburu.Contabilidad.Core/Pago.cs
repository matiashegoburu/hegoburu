using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hegoburu.Contabilidad.Core
{
    public class Pago
    {
        public virtual DateTime Fecha { get; set; }
        public virtual double Monto { get; set; }

        /// <summary>
        /// Pagable el cual este pago cancela total o parcialmente.
        /// </summary>
        public virtual Pagable Pagable { get; set; }
    }
}
