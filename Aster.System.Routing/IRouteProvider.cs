using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Routing {

    //interface to define routes required
    public interface IRouteProvider {
        void Register(IRouteBuilder routeBuilder);
        int Order { get; }
    }
}