using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class ProductoRepa
    {
        [Key]
        public int IdProductoRep { get; set; }

        public string DniCliente { get; set; }
        //controlar este campo
        public string ProductoReparacion { get; set; }
        public string FabricanteReparacion { get; set; }
        public string ModeloProducto { get; set; }
        public string EstadoIngreso { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
    }
}
