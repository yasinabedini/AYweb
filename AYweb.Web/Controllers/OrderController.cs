using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        public IActionResult MyCart()
        {
            return View(_service.GetCurrentCart(HttpContext));
        }
    }
}
