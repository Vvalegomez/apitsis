using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Sucursales
    {
        public Sucursales()
        {
            ArticulosDet = new HashSet<ArticulosDet>();
            Reportes = new HashSet<Reportes>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int SucCodigo { get; set; }
        public string SucDenom { get; set; }

        public virtual ICollection<ArticulosDet> ArticulosDet { get; set; }
        public virtual ICollection<Reportes> Reportes { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
