using AYweb.Application.Models.Order.Commands.ChnageOrderLineAmount;
using AYweb.Application.Models.Order.Commands.DeleteOrderLineFromOrder;
using AYweb.Application.Models.Order.Queries.GetCurrentUserCurrentOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Controllers
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
        public void ChangeOrderLineCount(long productId, int count)
        {
            //  _service.ChangeOrderLineCount(productId, count, HttpContext);
            _sender.Send(new ChnageOrderLineAmountCommand { ProductId = productId, Amount = count });
        }

        [HttpPost]
        public IActionResult DeleteOrderLine(long productId)
        {
            _sender.Send(new DeleteOrderLineFromOrderCommand() { productId = productId });
            return RedirectToAction("MyCart", "Index", new { area = "UserPanel" });
        }


    }
}
