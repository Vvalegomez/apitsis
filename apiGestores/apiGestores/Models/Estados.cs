using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Estados
    {
        public Estados()
        {
            Articulos = new HashSet<Articulos>();
            Cuentas = new HashSet<Cuentas>();
            Fabricantes = new HashSet<Fabricantes>();
            Impuestos = new HashSet<Impuestos>();
            Modelos = new HashSet<Modelos>();
            Niveles = new HashSet<Niveles>();
            Proveedores = new HashSet<Proveedores>();
            Reparaciones = new HashSet<Reparaciones>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int EstaCodigo { get; set; }
        public string EstaDenom { get; set; }

        public virtual ICollection<Articulos> Articulos { get; set; }
        public virtual ICollection<Cuentas> Cuentas { get; set; }
        public virtual ICollection<Fabricantes> Fabricantes { get; set; }
        public virtual ICollection<Impuestos> Impuestos { get; set; }
        public virtual ICollection<Modelos> Modelos { get; set; }
        public virtual ICollection<Niveles> Niveles { get; set; }
        public virtual ICollection<Proveedores> Proveedores { get; set; }
        public virtual ICollection<Reparaciones> Reparaciones { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
