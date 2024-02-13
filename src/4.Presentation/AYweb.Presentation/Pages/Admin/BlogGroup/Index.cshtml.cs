using AYweb.Application.Models.Blog.Queries.Common;
using AYweb.Application.Models.Blog.Queries.GetBlogGroups;
using AYweb.Application.Models.Role.Queries.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.BlogGroup
{
    public class IndexModel : PageModel
    {
        private readonly ISender _sender;

        public IndexModel(ISender sender)
        {
            _sender = sender;
        }

        public List<BlogGroupResult> BlogGroups { get; set; }

        public void OnGet()
        {
            BlogGroups = _sender.Send(new GetBlogGroupsQuery()).Result;
        }
    }
}
