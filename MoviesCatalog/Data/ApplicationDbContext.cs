using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Models;

namespace MoviesCatalog.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) 
        { 
        }
       
        public DbSet<User>? Users { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<RateMovie>? RateMovies { get; set; }
    }
}
