using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Data {
    public class DataSettings {
        
        public string DataProvider { get; set; }
        public string DataConnectionString { get; set; }

        public bool IsValid() {
            return !string.IsNullOrEmpty(DataProvider) && !string.IsNullOrEmpty(DataConnectionString);
        }
    }
}