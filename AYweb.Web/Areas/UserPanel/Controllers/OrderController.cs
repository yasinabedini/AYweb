using AYweb.Core.DTOs;
using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Entities.Order;
using AYweb.Dal.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly IPermissionService _permissionService;

        public OrderController(IOrderService service, IPermissionService permissionService)
        {
            _service = service;
            _permissionService = permissionService;
        }

        [Route("MyOrders")]
        public IActionResult Index(bool successPay)
        {
            int userId = _permissionService.GetAuthonticatedUserUserId(HttpContext);
            return View(_service.GetOrdersByUserId(userId));
        }

        [Route("MyOrders/{id}")]
        public IActionResult OrderDetails(int id)
        {
            int userId = _permissionService.GetAuthonticatedUserUserId(HttpContext);
            Order order = _service.GetOrderById(id);
            if (order.UserId != userId)
            {
                return NotFound();
            }

            return View(order);
        }


        [HttpGet]
        [Route("CheckOut")]
        public IActionResult CheckOut()
        {
            Order order = _service.GetCurrentCart(HttpContext);
            if (order == null || order.Status.Status.ToLower() != "cart") return NotFound();
            ViewData["Order"] = order;
            return View();
        }

        [HttpPost]
        [Route("CheckOut")]
        public IActionResult CheckOut(PayOrderViewModel order, IFormFile? transactionPicture)
        {
            if (!ModelState.IsValid && order.InPersonDelivery == false || order.PaymentMethod == 0 || order.PaymentMethod == null||string.IsNullOrEmpty(order.CustomerName))
            {
                Order orderData = _service.GetCurrentCart(HttpContext);
                ViewData["Order"] = orderData;
                ViewBag.Notification = true;
                return View(order);
            }
            _service.OrderPayRequest(order, transactionPicture, HttpContext.User.Identity.IsAuthenticated);

            return RedirectToAction("index", "order", new { area = "userpanel", successPay = true });
        }
    }
}
