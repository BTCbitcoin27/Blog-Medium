﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models.ViewModels
{
    public class HomeVM
    {
        

        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Articulo> Articulos { get; set; }

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

    }
}
