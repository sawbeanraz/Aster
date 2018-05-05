using System;
using Autofac;
using Aster.Data;
using Aster.Data.EntityFramework;
using Aster.Framework.Infrastructure.DependencyManagement;
using Aster.Services.Users;
using Aster.Services.Security;
using Aster.Services.Localization;
using Aster.System.Logging;

namespace Aster.Framework {

    public class DependencyRegistrar : IDependencyRegistrar {
        public int Order => 0;

        public void Register(ContainerBuilder builder) {

            var dataSettingsManager = new DataSettingsManager();
            var dataSettings = dataSettingsManager.LoadSettings();


            //Register Data Settings
            builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();


            //Register Data Provider Manager
            builder.Register(x => new EFDataProviderManager(x.Resolve<DataSettings>()))
              .As<BaseDataProviderManager>().InstancePerDependency();


            //Register Data Provider 
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider())
              .As<IDataProvider>().InstancePerDependency();


            //Register Database Context
            if(dataSettings != null && dataSettings.IsValid()) {
                var efDataProviderManager = new EFDataProviderManager(dataSettingsManager.LoadSettings());
                var dataProvider = efDataProviderManager.LoadDataProvider();
                dataProvider.InitConnectionFactory();

                builder.Register<IDbContext>(c =>
                  new DataContext(
                    dataSettings.DataConnectionString,
                    dataProvider)
                ).InstancePerLifetimeScope();

            } else {
                throw new Exception("Unable to set data provider");
            }


            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepositoryAsync<>)).InstancePerLifetimeScope();

            builder.RegisterType<DatabaseLogger>().As<ILogger>().InstancePerLifetimeScope();
            builder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<LanguageService>().As<ILanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<LocalizationService>().As<ILocalizationService>().InstancePerLifetimeScope();

        }
    }
}