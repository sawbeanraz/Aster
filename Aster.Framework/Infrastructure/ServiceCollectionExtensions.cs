using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Aster.Framework.Infrastructure.Engine;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Aster.Framework.Infrastructure {
  public static class ServiceCollectionExtensions {

    public static IServiceProvider ConfigureAsterServices(this IServiceCollection services, IConfigurationRoot configuration) {
     
      //Example Test
      //services.AddScoped<DataSettingsManager, DataSettingsManager>();

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

    public static void ConfigureAuthenticationService(this IServiceCollection services) {

      services.AddAuthentication(options => {
          options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      }).AddCookie(options => {
          options.LoginPath = "/auth/signin";   //TODO: read login path from configuration 
      });

    }


    public static void ConfigureMvcService(this IServiceCollection services) {
      services.AddMvc();
    }


    public static void AddHttpContextAccessor(this IServiceCollection services) {
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }


  }
}