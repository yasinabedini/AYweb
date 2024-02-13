using AYweb.Application.Models.Order.Commands.PayOrder;
using AYweb.Application.Models.Order.Queries.GetCurrentUserCurrentOrder;
using AYweb.Application.Models.Order.Queries.GetCurrentUserOrders;
using AYweb.Application.Models.Order.Queries.GetUserOrders;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Domain.Models.Order.Enums;
using AYweb.Domain.Models.Transaction.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Areas.UserPanel.Controllers
{
    [Area("userpanel")]
    [Authorize]
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
            return View(_sender.Send(new GetCurrentUserOrdersQuery()).Result);
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

        #region CheckOut
        [HttpGet]
        [Route("CheckOut")]
        public IActionResult CheckOut()
        {
            var order = _sender.Send(new GetCurrentUserCurrentOrderQuery()).Result;
            if (order == null || order.OrderStatus != _OrderStatus.completing.ToString()) return NotFound();
            ViewData["Order"] = order;
            return View();
        }

        [HttpPost]
        [Route("CheckOut")]
        [ValidateAntiForgeryToken]
        public IActionResult CheckOut(PayOrderCommand order, IFormFile? transactionPicture)
        {
            if (!ModelState.IsValid && order.InPersonDelivery == false || order.PaymentMethod == 0 || order.PaymentMethod == null || string.IsNullOrEmpty(order.CustomerName) || transactionPicture == null && order.PaymentMethod == 1)
            {
                var orderData = _sender.Send(new GetCurrentUserCurrentOrderQuery()).Result;
                ViewData["Order"] = orderData;
                ViewBag.Notification = true;
                return View(order);
            }
            if (transactionPicture is not null)
            {
                order.TransactionScreenShot = transactionPicture;
            }            
            _sender.Send(order);

            return RedirectToAction("index", "order", new { area = "userpanel", successPay = true });
        }
        #endregion


    }
}
