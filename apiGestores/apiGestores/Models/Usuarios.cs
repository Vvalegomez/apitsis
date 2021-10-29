using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string CategoriaUsuario { get; set; }
        public string ContraseñaUsuario { get; set; }
        public int IdSucursal_FK { get; set; }

    }
}
