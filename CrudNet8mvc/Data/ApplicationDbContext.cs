using CrudNet8mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNet8mvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optons) : base(optons)
        {
            
        }
        public DbSet<Contacto> Contacto { get; set; }
    }
}
