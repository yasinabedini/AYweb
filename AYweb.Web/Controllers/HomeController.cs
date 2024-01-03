using AYweb.Core.DTOs;
using AYweb.Core.DTOs;
using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace AYWeb.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _service;

        public HomeController(IUserService service)
        {
            _service = service;
        }

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
        public IActionResult Counseling(CounselingViewModel counseling)
        {
            if (!ModelState.IsValid) return View();

            _service.CounselingUser(counseling);
            ViewBag.Notification = true;
            return View();
        }
    }
}
