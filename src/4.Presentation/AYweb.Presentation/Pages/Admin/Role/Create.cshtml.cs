using AYweb.Application.Models.Permission.Queries.GetPermissions;
using AYweb.Application.Models.Role.Commands.AddPermissionToRole;
using AYweb.Application.Models.Role.Commands.CreateRole;
using AYweb.Application.Models.Role.Queries.GetRolePermissions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace AYweb.Presentation.Pages.Admin.Role
{
    public class CreateModel : PageModel
    {
        private readonly ISender _sender;

        public CreateModel(ISender sender)
        {
            _sender = sender;            
        }

        [BindProperty]
        public CreateRoleCommand Role { get; set; }
        public void OnGet()
        {
            ViewData["permissions"] = _sender.Send(new GetPermissionsQuery()).Result;
        }

        public IActionResult OnPost(List<int> permissions)
        {
            var roleId = _sender.Send(Role).Result;

            foreach (var permissionId in permissions)
            {
                _sender.Send(new AddPermissionToRoleCommand { RoleId = roleId, PermissionId = permissionId });
            }

            return RedirectToPage("Index");
        }
    }
}
