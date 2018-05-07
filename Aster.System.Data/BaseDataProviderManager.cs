using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Data {
    public abstract class BaseDataProviderManager {

        protected BaseDataProviderManager(DataSettings settings) {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        protected DataSettings Settings { get; }

        public abstract IDataProvider LoadDataProvider();
    }
}