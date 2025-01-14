using Microsoft.AspNetCore.Mvc;

namespace dotNetClass.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
