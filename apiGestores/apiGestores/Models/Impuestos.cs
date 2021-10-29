using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Impuestos
    {
        [Key]
        public int IdImpuesto { get; set; }
        public string NombreImpuesto { get; set; }
        public int ValorImpuesto { get; set; }
        
    }
}
