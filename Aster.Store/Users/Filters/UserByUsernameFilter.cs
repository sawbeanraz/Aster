using Aster.Data;
using Aster.Users.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Store.Users.Filters
{
    public class UserByUsernameFilter: BaseFilter<User>
    {

        public UserByUsernameFilter(string username): base(u => u.UserName == username)
        {            
        }
    }
}
