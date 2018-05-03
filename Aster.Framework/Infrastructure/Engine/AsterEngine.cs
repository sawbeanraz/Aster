using System;
using System.Linq;
using Aster.Framework.Infrastructure.DependencyManagement;
using Aster.Framework.TypeFinder;

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;




namespace Aster.Framework.Infrastructure.Engine {

    public class AsterEngine : IEngine {


        private IServiceProvider _serviceProvider { get; set; }


        public IServiceProvider ConfigureServices(IServiceCollection services, IConfigurationRoot configuration) {

            var typeFinder = new WebAppTypeFinder();

            var startupConfigurations = typeFinder.FindClassesOfType<IStartupConfiguration>();
            var startupInstances = startupConfigurations
              .Select(startup => (IStartupConfiguration)Activator.CreateInstance(startup))
              .OrderBy(startup => startup.Order);


            foreach(var startupInstance in startupInstances) {
                startupInstance.ConfigureServices(services, configuration);
            }







            //register auto mappers configurations


            //Register Dependencies
            RegisterDependencies(services, typeFinder);


            return _serviceProvider;

        }


        public virtual IServiceProvider RegisterDependencies(IServiceCollection services, ITypeFinder typeFinder) {
            var containerBuilder = new ContainerBuilder();

            //register engine
            containerBuilder.RegisterInstance(this).As<IEngine>().SingleInstance();

            containerBuilder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            var dependencyRegistrars = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var instances = dependencyRegistrars
              .Select(dependencyRegistrar => (IDependencyRegistrar)Activator.CreateInstance(dependencyRegistrar))
              .OrderBy(dependencyRegistrar => dependencyRegistrar.Order);

            foreach(var dependencyRegistrar in instances) {
                dependencyRegistrar.Register(containerBuilder);
            }

            //populate Autofac container builder with the set of registered services descriptors
            containerBuilder.Populate(services);


            //create service provider
            _serviceProvider = new AutofacServiceProvider(containerBuilder.Build());
            return _serviceProvider;
        }

        public void Initialize(IServiceCollection services) {

            //initialize plugins
        }

        public T Resolve<T>() where T : class {
            return (T)GetServiceProvider().GetRequiredService(typeof(T));
        }

        public object Resolve(Type type) {
            return GetServiceProvider().GetRequiredService(type);
        }

        protected IServiceProvider GetServiceProvider() {            
            var accessor = _serviceProvider.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            return context?.RequestServices ?? _serviceProvider;
        }
    }
}