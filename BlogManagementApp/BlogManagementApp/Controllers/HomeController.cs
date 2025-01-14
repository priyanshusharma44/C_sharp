using BlogManagementApp.Models;
using BlogManagementApp.Secuirty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogManagementApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDataProtector _protector;
        private readonly BlogManagementContext _appContext;
        private readonly IWebHostEnvironment _env;

        public HomeController(DataSecurityKey dkey, IDataProtectionProvider provider, BlogManagementContext context, IWebHostEnvironment env)
        {
            _protector = provider.CreateProtector(dkey.key);
            _appContext = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<UserList> users = _appContext.UserLists.ToList();
            List<UserListEdit> model = users.Select(e => new UserListEdit
            {
                UserId = e.UserId,
                FullName = e.FullName,
                CurrentAddress = e.CurrentAddress,
                EmailAddress = e.EmailAddress,
                UserPhoto = e.UserPhoto,
                UserPassword = e.UserPassword,
                UserRole = e.UserRole,
                EncId = _protector.Protect(e.UserId.ToString())
            }).ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserListEdit model)
        {
            short maxId = _appContext.UserLists.Any()
                ? (short)(_appContext.UserLists.Max(x => x.UserId) + 1)
                : (short)1;

            model.UserId = maxId;

            if (model.UserFile != null)
            {
                string fileName = "UserImage" + Guid.NewGuid() + Path.GetExtension(model.UserFile.FileName);
                string filePath = Path.Combine(_env.WebRootPath, "UserImage", fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    model.UserFile.CopyTo(stream);
                }
                model.UserPhoto = fileName;
            }

            UserList user = new UserList
            {
                UserId = model.UserId,
                FullName = model.FullName,
                UserPassword = _protector.Protect(model.UserPassword),
                CurrentAddress = model.CurrentAddress,
                EmailAddress = model.EmailAddress,
                UserPhoto = model.UserPhoto,
                UserRole = model.UserRole
            };

            _appContext.Add(user);
            _appContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("ID cannot be null or empty.");
            }

            try
            {
                short userId = Convert.ToInt16(_protector.Unprotect(id));
                UserList user = _appContext.UserLists.Find(userId);

                if (user == null)
                {
                    return NotFound();
                }

                UserListEdit model = new UserListEdit
                {
                    UserId = user.UserId,
                    FullName = user.FullName,
                    CurrentAddress = user.CurrentAddress,
                    EmailAddress = user.EmailAddress,
                    UserPhoto = user.UserPhoto,
                    UserRole = user.UserRole,
                    EncId = id
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error unprotecting the ID: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Edit(UserListEdit model)
        {
            if (ModelState.IsValid)
            {
                short userId = Convert.ToInt16(_protector.Unprotect(model.EncId));
                UserList user = _appContext.UserLists.Find(userId);

                if (user == null)
                {
                    return NotFound();
                }

                user.FullName = model.FullName;
                user.CurrentAddress = model.CurrentAddress;
                user.EmailAddress = model.EmailAddress;
                user.UserRole = model.UserRole;

                if (model.UserFile != null)
                {
                    string fileName = "UserImage" + Guid.NewGuid() + Path.GetExtension(model.UserFile.FileName);
                    string filePath = Path.Combine(_env.WebRootPath, "UserImage", fileName);
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.UserFile.CopyTo(stream);
                    }
                    user.UserPhoto = fileName;
                }

                _appContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Details(string id)
        {
            try
            {
                int userId = Convert.ToInt32(_protector.Unprotect(id));
                var user = _appContext.UserLists.Where(i => i.UserId == userId).ToList();
                return Json(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error unprotecting the ID: {ex.Message}");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult ProfileImage()
        {
            var user = _appContext.UserLists.FirstOrDefault(u => u.UserId == Convert.ToInt16(User.Identity.Name));
            ViewData["img"] = user?.UserPhoto;
            return PartialView("_Profile");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Delete(string id)
        {
            try
            {
                short userId = Convert.ToInt16(_protector.Unprotect(id));
                var user = _appContext.UserLists.Find(userId);

                if (user != null)
                {
                    _appContext.UserLists.Remove(user);
                    _appContext.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error unprotecting the ID: {ex.Message}");
            }
        }

        public IActionResult Profile()
        {
            var currentUserId = Convert.ToInt16(User.Identity!.Name);
            var currentUser = _appContext.UserLists.Find(currentUserId);
            var allUsers = _appContext.UserLists.ToList();

            var model = new ProfileViewModel
            {
                CurrentUser = currentUser,
                UserList = allUsers.Select(e => new UserListEdit
                {
                    UserId = e.UserId,
                    FullName = e.FullName,
                    CurrentAddress = e.CurrentAddress,
                    EmailAddress = e.EmailAddress,
                    UserPhoto = e.UserPhoto,
                    UserRole = e.UserRole,
                    EncId = _protector.Protect(e.UserId.ToString())
                }).ToList()
            };

            return View(model);
        }
    }
}
