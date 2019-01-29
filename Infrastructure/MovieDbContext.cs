using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext() : base("MovieDbContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MovieDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
