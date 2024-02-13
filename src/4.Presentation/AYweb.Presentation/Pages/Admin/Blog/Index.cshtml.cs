using AIPFramework.Queries;
using AYweb.Application.Models.Blog.Queries.Common;
using AYweb.Application.Models.Blog.Queries.GetBlogs;
using AYweb.Presentation.Atteribute.PermissionChacker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace AYweb.Presentation.Pages.Admin.Blog
{
    [PermissionChecker(23)]
    public class IndexModel : PageModel
    {
        private readonly ISender _sender;

        public PagedData<BlogResult> Blogs { get; set; }

        public IndexModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(string search = "",int page = 1)
        {
            Blogs = _sender.Send(new GetBlogsQuery() {search = search,PageNumber = page,PageSize = 50}).Result;
        }
    }
}
