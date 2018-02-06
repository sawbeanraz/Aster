using System;
using System.Threading.Tasks;
using Aster.Data;
using Aster.Core.Domain.Security;

namespace Aster.Services.Users {


  public class UserService : IUserService
  {

    private readonly IRepositoryAsync<User>  _userRepository;

    public UserService(IRepositoryAsync<User> userRepository) {
      _userRepository = userRepository;
    }


    public async Task<bool> ChangePasswordAsync(User user, string oldPassword, string newPassword)
    {
      try {      
        await _userRepository.InsertAsync(user);
        return true;

      } catch(Exception ex) {
        throw ex;
      }

    }

    public Task<User> GetUserByEmail(string email)
    {
      throw new System.NotImplementedException();
    }

    public Task<User> GetUserByUserName(string username)
    {
      throw new System.NotImplementedException();
    }
  }

}