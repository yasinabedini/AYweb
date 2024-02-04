using AYweb.Application.Models.Blog.Commands.AddBlogComment;
using AYweb.Application.Models.Blog.Queries.GetBlog;
using AYweb.Application.Models.Blog.Queries.GetBlogComments;
using AYweb.Application.Models.Blog.Queries.GetBlogGroups;
using AYweb.Application.Models.Blog.Queries.GetBlogs;
using AYweb.Application.Models.Blog.Queries.GetBlogsComments;
using AYweb.Application.Models.Blog.Queries.GetTags;
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

            var newsList = _sender.Send(new GetBlogsQuery { PageSize = take, PageNumber = pageId,search= search }).Result;

            ViewBag.pageId = pageId;

            if (pageId > 1)
            {
                ViewBag.lastPage = pageId - 1;
            }
            else
            {
                ViewBag.lastPage = 1;
            }

            if (pageId == newsList.calculatePageCount() || pageId > newsList.calculatePageCount())
            {
                ViewBag.nextPage = pageId;
            }
            else
            {
                ViewBag.nextPage = pageId + 1;
            }

            ViewBag.take = take;

            ViewData["tags"] = _sender.Send(new GetTagsQuery()).Result;
            ViewData["PopularNews"] = newsList.QueryResult;
            ViewData["NewsGroups"] = _sender.Send(new GetBlogGroupsQuery()).Result;
            ViewData["LastNews"] = newsList.QueryResult;
            ViewData["LastComment"] = _sender.Send(new GetBlogsCommentsQuery()).Result;

            return View(newsList);
        }

        public IActionResult BlogDetails(int id)
        {
            var news = _sender.Send(new GetBlogQuery { Id = id });

            var newsList = _sender.Send(new GetBlogsQuery { PageSize = 8, PageNumber = 1,search=""}).Result;//test

            if (news == null)
            {
                return NotFound();
            }

            ViewData["tags"] = _sender.Send(new GetTagsQuery()).Result;
            ViewData["PopularNews"] = newsList.QueryResult;
            ViewData["NewsGroups"] = _sender.Send(new GetBlogGroupsQuery()).Result;
            ViewData["LastNews"] = newsList.QueryResult;
            ViewData["LastComment"] = _sender.Send(new GetBlogsCommentsQuery()).Result;

            return View(news.Result);
        }

        [HttpPost]
        public IActionResult AddComment(AddBlogCommentCommand commentCommand)
        {
            var req = Request;
            _sender.Send(commentCommand);

            return RedirectToAction("BlogDetails", new { id = commentCommand.BlogId });
        }
    }
}
