using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class ComprasDet
    {
        public int ComCodigo { get; set; }
        public int ArtCodigo { get; set; }
        public int? ImpCodigo { get; set; }
        public int? ComdTotal { get; set; }

        public virtual Articulos ArtCodigoNavigation { get; set; }
        public virtual Compras ComCodigoNavigation { get; set; }
        public virtual Impuestos ImpCodigoNavigation { get; set; }
    }
}
