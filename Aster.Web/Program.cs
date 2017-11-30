using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Aster.Store.Users;

namespace Aster.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = BuildWebHost(args);

            using(var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                //var loggerFactory = services.GetRequiredService<ILoggerFactory>(); //TODO: Enable log system
                try {
                    //var catalogContext = services.GetRequiredService<CatalogContext>();                    
                    //CatalogContextSeed.SeedAsync(catalogContext, loggerFactory).Wait();

                    var userContext = services.GetRequiredService<UserContext>();
                    UserContextSeed.SeedAsync(userContext).Wait();

                    
                } catch(Exception ex) {
                    //TODO: Enable log system 
                    //var logger = loggerFactory.CreateLogger<Program>();
                    //logger.LogError(ex, "An error occurred seeding the DB.");                   
                }
            }


            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
