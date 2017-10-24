using Aster.Users.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;




namespace Aster.Users.Services {
    public class UserStore:
        IUserStore<IUser> {



        //TODO: Implement following interfaces as required
        //IUserRoleStore<IUser>,
        //IUserPasswordStore<IUser>,
        //IUserEmailStore<IUser>,
        //IUserSecurityStampStore<IUser>



        private readonly ISession _session;
        private readonly ILookupNormalizer _keyNormalizer;


        //TODO: Required to implement Roles for the System
        //private readonly IRoleProvider _roleProvider;
        public UserStore(ISession session,
            //IRoleProvider roleProvider,
            ILookupNormalizer keyNormalizer) {
            

            _session = session;
            

            //_roleProvider = roleProvider;
            _keyNormalizer = keyNormalizer;         //TODO: Required to learn more about KeyNormalizer
        }


        
        #region UserStore
        public Task<IdentityResult> CreateAsync(IUser user, CancellationToken cancellationToken) {


            if(user == null) {
                throw new ArgumentNullException(nameof(user));
            }
            //_session.Save(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(IUser user, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public void Dispose() { }

        public Task<IUser> FindByIdAsync(string userId, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public Task<IUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(IUser user, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(IUser user, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(IUser user, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public string NormalizeKey(string key) {
            return _keyNormalizer == null ? key : _keyNormalizer.Normalize(key);
        }

        public Task SetNormalizedUserNameAsync(IUser user, string normalizedName, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(IUser user, string userName, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(IUser user, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
        #endregion
    }
}