using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
