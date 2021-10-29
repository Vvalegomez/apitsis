using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Models
{
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }
        public string NombreEmpresa { get; set; }
        public string SitioWeb { get; set; }
        public string Telefono { get; set; }
        public string NombreContacto { get; set; }
        public string ApellidoContacto { get; set; }
        public string Email { get; set; }
        public string Calle { get; set; }
        public string CP { get; set; }
    }
}
