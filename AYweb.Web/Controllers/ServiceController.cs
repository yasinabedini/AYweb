using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
