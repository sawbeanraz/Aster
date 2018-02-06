using Aster.Framework.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aster.Framework {
  public class AuthenticationStartup : IStartupConfiguration
  {
    public int Order => 500;

    public void Configure(IApplicationBuilder application)
    {
      return ;
    }

    public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
    {
      services.ConfigureAuthenticationService();
      services.ConfigureMvcService();      
    }
  }
}