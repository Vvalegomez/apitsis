using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Reportes
    {
        public int RepCodigo { get; set; }
        public DateTime RepFecha { get; set; }
        public int? ReptipoCodigo { get; set; }
        public string RepObserv { get; set; }
        public int SucCodigo { get; set; }

        public virtual ReportesTipos ReptipoCodigoNavigation { get; set; }
        public virtual Sucursales SucCodigoNavigation { get; set; }
        public virtual ReportesDet ReportesDet { get; set; }
    }
}
