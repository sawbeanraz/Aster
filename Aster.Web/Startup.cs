using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Aster.Framework.Infrastructure;

namespace Aster.Web {
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange:true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            
            //TODO: Make Https required            
            //services.AddMvc(options => {
            //    options.Filters.Add(new RequireHttpsAttribute());
            //});
            
            services.ConfigureAsterServices(Configuration);
            services.ConfigureAsterAuthentication(Configuration);
        }

        
        // public void ConfigureDevelopmentServices(IServiceCollection services) {

        //     //ConfigureTestingServices(services);
        //     ConfigureProductionServices(services);

        // }

        // public void ConfigureTestingServices(IServiceCollection services) {
        //     services.AddDbContext<UserContext>(c => c.UseInMemoryDatabase("Users"));            
        //     ConfigureServices(services);
        // }
        
        // public void ConfigureProductionServices(IServiceCollection services) {
        //     services.AddDbContext<UserContext>(c => {
        //         try {                    
        //             c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //         } catch(System.Exception ex) {
        //             var message = ex.Message;
        //         }
        //     });
        //     ConfigureServices(services);
        // }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
