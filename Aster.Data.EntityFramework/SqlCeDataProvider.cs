using Aster.Data;
using System;

namespace Aster.Data.EntityFramework {


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