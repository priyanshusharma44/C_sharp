using CRUDASPNET.Models;
using Microsoft.AspNetCore.Mvc;

public class StudentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // READ: List All Students
    public IActionResult Index()
    {
        var students = _context.Students.ToList();
        return View(students);
    }

    // CREATE: Show Form
    public IActionResult Create()
    {
        return View();
    }

    // CREATE: Save Data
    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }

    // UPDATE: Show Edit Form
    public IActionResult Edit(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // UPDATE: Save Changes
    [HttpPost]
    public IActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }

    // DELETE: Confirm Delete
    public IActionResult Delete(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // DELETE: Remove Record
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var student = _context.Students.Find(id);
        _context.Students.Remove(student);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
