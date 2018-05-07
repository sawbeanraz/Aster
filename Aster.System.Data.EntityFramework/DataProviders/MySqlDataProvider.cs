namespace Aster.System.Data.EntityFramework.DataProviders {
    public class MySqlDataProvider : IDataProvider {
        public bool StoredProcedureSupported => true;

        public bool BackupSupported => true;

        public void InitConnectionFactory() {
            // throw new System.NotImplementedException();
        }

        public void InitDatabase() {
            InitConnectionFactory();
            SetDatabaseInitializer();
        }

        public void SetDatabaseInitializer() {
            // throw new System.NotImplementedException();
        }
    }
}
