using Aster.Data;
using Aster.Store.Users.Filters;
using Aster.Users.Abstractions;
using Aster.Users.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Store.Users {
    public class UserRepository: Repository<User>, IUserRepository  {
        
        public UserRepository(UserContext dbContext): base(dbContext)  {
        }

        public async Task<User> GetUserByEmail(string email) {            
            return await GetSingleAsync(
                new UserByEmailFilter(email));;
        }

        public async Task<User> GetUserByUserName(string username) {

            var _filter = new UserByUsernameFilter(username);            
            var user = await GetSingleAsync(_filter);

            return user;            
        }

        public async Task<bool> ChangePasswordAsync(IUser user, string oldPassword, string newPassword) {
            var _User = await GetByIdAsync(user.Id);

            if(_User.PasswordHash != oldPassword) {                
                return false;
            }             
            _User.PasswordHash = newPassword;
            Update(_User);
            return true;            
        }
    }
}