namespace Infrastructure.Migrations
{
    using Infrastructure.DataContext;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.DataContext.MovieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieDbContext context)
        {
            AddRole(context);
        }
        private void AddRole(MovieDbContext context)
        {
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin"
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User"
            });
            context.SaveChanges();
        }
    }
}
