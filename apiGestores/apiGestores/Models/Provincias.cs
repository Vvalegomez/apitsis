using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Provincias
    {
        public Provincias()
        {
            Ciudades = new HashSet<Ciudades>();
        }

        public int ProvCodigo { get; set; }
        public string ProvDenom { get; set; }
        public int? PaisCodigo { get; set; }

        public virtual Paises PaisCodigoNavigation { get; set; }
        public virtual ICollection<Ciudades> Ciudades { get; set; }
    }
}
