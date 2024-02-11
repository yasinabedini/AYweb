using AYweb.Application.Models.Blog.Commands.AddGroupToBlog;
using AYweb.Application.Models.Blog.Commands.DeleteBlogGroup;
using AYweb.Application.Models.Blog.Commands.DeleteBlogsGroups;
using AYweb.Application.Models.Blog.Commands.UpdateBlog;
using AYweb.Application.Models.Blog.Queries.GetBlog;
using AYweb.Application.Models.Blog.Queries.GetBlogGroups;
using AYweb.Application.Models.Blog.Queries.GetBlogsGroups;
using AYweb.Domain.Models.Blog.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AYweb.Presentation.Pages.Admin.Blog
{
    public class EditModel : PageModel
    {
        private readonly ISender _sender;

        [BindProperty]
        public UpdateBlogCommand Blog { get; set; }

        public EditModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(long id)
        {
            var blogModel = _sender.Send(new GetBlogQuery { Id = id }).Result;
            Blog = new UpdateBlogCommand
            {
                Introduction = blogModel.Introduction,
                Text = blogModel.Text,
                Summary = blogModel.Summary,
                Tags = blogModel.Tags,
                Title = blogModel.Title,
            };

            ViewData["blogGroups"] = _sender.Send(new GetBlogGroupsQuery()).Result;
            ViewData["blogBlogGroups"] = _sender.Send(new GetBlogsGroupsQuery { Id = id }).Result;

        }

        public IActionResult OnPost(List<int> groups)
        {
            if (!ModelState.IsValid)
            {
                ViewData["blogGroups"] = _sender.Send(new GetBlogGroupsQuery()).Result;
                ViewData["blogBlogGroups"] = _sender.Send(new GetBlogsGroupsQuery { Id = Blog.Id }).Result;
                return Page();
            }

            _sender.Send(Blog);

            _sender.Send(new DeleteBlogsGroupsCommand { BlogId = Blog.Id });

            foreach (var groupId in groups)
            {
                _sender.Send(new AddGroupToBlogCommand() { BlogId = Blog.Id, GroupId = groupId });
            }

            return RedirectToPage("Index");
        }
    }
}
