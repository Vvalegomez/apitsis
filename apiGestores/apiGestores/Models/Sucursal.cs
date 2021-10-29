using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Sucursal
    {
        [Key]
        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; }

    }
}
