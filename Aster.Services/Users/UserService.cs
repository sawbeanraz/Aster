using System;
using System.Threading.Tasks;
using System.Linq;
using Aster.Data;
using Aster.Core.Domain.Security;
using Aster.Services.Security;


namespace Aster.Services.Users {


  public class UserService : IUserService
  {

    private readonly IRepositoryAsync<User>  _userRepository;
    private readonly IEncryptionService _encryptionService;

    public UserService(
      IRepositoryAsync<User> userRepository,
      IEncryptionService encryptionService) {
      _userRepository = userRepository;
      _encryptionService = encryptionService;
    }


    public async Task<bool> ChangePasswordAsync(User user, string oldPassword, string newPassword) {
      try {      
        await _userRepository.InsertAsync(user);
        return true;

      } catch(Exception ex) {
        throw ex;
      }
    }

    public async Task<User> GetUserByEmail(string email) {

      if (string.IsNullOrWhiteSpace(email))
            return null;

        var query = from u in _userRepository.List
            orderby u.Id
            where u.Email == email
            select u;
        var user = query.FirstOrDefault();

        return await Task.FromResult(user);
    }



    public Task<User> GetUserByUserName(string username) {
      throw new System.NotImplementedException();
    }


    public async Task<bool> ValidatePasswordAsync(User user, string password) {
      try {
        var hashedPassword = _encryptionService.Hash(password, "u53r-pa55w0rd");
        return await Task.FromResult(user.PasswordHash == hashedPassword);
      } catch (Exception ex) {
        throw  ex;
      }

    }

  }

}