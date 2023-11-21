using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlogDetails(int id)
        {
            return View();
        }
    }
}
