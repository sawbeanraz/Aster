using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Localization;



using Aster.Users.Model;
using Aster.Users.Abstractions;

namespace Aster.Users.Services {
    public class UserService : IUserService {
        
        private readonly IOptions<IdentityOptions> _identityOptions;
        private readonly IUserRepository _userRepository;

        
        public UserService(IUserRepository userRepository,
            IOptions<IdentityOptions> identityOptions) {
            _userRepository = userRepository;
            _identityOptions = identityOptions;            
        }
        
        
        public async Task<IUser> CreateUserAsync(string username, string email, string[] roleNames, string password, Action<string, string> error) {
            var result = true;
            
            if(string.IsNullOrWhiteSpace(username)) {
                error("UserName", "A user name is required.");
                result = false;
            }

            if(string.IsNullOrWhiteSpace(password)) {
                error("Password", "A password is required.");
                result = false;
            }

            if(string.IsNullOrWhiteSpace(email)) {
                error("Email", "An email is required.");
                result = false;
            }
            

            if(!result) {
                return null;
            }
            
            if( await _userRepository.GetUserByEmail(email) != null) {
                error(string.Empty, "The email is already used.");
                return null;
            }
            var user = new User(username) {
                Email = email,
                PasswordHash = password,
                EmailConfirmed = false
            };            
            return await _userRepository.AddAsync(user);            
        }

        public async Task<bool> ChangePasswordAsync(IUser user, string currentPassword, string newPassword, Action<string, string> reportError) {            
            //TODO: Validate password and return error
            //Include: Hashing
            return await _userRepository.ChangePasswordAsync(user, currentPassword, newPassword);            
        }


        public async Task<IUser> GetAuthenticatedUserAsync(ClaimsPrincipal principal) {

            if(principal == null) {
                return await Task.FromResult<IUser>(null);
            }
            return await _userRepository
                .GetUserByUserName(principal.Identity.Name);
        }
    }
}
