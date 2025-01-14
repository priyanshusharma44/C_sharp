using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCORECRUDASP.Models;

namespace EFCORECRUDASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToDoAppDbContext _context;

        public HomeController(ToDoAppDbContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            return View(await _context.TodoLists.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoList = await _context.TodoLists
                .FirstOrDefaultAsync(m => m.Sn == id);
            if (todoList == null)
            {
                return NotFound();
            }

            return View(todoList);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sn,TaskName,Description,EntryDate,DeadLine,CompleteDate")] TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoList);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }
            return View(todoList);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Sn,TaskName,Description,EntryDate,DeadLine,CompleteDate")] TodoList todoList)
        {
            if (id != todoList.Sn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoListExists(todoList.Sn))
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
            return View(todoList);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoList = await _context.TodoLists
                .FirstOrDefaultAsync(m => m.Sn == id);
            if (todoList == null)
            {
                return NotFound();
            }

            return View(todoList);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList != null)
            {
                _context.TodoLists.Remove(todoList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoListExists(long id)
        {
            return _context.TodoLists.Any(e => e.Sn == id);
        }
    }
}
