using Infrastructure.Entities;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Infrastructure.DataContext
{
    public class MovieDbContext : IdentityDbContext<ApplicationUser>
    {
        public MovieDbContext() : base("MovieDbContext", throwIfV1Schema: false)
        {
        }

        public MovieDbContext(string connectString) : base(connectString)
        {
        }

        public static MovieDbContext Create()
        {
            return new MovieDbContext();
        }

        public DbSet<News> News { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryMovie> GetCategoryMovies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<FavoriteMovie> FavoriteMovies { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProducerMovie> ProducerMovies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
    }
}