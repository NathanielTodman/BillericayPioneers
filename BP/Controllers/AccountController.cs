using BP.Data;
using BP.Data.Authentication;
using BP.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BP.Controllers
{
    public class AccountController : Controller
    {

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid username/password");
                return View();
            }
            var user = new User("", "", model.Username, model.Password);
            using (var context = new BPContext())
            {
                if (UserAuthentication.IsValidUser(user, context))
                {
                    var temp = UserAuthentication.GetUser(user.Username, user.Password, context);
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, temp.FirstName),
                new Claim("FullName", temp.ToString()),
                new Claim(ClaimTypes.Role, temp.Access.ToString()),
            };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. Required when setting the 
                        // ExpireTimeSpan option of CookieAuthenticationOptions 
                        // set with AddCookie. Also required when setting 
                        // ExpiresUtc.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    if (model.ReturnURL != null && Url.IsLocalUrl(model.ReturnURL))
                        return Redirect(model.ReturnURL);
                    return RedirectToAction("GetPlayerRankings", "Performances");
                }
                else
                {
                    return View("Login");
                }
            }
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            using (var context = new BPContext())
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else if (context.Users.Any(g => g.Username == user.Username))
                {
                    ModelState.AddModelError("", "Username already exists");
                    return View();
                }
                else
                {
                    await UserAuthentication.AddAsync(user, context);
                    return View("Login");
                }
            }
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
