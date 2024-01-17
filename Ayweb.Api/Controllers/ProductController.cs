using AYweb.Application.Models.Product.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ayweb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public IActionResult Create(CreateProductCommand request)
        {
            var res = _sender.Send(request);
            return Ok(res.IsCompletedSuccessfully);
        }
    }
}
