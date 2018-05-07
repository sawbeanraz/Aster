using Aster.Core.Domain.Security;
using System.Threading.Tasks;

namespace Aster.Core.Services.Users {
    public interface IUserService {
        Task<User> GetUserByUserName(string username);

        Task<User> GetUserByEmail(string email);

        Task<bool> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<bool> ValidatePasswordAsync(User user, string password);
    }
}
