using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hegoburu.Contabilidad.Core
{
    /// <summary>
    /// Algo que se puede pagar, una obligacion de pago.
    /// </summary>
    public class Pagable
    {
        public virtual DateTime Fecha { get; set; }
        public virtual List<Vencimiento> Vencimientos { get; set; }
        public virtual bool Pagado { get; set; }
        public virtual double Monto { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Comentarios { get; set; }
    }
}
