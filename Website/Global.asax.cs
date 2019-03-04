using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Website.Mapping;
using Website.Modules;

namespace Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Autofac Configuaration
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            
            builder.RegisterModule(new ApplicaitonModule());

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Configuration automapper
            AutoMapper.Mapper.Initialize(m => m.AddProfile<MappingProfile>());
        }
    }
}