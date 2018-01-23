using System.Threading.Tasks;
using Aster.Domain.Users;

namespace Aster.Services.Users {
  public interface IUserService {
    Task<User> GetUserByUserName(string username);
    Task<User> GetUserByEmail(string email);        
    Task<bool> ChangePasswordAsync(User user, string oldPassword, string newPassword);
  }
}