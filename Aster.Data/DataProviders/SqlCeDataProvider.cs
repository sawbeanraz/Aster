using Aster.Data.Abstractions;

namespace Aster.Data.DataProviders {


  public class SqlCeDataProvider : IDataProvider {
    public bool StoredProcedureSupported => false;

    public bool BackupSupported => false;

    public void InitConnectionFactory() {
      throw new System.NotImplementedException();
    }

    public void InitDatabase() {
      throw new System.NotImplementedException();
    }

    public void SetDatabaseInitializer() {
      throw new System.NotImplementedException();
    }
  }
}