using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Controllers
{
    public class ErrorController : Controller
    {

        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }

        [Route("NotPermission")]
        public IActionResult PermissionError()
        {
            return View();
        }
    }
}
