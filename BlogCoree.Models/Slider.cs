﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre para erl slider")]
        [Display(Name ="Slider Name")]
        public string Nombre { get; set; }
        [Required]
        public bool Estado { get; set; }
        [DataType(DataType.ImageUrl)]
        [Display(Name ="Image")]
        public string UrlImage { get; set; }

    }
}
