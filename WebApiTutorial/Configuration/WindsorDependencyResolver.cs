using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace WebApiTutorial.Configuration
{
    internal sealed class WindsorDependencyResolver : IDependencyResolver
    {
        private IWindsorContainer container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(container);
        }

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            return container.Kernel.HasComponent(serviceType)
                ? container.Resolve(serviceType)
                : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType).Cast<object>();
        }
    }
}