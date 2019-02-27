using Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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

        public System.Data.Entity.DbSet<Infrastructure.Entities.UserInformation> UserInformations { get; set; }
    }
}