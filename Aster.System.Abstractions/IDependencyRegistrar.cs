using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Abstractions {
    interface IDependencyRegistrar {
        void Register(ContainerBuilder builder);

        int Order { get; }
    }
}
