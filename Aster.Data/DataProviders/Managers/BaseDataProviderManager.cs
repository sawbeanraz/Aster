using System;

namespace Aster.Data.DataProviders.Managers {

  public abstract class BaseDataProviderManager {



    protected BaseDataProviderManager(DataSettings settings) {
      if(settings == null) {
        throw new ArgumentNullException(nameof(settings));
      }
      this.Settings = settings;
    }

    protected DataSettings Settings { get; }

    public abstract IDataProvider LoadDataProvider();

  }
}