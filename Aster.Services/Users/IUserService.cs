using System.Threading.Tasks;
using Aster.Core.Domain.Security;

namespace Aster.Services.Users {
  public interface IUserService {
    Task<User> GetUserByUserName(string username);

    Task<User> GetUserByEmail(string email);        

    Task<bool> ChangePasswordAsync(User user, string oldPassword, string newPassword);

    Task<bool> ValidatePasswordAsync(User user, string password);
  }
}