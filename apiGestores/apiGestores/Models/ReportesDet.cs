using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class ReportesDet
    {
        public int RepCodigo { get; set; }
        public int ArtCodigo { get; set; }
        public int CueCodigo { get; set; }
        public int? RepCantidad { get; set; }
        public int? RepTotal { get; set; }

        public virtual Reportes RepCodigoNavigation { get; set; }
    }
}
