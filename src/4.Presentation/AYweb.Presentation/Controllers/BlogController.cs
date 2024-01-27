using AYweb.Application.Models.Blog.Queries.GetBlog;
using AYweb.Application.Models.Blog.Queries.GetBlogs;
using AYweb.Domain.Models.Blog.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Controllers
{
    public class BlogController : Controller
    {
        private readonly ISender _sender;

        public BlogController(ISender sender)
        {
            _sender = sender;
        }

        public IActionResult Index(int pageId = 1, string search = "")
        {
            int take = 8;

            var newsList = _sender.Send(new GetBlogsQuery { PageSize = take, PageNumber = pageId }).Result;

            ViewBag.pageId = pageId;

            if (pageId > 1)
            {
                ViewBag.lastPage = pageId - 1;
            }
            else
            {
                ViewBag.lastPage = 1;
            }

            if (pageId == newsList.pageCount || pageId > newsList.pageCount)
            {
                ViewBag.nextPage = pageId;
            }
            else
            {
                ViewBag.nextPage = pageId + 1;
            }

            ViewBag.take = take;

            ViewData["tags"] = new List<string> { "برنامه نویسی", "تکنولوژی" };
            ViewData["PopularNews"] = newsList.QueryResult.Take(3);
            ViewData["NewsGroups"] = new List<BlogGroup> { BlogGroup.Create("برنامه نویسی"), BlogGroup.Create("سی شارپ") };
            ViewData["LastNews"] = newsList.QueryResult.Take(6);
            ViewData["LastComment"] = new List<BlogComment> { BlogComment.Create("بسیار عالی", 1, "yasinabedini", "09106966244") };

            return View(newsList);
        }

        public IActionResult BlogDetails(int id)
        {
            var news = _sender.Send(new GetBlogQuery { Id = id });

            var newsList = _sender.Send(new GetBlogsQuery { PageSize = 8, PageNumber = 1 }).Result;//test
            if (news == null)
            {
                return BadRequest();
            }

            ViewData["tags"] = new List<string> { "برنامه نویسی", "تکنولوژی" };
            ViewData["PopularNews"] = newsList.QueryResult.Take(3);
            ViewData["NewsGroups"] = new List<BlogGroup> { BlogGroup.Create("برنامه نویسی"), BlogGroup.Create("سی شارپ") };
            ViewData["LastNews"] = newsList.QueryResult.Take(6);
            ViewData["LastComment"] = new List<BlogComment> { BlogComment.Create("بسیار عالی", 1, "yasinabedini", "09106966244") };

            return View(news.Result);
        }

        //TODO I Should Complete Add Comment For News
    }
}
