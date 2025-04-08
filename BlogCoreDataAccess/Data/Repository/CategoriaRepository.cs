using BlogCore.Data;
using BlogCore.Models;
using BlogCoreDataAccess.Data.Repository.IRepository;
using BlogCoreDataAccess.Data.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCoreDataAccess.Data.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    private readonly ApplicationDbContext _db;

    public CategoriaRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public IEnumerable<SelectListItem> GetListaCategorias()
    {
        return _db.Categorias.Select(i => new SelectListItem()
        {
            Text = i.Name,
            Value = i.Id.ToString()
        });
    }

    public void Update(Categoria categoria)
    {
        var objDesdeDb = _db.Categorias.FirstOrDefault(s => s.Id == categoria.Id);
        objDesdeDb.Name = categoria.Name;
        objDesdeDb.Order = categoria.Order;

        _db.SaveChanges();
    }
}
