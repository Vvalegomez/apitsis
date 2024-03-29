﻿using System;
using System.Collections.Generic;

namespace apiGestores.Models
{
    public partial class Fabricantes
    {
        public Fabricantes()
        {
            ArticulosDet = new HashSet<ArticulosDet>();
        }

        public int FabCodigo { get; set; }
        public string FabDenom { get; set; }
        public DateTime? FabFeccar { get; set; }
        public int EstaCodigo { get; set; }

        public virtual Estados EstaCodigoNavigation { get; set; }
        public virtual ICollection<ArticulosDet> ArticulosDet { get; set; }
    }
}
