using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Compras = new HashSet<Compras>();
        }

        public int UsuCodigo { get; set; }
        public string UsuUser { get; set; }
        public string UsuPass { get; set; }
        public int NivCodigo { get; set; }
        public int SucCodigo { get; set; }
        public int EstaCodigo { get; set; }

        public virtual Estados EstaCodigoNavigation { get; set; }
        public virtual Niveles NivCodigoNavigation { get; set; }
        public virtual Sucursales SucCodigoNavigation { get; set; }
        public virtual ICollection<Compras> Compras { get; set; }
    }
}
