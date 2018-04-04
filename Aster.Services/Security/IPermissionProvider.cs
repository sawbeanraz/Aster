using System.Collections.Generic;
using Aster.Core.Domain.Security;

namespace Aster.Services.Security {
    public interface IPermissionProvider {

        IEnumerable<PermissionRecord> GetPermissions();
    }
}