namespace Aster.System.Data.EntityFramework.DataProviders {
    public class SqlServerDataProvider : IDataProvider {
        public bool StoredProcedureSupported => true;

        public bool BackupSupported => true;

        public virtual void InitConnectionFactory() {
            //TODO: 
            // var connectionFactory = new SqlConnectionFactory();
            // Database.DefaultConnectionFactory = connectionFactory;      
        }

        public void InitDatabase() {
            InitConnectionFactory();
            SetDatabaseInitializer();
        }

        public void SetDatabaseInitializer() {
            //throw new System.NotImplementedException();

        }




    }
}
