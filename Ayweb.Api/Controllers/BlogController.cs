using AYweb.Application.Models.Blog.Queries.GetBlogs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ayweb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ISender _sender;

        public BlogController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public IActionResult GetAll(int pageId = 1)
        {
            return Ok(_sender.Send(new GetBlogsQuery { PageNumber = pageId, PageSize = 12 }).Result.QueryResult);
        }
    }
}
