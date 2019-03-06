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

        DbSet <Actor> Actors { get; set; }
        DbSet <ActorMovie> ActorMovies { get; set; }
        DbSet <Category> Categories { get; set; }
        DbSet<CategoryMovie> GetCategoryMovies { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<Favorite> Favorites { get; set; }
        DbSet <FavoriteMovie> FavoriteMovies { get; set; }
        DbSet<Film> Films { get; set; }
        DbSet <Image> Images { get; set; }
        DbSet<InformationUser> InformationUsers { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<News> News { get; set; }
        DbSet<Producer> Producers { get; set; }
        DbSet<ProducerMovie> ProducerMovies { get; set; }
        DbSet<Quality> Qualities { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<Resolution> Resolutions { get; set; }
    }
}