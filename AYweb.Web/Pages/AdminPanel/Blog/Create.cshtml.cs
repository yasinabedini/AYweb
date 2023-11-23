using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Entities.News;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Web.Pages.AdminPanel.Blog
{
    public class CreateModel : PageModel
    {
        private readonly IBlogService _service;

        public CreateModel(IBlogService service)
        {
            _service = service;
        }

        [BindProperty]
        public Dal.Entities.News.News News { get; set; }

        public void OnGet()
        {
            ViewData["newsGroups"] = _service.GetAllNewsGroup();
        }

        public IActionResult OnPost(IFormFile blogPicture, List<IFormFile> pictures, List<int> groups)
        {
            if (!ModelState.IsValid) { return Page(); }

            _service.CreateBlog(News, blogPicture);


            _service.AddGroupToNews(News.Id, groups);
            _service.AddPictureToNewsGallery(News.Id, pictures);
            return Page();
        }
    }
}
