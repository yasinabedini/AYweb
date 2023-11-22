using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
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
    }
}
