using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http;

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
                    .LifestyleTransient()
                );
        }
    }
}