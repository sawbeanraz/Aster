using Aster.Core.Domain;
/* 
  TODO: Instead of User should let's   
  AdminUser, 
  Candidate
  ClientContact
  and there base class will be User
*/
namespace Aster.Services.Authentication {

    public partial interface IAuthenticationService {

        void SignIn(User user, bool isPersistent);

        void SignOut();

        User GetAuthenticatedUser();
    }
}