using AYweb.Application.Models.Blog.Commands.DeleteBlog;
using AYweb.Application.Models.Product.Commands.DeleteProduct;
using AYweb.Presentation.Atteribute.PermissionChacker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Blog
{
    [PermissionChecker(25)]
    public class DeleteModel : PageModel
    {
        private readonly ISender _sender;

        public DeleteModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(long id)
        {
            _sender.Send(new DeleteBlogCommand { Id = id });
        }
    }
}
