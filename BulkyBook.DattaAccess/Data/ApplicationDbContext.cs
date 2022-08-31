using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DattaAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }

        public DbSet<Articulo> Articulos { get; set; }



    }
}
