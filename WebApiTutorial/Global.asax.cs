using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Web.Http;
using WebApiTutorial.Configuration;

namespace WebApiTutorial
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ConfigureDependencyResolver(GlobalConfiguration.Configuration);
        }

        private void ConfigureDependencyResolver(HttpConfiguration configuration)
        {
            container = new WindsorContainer();
            container.Install(FromAssembly.This());
            configuration.DependencyResolver = new WindsorDependencyResolver(container);
        }
    }
}