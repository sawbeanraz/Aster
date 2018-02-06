using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/**
 * Source: nopCommerce INopStartup.completionlist
 * 
 * An interface for startup class/object for services and middleware application
 */

namespace Aster.Framework {

  public interface IStartupConfiguration {

    void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration);

    void Configure(IApplicationBuilder application);

    int Order { get; }
  }
}