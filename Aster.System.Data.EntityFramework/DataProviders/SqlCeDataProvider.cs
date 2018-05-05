using Aster.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Data.EntityFramework.DataProviders {
    public class SqlCeDataProvider : IDataProvider {
        public bool StoredProcedureSupported => false;

        public bool BackupSupported => false;

        public void InitConnectionFactory() {            
            throw new NotImplementedException();
        }

        public void InitDatabase() {
            throw new NotImplementedException();
        }

        public void SetDatabaseInitializer() {
            throw new NotImplementedException();
        }
    }
}
