using Aster.System.Engine;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aster.Web.Framework {
    public static class ServiceCollectionExtensions {

        public static IServiceProvider ConfigureAsterServices(this IServiceCollection services,
            IConfigurationRoot configuration) {

            //TODO: Configurate Application Singleton configurations
            //Example Application Config settings etc

            services.AddHttpContextAccessor();

            //Start Application Instance
            var engine = EngineContext.Create();
            engine.Initialize(services);
            var serviceProvider = engine.ConfigureServices(services, configuration);

            //TODO: Log application bootstrap
            //EngineContext.Current.Resolve<ILogger>().Information("Application started", null, null);

            return serviceProvider;
        }



        public static void AddHttpContextAccessor(this IServiceCollection services) {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

    }
}