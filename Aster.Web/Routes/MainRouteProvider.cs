using Aster.System.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.Web.Routes
{
    public class MainRouteProvider: IRouteProvider {


        public void Register(IRouteBuilder routeBuilder) {

            //area Route
            routeBuilder.MapRoute(name: "areaRoute", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            //default Route
            routeBuilder.MapRoute(name: "defaultRoute",
                    template: "{controller=Home}/{action=Index}/{id?}");
        }
        public int Order => 0;

    }
}
