using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Impuestos
    {
        public Impuestos()
        {
            ComprasDet = new HashSet<ComprasDet>();
        }

        public int ImpCodigo { get; set; }
        public string ImpDenom { get; set; }
        public int ImpValor { get; set; }
        public int EstaCodigo { get; set; }

        public virtual Estados EstaCodigoNavigation { get; set; }
        public virtual ICollection<ComprasDet> ComprasDet { get; set; }
    }
}
