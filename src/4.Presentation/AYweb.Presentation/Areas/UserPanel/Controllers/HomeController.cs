using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Areas.UserPanel.Controllers
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
