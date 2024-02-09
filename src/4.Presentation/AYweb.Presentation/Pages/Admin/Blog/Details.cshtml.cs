using AYweb.Application.Models.Blog.Queries.Common;
using AYweb.Application.Models.Blog.Queries.GetBlog;
using AYweb.Application.Models.Blog.Queries.GetBlogGroups;
using AYweb.Application.Models.Blog.Queries.GetBlogsGroups;
using AYweb.Application.Models.Blog.Queries.GetTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly ISender _sender;

        public DetailsModel(ISender sender)
        {
            _sender = sender;            
        }

        [BindProperty]
        public BlogResult Blog { get; set; }

        public IActionResult OnGet(long id)
        {
            Blog = _sender.Send(new GetBlogQuery { Id = id }).Result;
            ViewData["blogGroups"] = _sender.Send(new GetBlogsGroupsQuery { Id = id }).Result;
            
            return Page();
        }
    }
}
