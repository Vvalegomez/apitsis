using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Ciudad
    {
        [Key]
        public int idCiudad { get; set; }

        public string nombreCiudad { get; set; }
    }
}
