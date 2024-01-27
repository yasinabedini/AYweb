using AYweb.Application.Models.Order.Queries.GetCurrentUserOrders;
using AYweb.Application.Models.Order.Queries.GetUserOrders;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class OrderController : Controller
    {
        private readonly ISender _sender;

        public OrderController(ISender sender)
        {
            _sender = sender;
        }



        #region Orders
        [Route("MyOrders")]
        public IActionResult Index(bool successPay)
        {
            return View(_sender.Send(new GetCurrentUserOrdersQuery()));
        }

        [Route("MyOrders/{id}")]
        public IActionResult OrderDetails(long id)
        {
            var order = _sender.Send(new GetCurrentUserOrdersQuery()).Result.First(t => t.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        #endregion

        //#region CheckOut
        //[HttpGet]
        //[Route("CheckOut")]
        //public IActionResult CheckOut()
        //{
        //    Order order = _service.GetCurrentCart(HttpContext);
        //    if (order == null || order.Status.Status.ToLower() != "cart") return NotFound();
        //    ViewData["Order"] = order;
        //    return View();
        //}
        //[HttpPost]
        //[Route("CheckOut")]
        //public IActionResult CheckOut(PayOrderViewModel order, IFormFile? transactionPicture)
        //{
        //    if (!ModelState.IsValid && order.InPersonDelivery == false || order.PaymentMethod == 0 || order.PaymentMethod == null || string.IsNullOrEmpty(order.CustomerName))
        //    {
        //        Order orderData = _service.GetCurrentCart(HttpContext);
        //        ViewData["Order"] = orderData;
        //        ViewBag.Notification = true;
        //        return View(order);
        //    }
        //    _service.OrderPayRequest(order, transactionPicture, HttpContext.User.Identity.IsAuthenticated);

        //    return RedirectToAction("index", "order", new { area = "userpanel", successPay = true });
        //}
        //#endregion


    }
}
