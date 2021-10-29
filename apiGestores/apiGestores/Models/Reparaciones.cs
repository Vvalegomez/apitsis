using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Reparaciones
    {
        [Key]
        public int IdReparacion { get; set; }

        public string EstadoReparacion { get; set; }
        public string Descripcion { get; set; }
        public string AccionRealizar { get; set; }
        public int ManoDeObra { get; set; }
        public int Precio { get; set; }
        public int IdProductoRep_FK { get; set; }
        public int IdUsuario_FK { get; set; }
    }
}
