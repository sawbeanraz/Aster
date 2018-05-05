using Aster.System.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Authentication {
    public class AuthenticationStartup : IStartupConfiguration {
        public int Order => 500;

        public void Configure(IApplicationBuilder application) {
            return;
        }

        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration) {
            services.ConfigureAuthenticationService();            
        }
    }
}
