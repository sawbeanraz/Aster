using System.Threading.Tasks;
using Aster.Domain.Users;

namespace Aster.Services.Users {


  public class UserService : IUserService
  {
    public async Task<bool> ChangePasswordAsync(User user, string oldPassword, string newPassword)
    {
      throw new System.NotImplementedException();
    }

    public async Task<User> GetUserByEmail(string email)
    {
      throw new System.NotImplementedException();
    }

    public async Task<User> GetUserByUserName(string username)
    {
      throw new System.NotImplementedException();
    }
  }

}