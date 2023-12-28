using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Areas.UserPanel.Controllers
{
    [Area("userpanel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
