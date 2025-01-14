using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAppWithLogin.Models;
namespace StudentAppWithLogin.Controllers
{
    [Authorize]
    public class UserListController : Controller
    {
        private readonly StudentDbContext _context;

        public UserListController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: UserList
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserLists.ToListAsync());
        }

        // Handles GET requests for displaying the login form
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            var loginModel = new LoginModel { ReturnUrl = returnUrl };
            return View(loginModel);
        }

        // Handles POST requests for processing the login form
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var currentUser = await _context.UserLists
                .Where(u => u.LoginId.ToUpper().Equals(login.LoginId.ToUpper())
                            && u.LoginPassword.Equals(login.Password)
                            && u.LoginStatus.Equals("Active"))
                .FirstOrDefaultAsync();

            if (currentUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, currentUser.UserName),
                    new Claim(ClaimTypes.NameIdentifier, currentUser.UserId.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties { IsPersistent = login.RememberMe });

                if (!string.IsNullOrEmpty(login.ReturnUrl) && Url.IsLocalUrl(login.ReturnUrl))
                {
                    return Redirect(login.ReturnUrl);
                }

                return RedirectToAction("Index", "UserList");
            }

            ModelState.AddModelError("", "Login failed. Invalid credentials.");
            return View(login);
        }

        // Handles user logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "UserList");
        }

        // GET: UserList/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("UserId,UserName,LoginId,LoginPassword,LoginStatus")] UserList userList)
        {
            // Check if model state is valid
            if (ModelState.IsValid)
            {
                try
                {
                    // Log the current state for debugging
                    Console.WriteLine($"Creating User: {userList.UserName}, LoginId: {userList.LoginId}");

                    // Add userList to context
                    _context.Add(userList);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // Log the exception details
                    ModelState.AddModelError("", $"Unable to save changes. Try again, and if the problem persists see your system administrator. Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Log other exceptions
                    ModelState.AddModelError("", $"An unexpected error occurred: {ex.Message}");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(userList);
        }
        // GET: UserList/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userList = await _context.UserLists.FindAsync(id);
            if (userList == null)
            {
                return NotFound();
            }

            return View(userList);
        }

        // POST: UserList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,LoginId,LoginPassword,LoginStatus")] UserList userList)
        {
            if (id != userList.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserListExists(userList.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userList);
        }

        // GET: UserList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userList = await _context.UserLists
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userList == null)
            {
                return NotFound();
            }

            return View(userList);
        }

        // POST: UserList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userList = await _context.UserLists.FindAsync(id);
            if (userList != null)
            {
                _context.UserLists.Remove(userList);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: UserList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userList = await _context.UserLists
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userList == null)
            {
                return NotFound();
            }

            return View(userList);
        }

        private bool UserListExists(int id)
        {
            return _context.UserLists.Any(e => e.UserId == id);
        }
    }
}
