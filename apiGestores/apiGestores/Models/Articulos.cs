using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Articulos
    {
        public Articulos()
        {
            ComprasDet = new HashSet<ComprasDet>();
            ReparacionesDet = new HashSet<ReparacionesDet>();
        }

        public int ArtCodigo { get; set; }
        public string ArtDenom { get; set; }
        public int EstaCodigo { get; set; }

        public virtual Estados EstaCodigoNavigation { get; set; }
        public virtual ArticulosDet ArticulosDet { get; set; }
        public virtual ICollection<ComprasDet> ComprasDet { get; set; }
        public virtual ICollection<ReparacionesDet> ReparacionesDet { get; set; }
    }
}
