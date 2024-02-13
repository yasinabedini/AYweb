using AYweb.Application.Models.Blog.Commands.UpdateBlogGroup;
using AYweb.Application.Models.Blog.Queries.GetBlogGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.BlogGroup
{
    public class EditModel : PageModel
    {
        private readonly ISender _sender;

        [BindProperty]
        public UpdateBlogGroupCommand BlogGroup { get; set; }

        public EditModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(long id)
        {
            var groupModel = _sender.Send(new GetBlogGroupQuery { Id = id }).Result;
            BlogGroup = new UpdateBlogGroupCommand { Title = groupModel.Title, Id = groupModel.Id };
        }

        public IActionResult OnPost()
        {
            _sender.Send(BlogGroup);

            return RedirectToPage("Index");
        }
    }
}
