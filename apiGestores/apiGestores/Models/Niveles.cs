using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Niveles
    {
        public Niveles()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int NivCodigo { get; set; }
        public string NivDenom { get; set; }
        public int EstaCodigo { get; set; }

        public virtual Estados EstaCodigoNavigation { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
