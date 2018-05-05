using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.System.Permission {
    public interface IPermissionProvider {
        IEnumerable<PermissionRecord> GetPermissions();
    }
}
