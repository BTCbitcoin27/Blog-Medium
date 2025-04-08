using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCoreDataAccess.Data.Repository;
using BlogCore.Data;
using BlogCore.Models;
using BlogCoreDataAccess.Data.Repository.IRepository;

namespace BlogCoreDataAccess.Data.Repository
{
    public class ContainerWork : IContainerWork
    {
        private readonly ApplicationDbContext _context;

        public ContainerWork(ApplicationDbContext context)
        {
            _context = context;
            Categoria = new CategoriaRepository(_context);
            Articulo = new ArticuloRepository(_context);
            Slider = new SliderRepository(_context);
            Usuario = new UsuarioRepository(_context);
        }

        public ICategoriaRepository Categoria {  get;private set; }
        public IArticuloRepository Articulo { get; private set; }
        public ISliderRepository Slider { get; set; }
        public IUsuarioRepository Usuario { get;  set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
