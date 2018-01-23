using Aster.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Aster.Data.DataProviders {

  public class MySqlDataProvider : IDataProvider {
    public bool StoredProcedureSupported => true;

    public bool BackupSupported => true;

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