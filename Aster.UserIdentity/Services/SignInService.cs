using System;
using System.Collections.Generic;
using System.Text;
using Aster.Users.Abstractions;
using System.Threading.Tasks;
using Aster.Users.Model;
using Aster.Data.Abstractions;

namespace Aster.Users.Services {
    /// <summary>
    /// Dummy Service
    /// Required to implement use of database for validating users
    /// </summary>
    public class SignInService : ISignInService {

        private IDictionary<string, (string PasswordHash, User User)> _users =
            new Dictionary<string, (string PasswordHash, User User)>();


        // private readonly IUserRepository _userRepository;

        private readonly IRepositoryAsync<User> _userRepository;
        
        public SignInService(IRepositoryAsync<User> userRepository) {
            _userRepository = userRepository;
        }

        

        
        public async Task<IUser> ValidateCredentials(string username, string password) {            
            // var user = await _userRepository.GetUserByUserName(username.ToLower());

            var user = await _userRepository.GetByIdAsync(null);

            
            
            //var _passwordHash = _users[userKey].PasswordHash;
            if(!password.Equals(user.PasswordHash)) {
                return null;
            }            
            return user;
        }
    }
}