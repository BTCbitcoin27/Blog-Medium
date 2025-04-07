using System.Diagnostics;
using BlogCore.Models;
using BlogCore.Models.ViewModels;
using BlogCoreDataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IContainerWork _containerWork;

        public HomeController(IContainerWork contenedorTrabajo)
        {
            _containerWork = contenedorTrabajo;
            
        }
        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 6)
        {

            var articulos = _containerWork.Articulo.AsQueryable();

            // Paginar los resultados
            var paginatedEntries = articulos.Skip((page - 1) * pageSize).Take(pageSize);

            HomeVM homeVM = new HomeVM()
            {
                Sliders = _containerWork.Slider.GetAll(),
                Articulos = paginatedEntries.ToList(),
                PageIndex = page,
                TotalPages = (int)Math.Ceiling(articulos.Count() / (double)pageSize)
            };

            //Esta línea es para poder saber si estamos en el home o no
            ViewBag.IsHome = true;

            return View(homeVM);
        }


        [HttpGet]
        public IActionResult ResultadoBusqueda(string searchString, int page = 1, int pageSize = 7)
        {
            var articulos = _containerWork.Articulo.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                articulos = articulos.Where(e => e.Title.Contains(searchString));
            }
            var paginatedEntries = articulos.Skip((page - 1) * pageSize).Take(pageSize);
            var model = new ListaPaginada<Articulo>(paginatedEntries.ToList(), articulos.Count(), page, pageSize, searchString);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        
        public IActionResult Details(int id)
        {
            var articuloDB = _containerWork.Articulo.Get(id);
            return View(articuloDB);
        }
    }
}
