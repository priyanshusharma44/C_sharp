using BlogManagementApp.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogManagementApp.Secuirty;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogManagementApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManagementContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IDataProtector _protector;

        public BlogController(BlogManagementContext context, IWebHostEnvironment env, IDataProtectionProvider protector, DataSecurityKey key)
        {
            _env = env;
            _context = context;
            _protector = protector.CreateProtector(key.key);
        }

        // GET: BlogController
        public IActionResult Index()
        {
            var users = _context.BlogContents.ToList();
            var model = users.Select(e => new BlogContentEdit
            {
                Bid = e.Bid,
                SectionDescription = e.SectionDescription,
                SectionHeading = e.SectionHeading,
                SectionImage = e.SectionImage,
                UploadeUserId = Convert.ToInt16(e.UploadeUserId),
                PostDate = e.PostDate,
                EncId = _protector.Protect(e.Bid.ToString())
            }).ToList();
            return View(model);
        }

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
        {
            var u = _context.BlogContents.Where(x => x.Bid == id).First();
            return View(u);
        }

        // GET: BlogController/Create
        public ActionResult AddBlog()
        {
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBlog(BlogContent edit)
        {
            short maxid;
            if (_context.BlogContents.Any())

                maxid = Convert.ToInt16(_context.BlogContents.Max(x => x.Bid)  + 1);
            else
                maxid = 1;
            edit.Bid = maxid;
            edit.CancleDate = edit.CancleDate;
            edit.PostDate = edit.PostDate;

            try
            {
                _context.Add(edit);
                _context.SaveChanges();
                return View();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        // GET: BlogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
