using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class ArticulosDet
    {
        public int ArtCodigo { get; set; }
        public string ArtColor { get; set; }
        public int? ArtPrecio { get; set; }
        public int FabCodigo { get; set; }
        public int SucCodigo { get; set; }
        public int? ProveCodigo { get; set; }
        public int? ModCodigo { get; set; }

        public virtual Articulos ArtCodigoNavigation { get; set; }
        public virtual Fabricantes FabCodigoNavigation { get; set; }
        public virtual Modelos ModCodigoNavigation { get; set; }
        public virtual Proveedores ProveCodigoNavigation { get; set; }
        public virtual Sucursales SucCodigoNavigation { get; set; }
    }
}
