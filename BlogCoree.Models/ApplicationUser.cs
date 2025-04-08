using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlogCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Ingresa tu nombre de usuario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingresa tu direccion")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Ingresa tu ciudad")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Ingresa tu pais")]
        public string Pais { get; set; }

    }
}
    