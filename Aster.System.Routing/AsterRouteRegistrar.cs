using Aster.Utils.TypeFinder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aster.System.Routing {
    public class AsterRouteRegistrar : IRouteRegistrar {
        protected readonly ITypeFinder _typefinder;

        public AsterRouteRegistrar(ITypeFinder typeFinder) {
            _typefinder = typeFinder;
        }

        public virtual void RegisterRoutes(IRouteBuilder routeBuilder) {


            var routeProviders = _typefinder.FindClassesOfType<IRouteProvider>();


            var routerProviderInstances = routeProviders
                .Select(routeProvider => (IRouteProvider)Activator.CreateInstance(routeProvider))
                .OrderBy(routeProvider => routeProvider.Order);


            foreach(var routeProvider in routerProviderInstances)
                routeProvider.Register(routeBuilder);

        }
    }
}