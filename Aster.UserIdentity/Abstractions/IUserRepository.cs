using Aster.Data.Abstractions;
using Aster.Users.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Users.Abstractions
{
    public interface IUserRepository: IRepository<User>, IRepositoryAsync<User> {
        Task<User> GetUserByUserName(string username);
        Task<User> GetUserByEmail(string email);
        
        Task<bool> ChangePasswordAsync(IUser user, string oldPassword, string newPassword);
        
    }
}
