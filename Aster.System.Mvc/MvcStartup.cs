using Aster.System.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Mvc
{
    public class MvcStartup: IStartupConfiguration {

        //Order should be after Authentication
        public int Order => 550;

        public void Configure(IApplicationBuilder application) {
            //If required to configure application builder
            return;
        }

        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration) {
            services.ConfigureAsterMvc();
        }
    }
}
