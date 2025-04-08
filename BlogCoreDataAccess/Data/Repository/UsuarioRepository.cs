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
    public class UsuarioRepository(ApplicationDbContext db) : Repository<ApplicationUser>(db), IUsuarioRepository
    {
        private readonly ApplicationDbContext _db = db;

        public void BloquearUsuario(string UserID)
        {
            var userFromDB = _db.ApplicationUser.FirstOrDefault(u => u.Id == UserID);
            userFromDB.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        public void DesbloquearUsuario(string UserID)
        {
            var userFromDB = _db.ApplicationUser.FirstOrDefault(u => u.Id == UserID);
            userFromDB.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
