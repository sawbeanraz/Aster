using Aster.System.Data.EntityFramework.DataProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Data.EntityFramework {
    public class EntityFrameworkDataProviderManager : BaseDataProviderManager {

        public EntityFrameworkDataProviderManager(DataSettings settings) : base(settings) {
        }

        public override IDataProvider LoadDataProvider() {
            var providerName = Settings.DataProvider;

            if(string.IsNullOrWhiteSpace(providerName)) {
                throw new Exception("Data Settings doesn't contain provider name");
            }

            switch(providerName.ToLower()) {

                case "sqlserver":
                    return new SqlServerDataProvider();
                case "sqlce":
                    return new SqlCeDataProvider();
                case "mysql":
                    return new MySqlDataProvider();
                default:
                    throw new Exception($"Not supported data provider name: {providerName}");
            }
        }
    }
}
