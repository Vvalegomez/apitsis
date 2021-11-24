using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Proveedores
    {
        public Proveedores()
        {
            ArticulosDet = new HashSet<ArticulosDet>();
        }

        public int ProveCodigo { get; set; }
        public string ProveDenom { get; set; }
        public string ProveWebsite { get; set; }
        public string ProveTelefono { get; set; }
        public string ProveMail { get; set; }
        public string ProveDireccion { get; set; }
        public string ProveCp { get; set; }
        public int CiuCodigo { get; set; }
        public int EstaCodigo { get; set; }

        public virtual Ciudades CiuCodigoNavigation { get; set; }
        public virtual Estados EstaCodigoNavigation { get; set; }
        public virtual ICollection<ArticulosDet> ArticulosDet { get; set; }
    }
}
