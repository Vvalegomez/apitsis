using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Ciudades
    {
        public Ciudades()
        {
            Cuentas = new HashSet<Cuentas>();
            Proveedores = new HashSet<Proveedores>();
        }

        public int CiuCodigo { get; set; }
        public string CiuDenom { get; set; }
        public int? ProvCodigo { get; set; }

        public virtual Provincias ProvCodigoNavigation { get; set; }
        public virtual ICollection<Cuentas> Cuentas { get; set; }
        public virtual ICollection<Proveedores> Proveedores { get; set; }
    }
}
