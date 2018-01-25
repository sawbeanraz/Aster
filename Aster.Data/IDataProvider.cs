using Microsoft.EntityFrameworkCore;

namespace Aster.Data {

  public interface IDataProvider {

    void InitConnectionFactory();

    void SetDatabaseInitializer();

    void InitDatabase();

    bool StoredProcedureSupported {get;}

    bool BackupSupported { get; }
  }

}