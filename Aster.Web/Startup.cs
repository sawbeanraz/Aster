using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Aster.Web.Framework;
using Microsoft.AspNetCore.StaticFiles;

namespace Aster.Web {
    public class Startup {
        public Startup(IHostingEnvironment environment) {

            Configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange:true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services) {
            

            //TODO: Make Https required            
            //services.AddMvc(options => {
            //    options.Filters.Add(new RequireHttpsAttribute());
            //});

  
            return services.ConfigureAsterServices(Configuration);            
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }






            //StaticFileOptions options = new StaticFileOptions();
            //FileExtensionContentTypeProvider typeProvider = new FileExtensionContentTypeProvider();

            //var mimes = new Dictionary<string, string> {
            //    {".woff", "applicaiton/font-woff" },
            //    {".woff2", "font/woff2" },
            //    {".ttf", "application/font-sfnt" },
            //    {".eot", "application/vnd.ms-fontobject" },
            //    {".otf", "application/font-sfnt" },
            //    {".svg", "image/svg+xml" }
            //};

            //foreach(var mime in mimes) {
            //    if(!typeProvider.Mappings.ContainsKey(mime.Key))
            //        typeProvider.Mappings.Add(mime.Key, mime.Value);
            //}

            //options.ContentTypeProvider = typeProvider;
            //app.UseStaticFiles(options);

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
