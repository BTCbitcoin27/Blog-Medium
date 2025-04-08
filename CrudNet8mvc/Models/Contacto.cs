using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace CrudNet8mvc.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a name")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Enter a phone number")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Enter an email")]
        public string Email { get; set; }
        [Display(Name = "date")]

        public DateTime FechaDeCreacon { get; set; }
    }
}
