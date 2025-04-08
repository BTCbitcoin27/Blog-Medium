using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter a name")]
        [Display(Name="Category name")]
        public string Name { get; set; }
        [Display(Name = "Categoria")]
        [Range(1, 100,ErrorMessage = "Ingrwa UN Vloe wnrtrwe  y 100")]
        public int? Order { get; set; }
    }
}
