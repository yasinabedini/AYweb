using AYweb.Application.Models.User.Commands.CounselingUser;
using AYweb.Domain.Models.Service.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Controllers
{
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }

        [Route("Counseling")]
        public IActionResult Counseling(string? title)
        {
            return View();
        }

        [HttpPost]
        [Route("Counseling")]
        [ValidateAntiForgeryToken]
        public IActionResult Counseling([FromServices]ISender sender,CounselingUserCommand counseling)
        {
            if (!ModelState.IsValid) return View();

            sender.Send(counseling);
            ViewBag.Notification = true;
            return View();
        }
    }
}
