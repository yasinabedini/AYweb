using AYweb.Core.DTOs;
using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Entities.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;        
        public OrderController(IOrderService service, IPermissionService permissionService)
        {
            _service = service;            
        }

        public IActionResult MyCart()
        {
            return View(_service.GetCurrentCart(HttpContext));
        }
        


        
    }
}
