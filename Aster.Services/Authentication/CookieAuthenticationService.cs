using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Aster.Services.Users;
using Aster.Core.Domain.Security;
// using System.Security.Claims;
// using Microsoft.AspNetCore.Authentication;
// using Nop.Core.Domain.Customers;
// using Nop.Services.Customers;

namespace Aster.Services.Authentication {
    /// <summary>
    /// Represents service using cookie middleware for the authentication
    /// </summary>
    public partial class CookieAuthenticationService : IAuthenticationService {
        
        // private readonly CustomerSettings _customerSettings;
        // private readonly ICustomerService _customerService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        // private Customer _cachedCustomer;
        private readonly IUserService _userService;

        public CookieAuthenticationService(IUserService userService) {
          _userService = userService;
            
          // this._httpContextAccessor = httpContextAccessor;
        }

        public virtual void SignIn(User user, bool isPersistent) {
            // if (customer == null)
            //     throw new ArgumentNullException(nameof(customer));

            // //create claims for customer's username and email
            // var claims = new List<Claim>();

            // if (!string.IsNullOrEmpty(customer.Username))
            //     claims.Add(new Claim(ClaimTypes.Name, customer.Username, ClaimValueTypes.String, NopCookieAuthenticationDefaults.ClaimsIssuer));

            // if (!string.IsNullOrEmpty(customer.Email))
            //     claims.Add(new Claim(ClaimTypes.Email, customer.Email, ClaimValueTypes.Email, NopCookieAuthenticationDefaults.ClaimsIssuer));

            // //create principal for the current authentication scheme
            // var userIdentity = new ClaimsIdentity(claims, NopCookieAuthenticationDefaults.AuthenticationScheme);
            // var userPrincipal = new ClaimsPrincipal(userIdentity);

            // //set value indicating whether session is persisted and the time at which the authentication was issued
            // var authenticationProperties = new AuthenticationProperties
            // {
            //     IsPersistent = isPersistent,
            //     IssuedUtc = DateTime.UtcNow
            // };

            // //sign in
            // await _httpContextAccessor.HttpContext.SignInAsync(NopCookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authenticationProperties);

            // //cache authenticated customer
            // _cachedCustomer = customer;
            return;
        }


        public virtual void SignOut() {
            // //reset cached customer
            // _cachedCustomer = null;

            // //and sign out from the current authentication scheme
            // await _httpContextAccessor.HttpContext.SignOutAsync(NopCookieAuthenticationDefaults.AuthenticationScheme);
            return;
        }

        public virtual User GetAuthenticatedUser() {
            // //whether there is a cached customer
            // if (_cachedCustomer != null)
            //     return _cachedCustomer;

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
            // _cachedCustomer = customer;

            // return _cachedCustomer;
            return null;
        }
    }
}