using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Routing {
    //interface for registering all IRouteProvider
    public interface IRouteRegistrar {
        void RegisterRoutes(IRouteBuilder routerBuilder);
    }
}