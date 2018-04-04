using Aster.Data;
using System;

namespace Aster.Core.Domain.Security {
    public class PermissionRecord : BaseEntity {
        public string Name { get; set; }       //full name of permission        
        public string Portal { get; set; }          //Portal Admin, 
        public string Category { get; set; }     //Sub classification for permission e.g Admin > Payroll Settings

    }
}