using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using WebApiTutorial.Configuration;
using WebApiTutorial.Handlers;

namespace WebApiTutorial
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureDependencyResolver(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new MetadataResponseHandler());
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void ConfigureDependencyResolver(HttpConfiguration configuration)
        {
            container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Install(FromAssembly.This());
            configuration.DependencyResolver = new WindsorDependencyResolver(container);
        }
    }
}