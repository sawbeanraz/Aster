using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Data {
    public class DataSettingsHelper {

        private static bool? _isDatabasInstalled;

        public static bool IsDatabaseInstalled() {
            return false;
        }

        public static void Flush() {
            _isDatabasInstalled = null;
        }

    }
}