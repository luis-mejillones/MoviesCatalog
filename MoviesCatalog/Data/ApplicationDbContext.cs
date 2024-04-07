using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Domain;

namespace MoviesCatalog.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) 
        { 
        }
       
        public DbSet<Miniature> Miniatures { get; set; }
    }
}
