using AYweb.Application.Models.Role.Queries.GetUserRoles;
using AYweb.Application.Models.User.Queries.Common;
using AYweb.Application.Models.User.Queries.GetUser;
using AYweb.Application.Models.User.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.User
{
    public class DetailsModel : PageModel
    {
        private readonly ISender _sender;

        public DetailsModel(ISender sender)
        {
            _sender = sender;
        }

        public UserResult User { get; set; }

        public IActionResult OnGet(long id)
        {
            User = _sender.Send(new GetUserQuery() { Id = id }).Result;
            ViewData["roles"] = _sender.Send(new GetUserRolesQuery { UserId = id }).Result;
            return Page();
        }
    }
}
