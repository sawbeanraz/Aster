using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Aster.Framework.Infrastructure.Engine;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Aster.Framework.Infrastructure {
  public static class ServiceCollectionExtensions {

    public static IServiceProvider ConfigureAsterServices(this IServiceCollection services, IConfigurationRoot configuration) {
     
      //Example Test
      //services.AddScoped<DataSettingsManager, DataSettingsManager>();

      //Start Application Instance
      var engine = EngineContext.Create();
      engine.Initialize(services);
      var serviceProvider = engine.ConfigureServices(services, configuration);

      //TODO: Log application bootstrap
      //EngineContext.Current.Resolve<ILogger>().Information("Application started", null, null);

      return serviceProvider;
    }

    public static IServiceCollection ConfigureAsterAuthentication(this IServiceCollection services, IConfigurationRoot configuration) {

      services.AddAuthentication(options => {
          options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      }).AddCookie(options => {
          options.LoginPath = "/auth/signin";
      });



      return services;

    }


  }
}