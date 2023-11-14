using Microsoft.AspNetCore.Mvc;

namespace AYWeb.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
