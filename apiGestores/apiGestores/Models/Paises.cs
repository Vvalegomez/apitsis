using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Paises
    {
        public Paises()
        {
            Provincias = new HashSet<Provincias>();
        }

        public int PaisCodigo { get; set; }
        public string PaisDenom { get; set; }

        public virtual ICollection<Provincias> Provincias { get; set; }
    }
}
