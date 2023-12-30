using AYweb.Core.DTOs;
using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Entities.Plan;
using AYweb.Dal.Entities.Transaction;
using AYweb.Dal.Entities.User;
using AYweb.Dal.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly;

namespace AYweb.Web.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanService _service;
        private readonly IPermissionService _permissionService;

        public PlanController(IPlanService service, IPermissionService permissionService)
        {
            _service = service;
            _permissionService = permissionService;
        }

        public IActionResult Index()
        {
            return View(_service.GetAllPlans());
        }

        public IActionResult CheckOut(int id)
        {
            ViewData["Plan"] = _service.GetPlanById(id);
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CheckOut(PlanCheckOutViewModel checkOut, IFormFile? TransactionScreenshot)
        {
            if (checkOut.PaymentMethod == null || checkOut.PaymentMethod == 0 || checkOut.PaymentMethod == (int)_PaymentMethods.CardByCard && TransactionScreenshot == null)
            {
                ViewData["Plan"] = _service.GetPlanById(checkOut.PlanId);
                ViewBag.Notification = true;
                checkOut.PaymentMethod = 0;
                return View();
            }

            User user = _permissionService.GetAuthonticatedUser(HttpContext);
            Plan plan = _service.GetPlanById(checkOut.PlanId);

            _service.AddPlanToUser(user.UserId, plan, TransactionScreenshot);
            return View();
        }

    }
}
