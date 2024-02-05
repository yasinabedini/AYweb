using AYweb.Application.Models.Plan.Queries.GetPlans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Controllers
{
    public class PlanController : Controller
    {
        private readonly ISender _sender;

        public PlanController(ISender sender)
        {
            _sender = sender;
        }

        public IActionResult Index()
        {
            return View(_sender.Send(new GetPlansQuery()).Result);
        }

        //public IActionResult CheckOut(int id)
        //{
        //    ViewData["Plan"] = _service.GetPlanById(id);
        //    return View();
        //}

        //[HttpPost]
        //[Authorize]
        //public IActionResult CheckOut(PlanCheckOutViewModel checkOut, IFormFile? TransactionScreenshot)
        //{
        //    if (checkOut.PaymentMethod == null || checkOut.PaymentMethod == 0 || checkOut.PaymentMethod == (int)_PaymentMethods.CardByCard && TransactionScreenshot == null)
        //    {
        //        ViewData["Plan"] = _service.GetPlanById(checkOut.PlanId);
        //        ViewBag.Notification = true;
        //        checkOut.PaymentMethod = 0;
        //        return View();
        //    }

        //    User user = _permissionService.GetAuthonticatedUser(HttpContext);
        //    Plan plan = _service.GetPlanById(checkOut.PlanId);

        //    _service.AddPlanToUser(user.UserId, plan, TransactionScreenshot);
        //    return View();
        //}

    }
}
