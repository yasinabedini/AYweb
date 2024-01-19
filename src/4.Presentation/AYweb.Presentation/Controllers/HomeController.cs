using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
