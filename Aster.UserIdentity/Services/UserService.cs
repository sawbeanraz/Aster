using Aster.Users.Abstractions.Services;
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
        
        private readonly UserManager<IUser> _userManager;        
        //Not sure what these are used for: Copied from OrchardCMSCore
        private readonly IOptions<IdentityOptions> _identityOptions;

        private readonly IStringLocalizer<UserService> T;        

        public UserService(UserManager<IUser> userManager, IOptions<IdentityOptions> identityOptions, IStringLocalizer<UserService> stringLocalizer) {
            _userManager = userManager;
            _identityOptions = identityOptions;
            T = stringLocalizer;
        }

        public async Task<IUser> CreateUserAsync(string username, string email, string[] roleNames, string password, Action<string, string> error) {
            var result = true;

            
            if(string.IsNullOrWhiteSpace(username)) {
                error("UserName", T["A user name is required."]);
                result = false;
            }

            if(string.IsNullOrWhiteSpace(password)) {
                error("Password", T["A password is required."]);
                result = false;
            }

            if(string.IsNullOrWhiteSpace(email)) {
                error("Email", T["An email is required."]);
                result = false;
            }
            

            if(!result) {
                return null;
            }

            
            if(await _userManager.FindByEmailAsync(email) != null) {
                error(string.Empty, T["The email is already used."]);
                return null;
            }

            //var user = new User {
            //    UserName = username,
            //    Email = email,
            //    RoleNames = new List<string>(roleNames)
            //};
            var user = new User(username);

            var identityResult = await _userManager.CreateAsync(user, password);

            if(!identityResult.Succeeded) {
                //TODO Required to return error
                //ProcessValidationErrors(identityResult.Errors, user, reportError);                
                return null;
            }

            return user;
        }

        public async Task<bool> ChangePasswordAsync(IUser user, string currentPassword, string newPassword, Action<string, string> reportError) {

            var identityResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if(!identityResult.Succeeded) {
                //TODO: Need to report error
                //ProcessValidationErrors(identityResult.Errors, (User)user, reportError);                
            }

            return identityResult.Succeeded;


        }


        public async Task<IUser> GetAuthenticatedUserAsync(ClaimsPrincipal principal) {

            if(principal == null) {
                return await Task.FromResult<IUser>(null);
            }

            return await _userManager.GetUserAsync(principal);

        }
    }
}
