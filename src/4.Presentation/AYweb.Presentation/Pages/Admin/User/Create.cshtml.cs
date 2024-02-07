using AYweb.Application.Models.Role.Queries.GetRoles;
using AYweb.Application.Models.User.Commands.AddRoleToUser;
using AYweb.Application.Models.User.Commands.CreateUser;
using AYweb.Application.Models.User.Queries.GetUserByPhoneNumber;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.User
{
    public class CreateModel : PageModel
    {
        private readonly ISender _sender;

        [BindProperty]
        public CreateUserCommand User { get; set; }

        public CreateModel(ISender sender)
        {
            _sender = sender;
        }



        public void OnGet()
        {
            ViewData["roles"] = _sender.Send(new GetRolesQuery()).Result;
        }

        public IActionResult OnPost(List<int> roleList)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_sender.Send(new GetUserByPhoneNumberQuery() { PhoneNumber = User.PhoneNumber }).Result is not null)
            {
                ViewData["phoneError"] = true;
                return Page();
            }
            
            long userId = _sender.Send(User).Result;

            foreach (var roleId in roleList)
            {
                _sender.Send(new AddRoleToUserCommand() { RoleId = roleId, UserId = userId });
            }

            return RedirectToPage("Index");
        }
    }
}
