using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aster.Web.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Aster.Services.Users;
using Aster.Domain.Users;

namespace Aster.Web.Controllers {

    [Route("auth")]
    public class AuthController : Controller {

        // private ISignInService _signInService;
        // private IUserService _userService;


        private readonly IUserService _userService;

        public AuthController(IUserService userservice) {            
            _userService = userservice;
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
            // if(ModelState.IsValid) {
            //     // var user = await _signInService
            //     //     .ValidateCredentials(model.Username, model.Password);

            //     // await SignInUser(user.UserName);

            //     // if(!string.IsNullOrEmpty(returnUrl)) {
            //     //     return Redirect(returnUrl);
            //     // }

            //     // return RedirectToAction("Index", "Home");
            // }       

            var _user = new User() {
                UserName = "test",
                PasswordHash = "testing"
            };
            

            await _userService.ChangePasswordAsync(_user, "test", "test");
            
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
        

        [Route("register")]
        [HttpGet]
        public IActionResult Register() {
            return View();
        }
        
        [Route("register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserModel model) {
            // if(ModelState.IsValid) {                
            //     var user = await _userService
            //         .CreateUserAsync(model.Username, model.Email, null, model.Password, null);                
            //     return RedirectToAction("Index", "Home");
            // }
            await Task.FromResult(100);// just to ignore warning;
            return View(model);
        }

            
    }
}