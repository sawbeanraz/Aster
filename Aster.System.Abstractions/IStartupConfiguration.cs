using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aster.System.Abstractions {
    public interface IStartupConfiguration {
        void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration);

        void Configure(IApplicationBuilder application);

        int Order { get; }
    }
}