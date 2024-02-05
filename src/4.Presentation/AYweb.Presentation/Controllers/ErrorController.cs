using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
