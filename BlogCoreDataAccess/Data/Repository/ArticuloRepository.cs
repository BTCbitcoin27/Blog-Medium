using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCore.Data;
using BlogCore.Models;
using BlogCoreDataAccess.Data.Repository.IRepository;

namespace BlogCoreDataAccess.Data.Repository
{
    internal class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticuloRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Articulo> AsQueryable()
        {
            return _context.Set<Articulo>().AsQueryable();
        }

        public void Update(Articulo articulo)
        {
            var dbObject = _context.Articulos.FirstOrDefault(s =>  s.Id == articulo.Id);
            dbObject.Title = articulo.Title;
            dbObject.Description = articulo.Description;
            dbObject.UrlImagen = articulo.UrlImagen;
            dbObject.CategoriaId = articulo.CategoriaId;


            _context.SaveChanges();
        }
    }
} 
