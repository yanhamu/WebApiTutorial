using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http;
using WebApiTutorial.Services;
using WebApiTutorial.Services.ResponseMetadataHandlers;

namespace WebApiTutorial.Configuration
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes
                    .FromThisAssembly()
                    .BasedOn<ApiController>()
                    .LifestyleTransient(),

                Classes
                    .FromThisAssembly()
                    .Where(c => c.Name.EndsWith("Service"))
                    .LifestyleTransient(),

                Classes
                    .FromThisAssembly()
                    .BasedOn<IMetadataHandler>()
                    .WithServiceDefaultInterfaces()
                    .WithService
                    .Self()
                    .LifestyleTransient(),

                Component
                    .For<MetadataProcessor>()
                    .LifestyleTransient()
                );
        }
    }
}