using Microsoft.AspNetCore.Mvc;

namespace BlogManagementApp.Controllers
{
    public class StaticController : Controller
    {
        public IActionResult Index()

        {
            return View();
        }
    }
}
