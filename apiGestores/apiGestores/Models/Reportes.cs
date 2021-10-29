using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Reportes
    {
        [Key]
        public int IdReporte { get; set; }
        public DateTime FechaReporte { get; set; }
        public string TipoReporte { get; set; }

    }
}
