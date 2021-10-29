using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string ModeloProducto { get; set; }
        public string ColorProducto { get; set; }
        public int CantidadProducto { get; set; }
        public string EstadoProducto { get; set; }
        public int PrecioProducto { get; set; }
        public string NumeroSerie { get; set; }
        public int IdFabricante_FK { get; set; }
        public int IdProveedor_FK { get; set; }
        public int IdReporte_FK { get; set; }
        public int IdSucursal_FK { get; set; }
    }
}
