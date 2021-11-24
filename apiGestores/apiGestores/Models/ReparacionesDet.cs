using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class ReparacionesDet
    {
        public int RepaCodigo { get; set; }
        public int? ArtCodigo { get; set; }
        public int? RepadPrecio { get; set; }
        public string RepadAccion { get; set; }

        public virtual Articulos ArtCodigoNavigation { get; set; }
        public virtual Reparaciones RepaCodigoNavigation { get; set; }
    }
}
