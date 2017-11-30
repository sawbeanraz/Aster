using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Users.Abstractions {
    public interface IRole {
        string Id { get; set; }
        string Name { get; set; }
    }
}