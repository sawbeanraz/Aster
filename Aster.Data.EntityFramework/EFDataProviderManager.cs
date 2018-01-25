using System;
using Aster.Data;

namespace Aster.Data.EntityFramework {
    

  public class EFDataProviderManager: BaseDataProviderManager {

    public EFDataProviderManager(DataSettings settings): base(settings) {

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