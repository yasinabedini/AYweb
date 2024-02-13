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
    }
}
