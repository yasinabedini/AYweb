using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Entities.Product;
using AYweb.Dal.Entities.Service;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _service;

        public BlogController(IBlogService service)
        {
            _service = service;
        }

        public IActionResult Index(int pageId = 1, string search = "")
        {
            int take = 8;

            var newsList = _service.GetAllNews(pageId, search, take);

            ViewBag.pageId = pageId;

            if (pageId > 1)
            {
                ViewBag.lastPage = pageId - 1;
            }
            else
            {
                ViewBag.lastPage = 1;
            }

            if (pageId == newsList.Item2 || pageId > newsList.Item2)
            {
                ViewBag.nextPage = pageId;
            }
            else
            {
                ViewBag.nextPage = pageId + 1;
            }

            ViewBag.take = take;

            ViewData["tags"] = _service.GetAllTags();
            ViewData["PopularNews"] = _service.GetPopularNews().Take(3).ToList();
            ViewData["NewsGroups"] = _service.GetAllNewsGroup();
            ViewData["LastNews"] = _service.GetAllNews().Item1.Take(6).ToList();
            ViewData["LastComment"] = _service.GetLastComment();

            return View(newsList);
        }

        public IActionResult BlogDetails(int id)
        {
            var news = _service.GetNewsById(id);
            if (news==null)
            {
                return BadRequest();
            }

            ViewData["tags"] = _service.GetAllTags();
            ViewData["PopularNews"] = _service.GetPopularNews().Take(3).ToList();
            ViewData["NewsGroups"] = _service.GetAllNewsGroup();
            ViewData["LastNews"] = _service.GetAllNews().Item1.Take(6).ToList();
            ViewData["LastComment"] = _service.GetLastComment();

            return View(news);
        }

        //TODO I Should Complete Add Comment For News
    }
}
