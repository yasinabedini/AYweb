using AYweb.Application.Models.Product.Commands.CreateProduct;
using AYweb.Application.Models.Product.Queries.GetComments;
using AYweb.Application.Models.Product.Queries.GetProduct;
using AYweb.Application.Models.Product.Queries.GetProducts;
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

        [HttpGet]
        public IActionResult GetAll(int pageId = 1)
        {
            return Ok(_sender.Send(new GetProductsQuery()).Result.QueryResult);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_sender.Send(new GetProductQuery() { Id = id }).Result);
        }

        [HttpGet("GetComments")]
        public IActionResult GetComments(int pageId = 1)
        {
            return Ok(_sender.Send(new GetCommentQuery() { PageNumber = pageId, PageSize = 40 }).Result.QueryResult);
        }
    }
}
