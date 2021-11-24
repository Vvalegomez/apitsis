using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Compras
    {
        public int ComCodigo { get; set; }
        public string ComNumerofisico { get; set; }
        public string ComObserv { get; set; }
        public DateTime? ComFecha { get; set; }
        public int? UsuCodigo { get; set; }

        public virtual Usuarios UsuCodigoNavigation { get; set; }
        public virtual ComprasDet ComprasDet { get; set; }
    }
}
