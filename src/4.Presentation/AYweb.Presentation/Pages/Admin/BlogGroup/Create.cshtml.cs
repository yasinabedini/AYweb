using AYweb.Application.Models.Blog.Commands.AddBlogGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.BlogGroup
{
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
