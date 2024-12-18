using Microsoft.EntityFrameworkCore;
using MovieApp.Entities;

namespace MovieApp.Data
{
    public class MovieContext(DbContextOptions<MovieContext> options):DbContext(options)
    {
        // DbSet mapped to a table in database and provide API for interacting with the datbase
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Genre> Genres => Set<Genre>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Drama" },
            new { Id = 2, Name = "Crime" },
            new { Id = 3, Name = "Action" },
            new { Id = 4, Name = "Biography" },
            new { Id = 5, Name = "Adventure" }
);
        }
    }
}
