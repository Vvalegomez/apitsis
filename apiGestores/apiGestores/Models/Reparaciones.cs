using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Reparaciones
    {
        public int RepaCodigo { get; set; }
        public DateTime RepaFeccar { get; set; }
        public DateTime RepaFeccie { get; set; }
        public int CueCodigo { get; set; }
        public int EstaCodigo { get; set; }
        public string RepaObserv { get; set; }

        public virtual Cuentas CueCodigoNavigation { get; set; }
        public virtual Estados EstaCodigoNavigation { get; set; }
        public virtual ReparacionesDet ReparacionesDet { get; set; }
    }
}
