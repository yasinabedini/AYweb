using AYweb.Application.Models.Order.Commands.AddProductToOrder;
using AYweb.Application.Models.Product.Queries.GetProduct;
using AYweb.Application.Models.Product.Queries.GetProducts;
using AYweb.Domain.Models.Service.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISender _sender;

        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        public IActionResult Index(int pageId = 1, string search = "")
        {
            int take = 12;
            var products = _sender.Send(new GetProductsQuery { PageNumber = pageId, PageSize = take,Search = search });
            
            if (pageId > 1)
            {
                ViewBag.lastPage = pageId - 1;
            }
            else
            {
                ViewBag.lastPage = 1;
            }

            if (pageId == products.Result.pageCount || pageId > products.Result.pageCount)
            {
                ViewBag.nextPage = pageId;
            }
            else
            {
                ViewBag.nextPage = pageId + 1;
            }            

            return View(products.Result);
        }

        [HttpGet]
        [Route("Product/{id}")]
        public IActionResult ProductDetails(int id)
        {
            return View(_sender.Send(new GetProductQuery { Id =id}).Result);
        }


        [HttpPost]
        public IActionResult AddProductToCart(AddProductToOrderCommand addproduct)
        {
            _sender.Send(addproduct);

            return RedirectToAction("ProductDetails", "Product", new { Id = addproduct.ProductId });
        }
    }
}
