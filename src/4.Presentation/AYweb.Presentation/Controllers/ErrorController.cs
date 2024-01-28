using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
