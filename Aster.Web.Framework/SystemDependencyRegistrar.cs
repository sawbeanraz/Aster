using Aster.System.Abstractions;
using Aster.System.Data;
using Aster.System.Data.EntityFramework;
using Aster.System.Localization;
using Aster.System.Logging;
using Aster.System.Routing;
using Aster.Utils.Encryption;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Web.Framework {
    public class SystemDependencyRegistrar: IDependencyRegistrar {

        public int Order => 0;

        public void Register(ContainerBuilder builder) {

            var dataSettingsManager = new DataSettingsManager();
            var dataSettings = dataSettingsManager.LoadSettings();


            //Global Access for DataSettings and base provider
            builder.Register(c => dataSettingsManager.LoadSettings())
                .As<DataSettings>();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider())
                .As<IDataProvider>().InstancePerDependency();

            //Register data provider manager for Entity framework
            builder.Register(x => new EntityFrameworkDataProviderManager(x.Resolve<DataSettings>()));
            //Register Database Context
            if(dataSettings != null && dataSettings.IsValid()) {
                var efDataProviderManager = 
                    new EntityFrameworkDataProviderManager(dataSettingsManager.LoadSettings());
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

            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepositoryAsync<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<DatabaseLogger>().As<ILogger>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EncryptionService>().As<IEncryptionService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LanguageService>().As<ILanguageService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<LocalizationService>().As<ILocalizationService>()
                .InstancePerLifetimeScope();



            //Register Routes dynamically
            builder.RegisterType<AsterRouteRegistrar>().As<IRouteRegistrar>().SingleInstance();
        }

    }
}