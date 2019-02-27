using Autofac;
using Infrastructure.DataContext;

namespace Website.Modules
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterType<MovieDbContext>().InstancePerLifetimeScope();
        }
    }
}