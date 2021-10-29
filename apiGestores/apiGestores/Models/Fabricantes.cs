using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Fabricantes
    {
        [Key]
        public int IdFabricante { get; set; }

        public string NombreFabricante { get; set; }
        public string EstadoFabricante { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
      
    }
}
