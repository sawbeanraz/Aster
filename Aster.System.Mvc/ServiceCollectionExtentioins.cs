using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aster.System.Mvc {
    public static class ServiceCollectionExtentioins {


        public static void ConfigureAsterMvc(
            this IServiceCollection services) {

            services.AddMvc();
        }
    }
}
