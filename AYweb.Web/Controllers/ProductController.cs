using AYweb.Core.DTOs;
using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Entities.Order;
using AYweb.Dal.Entities.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace AYweb.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IOrderService _orderService;

        public ProductController(IProductService service, IOrderService orderService)
        {
            _service = service;
            _orderService = orderService;
        }

        public IActionResult Index(int pageId = 1, string filter = "", string orderBy = "")
        {
            int take = 12;
            var products = _service.GetProducts(pageId, filter, orderBy, true, take);

            ViewBag.pageId = pageId;

            if (pageId > 1)
            {
                ViewBag.lastPage = pageId - 1;
            }
            else
            {
                ViewBag.lastPage = 1;
            }

            if (pageId == products.Item2 || pageId > products.Item2)
            {
                ViewBag.nextPage = pageId;
            }
            else
            {
                ViewBag.nextPage = pageId + 1;
            }

            ViewBag.take = take;

            return View(products);
        }

        [HttpGet]
        [Route("Product/{id}")]
        public IActionResult ProductDetails(int id)
        {
            return View(_service.GetProductById(id));
        }

        [HttpPost]
        public IActionResult AddProductToCart(AddProductToOrderViewModel addInfo)
        {
            Order currentCart = _orderService.GetCurrentCart(HttpContext);
            Product product = _service.GetProductById(addInfo.ProductId);
            if (currentCart is null)
            {
                currentCart = new Order()
                {
                    Status = new OrderStatus("Cart"),
                    CreateDate = DateTime.Now,
                    EndPrice = 0,
                    IsDelete = false
                };
                _orderService.AddOrder(currentCart);                
            }            

            _orderService.AddProductToOrder(currentCart.Id, product, addInfo.Count, HttpContext.User.Identity.IsAuthenticated);            
            return RedirectToAction("ProductDetails", "Product", new { Id = addInfo.ProductId });
        }
    }
}
