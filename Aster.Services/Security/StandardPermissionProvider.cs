using System.Collections.Generic;
using Aster.Core.Domain.Security;

namespace Aster.Services.Security {
    public class PermissionProvider : IPermissionProvider
    {

        public static readonly PermissionRecord AdminSettings  = new PermissionRecord { Name = "Admin Settings", Portal= "Admin", Category = "Settings" };
        public static readonly PermissionRecord AdminContractors  = new PermissionRecord { Name = "Access Admin Contractors", Portal= "Admin", Category = "Contrators" };
        public static readonly PermissionRecord AdminContractorsEdit  = new PermissionRecord { Name = "Access Admin Contractors Edit", Portal= "Admin", Category = "Settings" };
        public static readonly PermissionRecord AdminContractorsDelete  = new PermissionRecord { Name = "Access Admin Contractors Delete", Portal= "Admin", Category = "Settings" };        

        public IEnumerable<PermissionRecord> GetPermissions()
        {
            throw new System.NotImplementedException();
        }
    }
}