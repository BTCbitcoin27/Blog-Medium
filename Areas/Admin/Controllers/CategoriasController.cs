using BlogCore.Models;
using BlogCoreDataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContainerWork _containerWork;
        public CategoriasController(IContainerWork containerWork)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _containerWork.Categoria.Add(categoria);
                _containerWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _containerWork.Categoria.Get(id);
            if(categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _containerWork.Categoria.Update(categoria);
                _containerWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _containerWork.Categoria.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDB = _containerWork.Categoria.Get(id);
            if (objFromDB == null)
            {
                return Json(new { success = false, message = "Error borrando categoria" });
            }

            _containerWork.Categoria.Remove(objFromDB);
            _containerWork.Save();
            return Json(new { success = true, message = "Borrando categoria" });

        }


    }
}
