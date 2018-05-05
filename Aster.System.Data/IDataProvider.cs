using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Data {
    public interface IDataProvider {
        void InitConnectionFactory();

        void SetDatabaseInitializer();

        void InitDatabase();

        bool StoredProcedureSupported { get; }

        bool BackupSupported { get; }
    }
}