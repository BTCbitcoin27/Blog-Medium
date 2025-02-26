using BlogCoreDataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticulosController : Controller
    {
        private readonly IContainerWork _containerWork;
        public ArticulosController(IContainerWork containerWork)
        {
            _containerWork = containerWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _containerWork.Articulo.GetAll(includeProperties: "Categoria") });
        }
    }
}
