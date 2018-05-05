using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aster.System.Abstractions {
    public interface IEngine {

        void Initialize(IServiceCollection services);

        IServiceProvider ConfigureServices(
            IServiceCollection services,
            IConfigurationRoot configuration);

        T Resolve<T>() where T : class;

        object Resolve(Type type);
    }
}