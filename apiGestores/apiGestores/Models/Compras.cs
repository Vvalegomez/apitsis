using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Compras
    {
        [Key]
        public int IdCompra { get; set; }

        public int NumeroCompra { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCompra { get; set; }
        public int IdUsuario_FK { get; set; }
        public int IdImpuesto_FK { get; set; }
        public int IdProveedor_FK { get; set; }
    }
}
