using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class ReportesTipos
    {
        public ReportesTipos()
        {
            Reportes = new HashSet<Reportes>();
        }

        public int ReptipoCodigo { get; set; }
        public string ReptipoDenom { get; set; }

        public virtual ICollection<Reportes> Reportes { get; set; }
    }
}
