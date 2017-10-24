using Aster.Users.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Aster.Users.Abstractions;
using System.Threading.Tasks;
using Aster.Users.Model;

namespace Aster.Users.Services {
    /// <summary>
    /// Dummy Service
    /// Required to implement use of database for validating users
    /// </summary>
    public class SignInService : ISignInService {

        private IDictionary<string, (string PasswordHash, User User)> _users =
            new Dictionary<string, (string PasswordHash, User User)>();

        public SignInService(IDictionary<string, string> UserList) {
            foreach(var user in UserList) {
                _users.Add(user.Key, (user.Value, new User(user.Key)));
            }
        }
        

        public async Task<IUser> ValidateCredentials(string username, string password) {            
            var userKey = username.ToLower();

            if(!_users.ContainsKey(userKey)) {
                return null;
            }

            //TODO: Implement hashing for password
            var _passwordHash = _users[userKey].PasswordHash;
            if(!password.Equals(_passwordHash)) {
                return null;
            }
            
            return await Task.FromResult(
                _users[userKey].User);
        }
    }
}