using Microsoft.AspNetCore.Mvc;

namespace Movie.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
