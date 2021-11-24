using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Cuentas
    {
        public Cuentas()
        {
            Reparaciones = new HashSet<Reparaciones>();
        }

        public int CueCodigo { get; set; }
        public string CueDenom { get; set; }
        public string CueWebsite { get; set; }
        public string CueTelefono { get; set; }
        public string CueMail { get; set; }
        public string CueDireccion { get; set; }
        public string CueCp { get; set; }
        public int CiuCodigo { get; set; }
        public int EstaCodigo { get; set; }

        public virtual Ciudades CiuCodigoNavigation { get; set; }
        public virtual Estados EstaCodigoNavigation { get; set; }
        public virtual ICollection<Reparaciones> Reparaciones { get; set; }
    }
}
