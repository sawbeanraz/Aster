using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aster.Web.Models;
using Aster.Users.Abstractions.Services;
using Aster.Users.Model;
using Aster.Users.Abstractions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Aster.Web.Controllers {

    [Route("auth")]
    public class AuthController : Controller {

        private ISignInService _signInService;

        public AuthController(ISignInService signInService) {
            _signInService = signInService;
        }


        [Route("signin")]
        public IActionResult SignIn() {
            return View();
        }

        [Route("signout")]        
        public async Task<IActionResult> SignOut() {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }


        [Route("signin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInModel model, string returnUrl = null ) {
            if(ModelState.IsValid) {
                var user = await _signInService
                    .ValidateCredentials(model.Username, model.Password);

                await SignInUser(user.UserName);

                if(!string.IsNullOrEmpty(returnUrl)) {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");                
            }            
            return View(model);
        }
        
        public async Task SignInUser(string username) {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim("name", username)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme,"name", null);

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
        }
            
    }
}