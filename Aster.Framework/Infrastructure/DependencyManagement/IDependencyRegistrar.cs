using Autofac;

namespace Aster.Framework.Infrastructure.DependencyManagement {


  public interface IDependencyRegistrar {


    //TODO: Add ITypeFinder typeFinder, AsterConfig config for flexible dependency management
    void Register(ContainerBuilder builder);

    int Order { get; }

  }


}