using Abp.Extensions;
using AYweb.Application.Models.Role.Queries.GetRoles;
using AYweb.Application.Models.Role.Queries.GetUserRoles;
using AYweb.Application.Models.User.Commands.AddRoleToUser;
using AYweb.Application.Models.User.Commands.DeleteAllUserRoles;
using AYweb.Application.Models.User.Commands.UpdateUser;
using AYweb.Application.Models.User.Queries.GetUser;
using AYweb.Domain.Models.User.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.User
{
    public class EditModel : PageModel
    {
        private readonly ISender _sender;

        [BindProperty]
        public UpdateUserCommand User { get; set; }

        public EditModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(long id)
        {
            ViewData["Roles"] = _sender.Send(new GetRolesQuery()).Result;
            ViewData["userRoles"] = _sender.Send(new GetUserRolesQuery() { UserId = id }).Result;

            var usermodel = _sender.Send(new GetUserQuery { Id = id }).Result;



            User = new UpdateUserCommand
            {
                Id = id,
                FirstName = usermodel.FirstName,
                LastName = usermodel.LastName,
                Email = usermodel.Email
            };
        }

        public IActionResult OnPost (List<long> roleList)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _sender.Send(User);

            _sender.Send(new DeleteAllUserRolesCommand { UserId = User.Id });

            foreach (var roleId in roleList)
            {
                _sender.Send(new AddRoleToUserCommand() { RoleId = roleId, UserId = User.Id });
            }

            return RedirectToPage("Index");
        }
    }
}
