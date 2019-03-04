using Autofac;
using Infrastructure.DataContext;

namespace Website.Modules
{
    public class ApplicaitonModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterType<MovieDbContext>().InstancePerLifetimeScope();
        }
    }
}