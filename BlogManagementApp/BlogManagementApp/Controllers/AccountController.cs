using BlogManagementApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogManagementApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly BlogManagementContext _appContext;
        private object uEdit;

        public AccountController(BlogManagementContext context)
        {
            _appContext = context;
        }

        public BlogManagementContext AppContext => _appContext;

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserListEdit uedit)
        {
            var users = _appContext.UserLists.ToList();
                if (users != null)
            {
                var u = users.Where(x => x.EmailAddress.ToUpper().Equals(uedit.EmailAddress.ToUpper())&&  x.UserPassword.Equals(uedit.UserPassword )).FirstOrDefault();

                if (u != null)
                {
                    List<Claim> claims = new() {
                        new Claim(ClaimTypes.Name,
                                  u.UserId.ToString()),
                        new Claim(ClaimTypes.Role,u.UserRole),
                        new Claim("FullName",u.FullName)
                    };
                    var identity= new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties { IsPersistent=true});

                    return RedirectToAction("Dashboard");
                }
            }
            else {
                ModelState.AddModelError("", "InvalidUser");
            }
            return View();
        }
      
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            return RedirectToAction("Index", "Home"); // Redirects to the Index action of the Home controller
        }
    }
}
