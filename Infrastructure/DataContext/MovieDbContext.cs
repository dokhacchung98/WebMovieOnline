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

        public System.Data.Entity.DbSet<Infrastructure.Entities.News> News { get; set; }

        DbSet<Actor> Actors { get; set; }
        DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Category> Categories { get; set; }
        DbSet<CategoryMovie> GetCategoryMovies { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<FavoriteMovie> FavoriteMovies { get; set; }
        DbSet<Film> Films { get; set; }
        DbSet<Movie> Movies { get; set; }
        //DbSet<News> News { get; set; }
        DbSet<Producer> Producers { get; set; }
        DbSet<ProducerMovie> ProducerMovies { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<Resolution> Resolutions { get; set; }
    }
}