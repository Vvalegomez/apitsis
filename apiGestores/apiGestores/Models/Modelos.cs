using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Modelos
    {
        public Modelos()
        {
            ArticulosDet = new HashSet<ArticulosDet>();
        }

        public int ModCodigo { get; set; }
        public string ModDenom { get; set; }
        public int EstaCodigo { get; set; }

        public virtual Estados EstaCodigoNavigation { get; set; }
        public virtual ICollection<ArticulosDet> ArticulosDet { get; set; }
    }
}
