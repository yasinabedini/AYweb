using AYweb.Application.Models.Blog.Commands.AddGroupToBlog;
using AYweb.Application.Models.Blog.Commands.CreateBlog;
using AYweb.Application.Models.Blog.Queries.GetBlogGroups;
using AYweb.Domain.Models.Service.Entities;
using AYweb.Presentation.Atteribute.PermissionChacker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Blog
{
    [PermissionChecker(21)]
    public class CreateModel : PageModel
    {
        private readonly ISender _sender;

        [BindProperty]
        public CreateBlogCommand Blog { get; set; }

        public CreateModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet()
        {
            ViewData["blogGroups"] = _sender.Send(new GetBlogGroupsQuery()).Result;
        }

        public IActionResult OnPost(IFormFile blogPicture, List<IFormFile> pictures, List<int> groups)
        {
            Blog.Pictures = pictures;
            Blog.Image = blogPicture;

            long blogId = _sender.Send(Blog).Result;

            foreach (var groupId in groups)
            {
                _sender.Send(new AddGroupToBlogCommand() { BlogId = blogId, GroupId = groupId });
            }

            return RedirectToPage("Index");
        }
    }
}
