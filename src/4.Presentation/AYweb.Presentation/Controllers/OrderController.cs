using AYweb.Application.Models.Order.Queries.GetCurrentUserCurrentOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISender _sender;

        public OrderController(ISender sender)
        {
            _sender = sender;
        }
     

        public IActionResult MyCart()
        {
            return View(_sender.Send(new GetCurrentUserCurrentOrderQuery()).Result);
        }

        [HttpPost]
        public void ChangeOrderLineCount(int productId, int count)
        {
          //  _service.ChangeOrderLineCount(productId, count, HttpContext);
        }

        public IActionResult DeleteOrderLine(int productId)
        {
            //_service.DeleteOrderLine(productId, HttpContext);
            return RedirectToAction("MyCart", "Index", new { area = "UserPanel" });
        }


    }
}
