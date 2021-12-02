using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiGestores.Models
{
    public partial class Ciudades
    {
        public Ciudades()
        {
            Cuentas = new HashSet<Cuentas>();
            Proveedores = new HashSet<Proveedores>();
        }

        [Key]
        public int ciu_codigo { get; set; }
        public string ciu_denom { get; set; }
        public int? prov_codigo { get; set; }

        public virtual Provincias ProvCodigoNavigation { get; set; }
        public virtual ICollection<Cuentas> Cuentas { get; set; }
        public virtual ICollection<Proveedores> Proveedores { get; set; }
    }
}
