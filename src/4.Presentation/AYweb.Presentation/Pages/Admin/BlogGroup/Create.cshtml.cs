using AYweb.Application.Models.Blog.Commands.AddBlogGroup;
using AYweb.Presentation.Atteribute.PermissionChacker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.BlogGroup
{
    [PermissionChecker(27)]
    public class CreateModel : PageModel
    {
        private readonly ISender _sender;

       [BindProperty]
        public AddBlogGroupCommand BlogGroup { get; set; }

        public CreateModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _sender.Send(BlogGroup);

            return RedirectToPage("Index");
        }
    }
}
