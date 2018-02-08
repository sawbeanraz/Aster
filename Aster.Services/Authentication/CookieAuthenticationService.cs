using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Aster.Services.Users;
using Aster.Core.Domain.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
// using Nop.Core.Domain.Customers;
// using Nop.Services.Customers;

namespace Aster.Services.Authentication {


  public partial class CookieAuthenticationService : IAuthenticationService {
      
      // private readonly CustomerSettings _customerSettings;
      // private readonly ICustomerService _customerService;
      private readonly IHttpContextAccessor _httpContextAccessor;
      // private Customer _cachedUser;
      private readonly IUserService _userService;

      public CookieAuthenticationService(
        IUserService userService,
        IHttpContextAccessor httpContextAccessor) {


        _userService = userService;          
         _httpContextAccessor = httpContextAccessor;
      }

      public virtual async void SignIn(User user, bool isPersistent) {
        if (user == null) {
          throw new ArgumentNullException(nameof(user));
        }

        
        var claims = new List<Claim>();

        if (!string.IsNullOrEmpty(user.UserName))
          claims.Add(new Claim(ClaimTypes.Name, user.UserName, ClaimValueTypes.String, "Aster.Security"));    //TODO: make the string configurable or from static class -- ClaimIssuer

        if (!string.IsNullOrEmpty(user.Email))
          claims.Add(new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email, "Aster.Security"));   //TODO: make issuer string configurable or from static class

        //create principal for the current authentication scheme
        var userIdentity = new ClaimsIdentity(claims, "Authentication"); //TODO: make the string configurable or from static class
        var userPrincipal = new ClaimsPrincipal(userIdentity);

        //set value indicating whether session is persisted and the time at which the authentication was issued
        var authenticationProperties = new AuthenticationProperties {
            IsPersistent = isPersistent,
            IssuedUtc = DateTime.UtcNow
        };

        //sign in 
        //TODO: make the string configuration or from static class -- AuthenticationScheme
        await _httpContextAccessor.HttpContext.SignInAsync("Authentication", userPrincipal, authenticationProperties);

        // //cache authenticated user  -- TODO: Cache user
        // _cachedUser = userIdentity;
        return;
      }


      public virtual async void SignOut() {
          // //reset cached user -- TODO
          // _cachedUser = null;
          
          await _httpContextAccessor.HttpContext.SignOutAsync("Authentication");
          return;
      }

      public virtual User GetAuthenticatedUser() {
          // //whether there is a cached customer
          // if (_cachedUser != null)
          //     return _cachedUser;

          // //try to get authenticated user identity
          // var authenticateResult = _httpContextAccessor.HttpContext.AuthenticateAsync(NopCookieAuthenticationDefaults.AuthenticationScheme).Result;
          // if (!authenticateResult.Succeeded)
          //     return null;

          // Customer customer = null;
          // if (_customerSettings.UsernamesEnabled)
          // {
          //     //try to get customer by username
          //     var usernameClaim = authenticateResult.Principal.FindFirst(claim => claim.Type == ClaimTypes.Name
          //         && claim.Issuer.Equals(NopCookieAuthenticationDefaults.ClaimsIssuer, StringComparison.InvariantCultureIgnoreCase));
          //     if (usernameClaim != null)
          //         customer = _customerService.GetCustomerByUsername(usernameClaim.Value);
          // }
          // else
          // {
          //     //try to get customer by email
          //     var emailClaim = authenticateResult.Principal.FindFirst(claim => claim.Type == ClaimTypes.Email 
          //         && claim.Issuer.Equals(NopCookieAuthenticationDefaults.ClaimsIssuer, StringComparison.InvariantCultureIgnoreCase));
          //     if (emailClaim != null)
          //         customer = _customerService.GetCustomerByEmail(emailClaim.Value);
          // }

          // //whether the found customer is available
          // if (customer == null || !customer.Active || customer.RequireReLogin || customer.Deleted || !customer.IsRegistered())
          //     return null;

          // //cache authenticated customer
          // _cachedUser = customer;

          // return _cachedUser;
          return null;
      }
  }
}