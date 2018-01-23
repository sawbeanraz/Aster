using Aster.Data;
using Aster.Store.Users.Filters;
using Aster.Users.Abstractions;
using Aster.Users.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aster.Data.Abstractions;

namespace Aster.Store.Users {
    public class UserRepository: EFRepository<User>  {
        
        public UserRepository(IDbContext dbContext): base(dbContext)  {
        }

        
    }
}