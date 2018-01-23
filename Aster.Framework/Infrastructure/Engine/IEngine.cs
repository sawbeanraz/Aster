using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Aster.Framework.Infrastructure.Engine {

  public interface IEngine {

    void Initialize(IServiceCollection services);

    IServiceProvider ConfigureServices(IServiceCollection serivces, IConfigurationRoot configuration);
    
    T Resolve<T>() where T: class;

    object Resolve(Type type);

  }
}