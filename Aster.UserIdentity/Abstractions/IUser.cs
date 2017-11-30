using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Users.Abstractions
{
    public interface IUser {
        int Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
    }
}
