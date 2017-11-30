using Aster.Data;
using Aster.Users.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Store.Users.Filters
{
    public class UserByEmailFilter: BaseFilter<User> {
        public UserByEmailFilter(string email): base(u => u.Email == email)
        {
        }
    }
}
