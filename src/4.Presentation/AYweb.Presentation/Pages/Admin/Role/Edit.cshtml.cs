using AYweb.Application.Models.Permission.Queries.GetPermissions;
using AYweb.Application.Models.Role.Commands.AddPermissionToRole;
using AYweb.Application.Models.Role.Commands.DeleteRolePermissions;
using AYweb.Application.Models.Role.Commands.UpdateRole;
using AYweb.Application.Models.Role.Queries.GetRole;
using AYweb.Application.Models.Role.Queries.GetRolePermissions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pipelines.Sockets.Unofficial.Arenas;

namespace AYweb.Presentation.Pages.Admin.Role
{
    public class EditModel : PageModel
    {
        private readonly ISender _sender;

        [BindProperty]
        public UpdateRoleCommand Role { get; set; }

        public EditModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(long id)
        {
            ViewData["permissions"] = _sender.Send(new GetPermissionsQuery()).Result;
            ViewData["rolePermissions"] = _sender.Send(new GetRolePermissionsQuery { Id = id }).Result;

            var roleModel = _sender.Send(new GetRoleQuery { Id = id }).Result;

            Role = new UpdateRoleCommand { Title = roleModel.Title, Id = roleModel.Id };
        }

        public IActionResult OnPost(List<int> permissions)
        {
            _sender.Send(Role);

            _sender.Send(new DeleteRolePermissionsCommand { Id = Role.Id });

            foreach (var permissionId in permissions)
            {
                _sender.Send(new AddPermissionToRoleCommand { RoleId = Role.Id, PermissionId = permissionId });
            }

            return RedirectToPage("Index");
        }
    }
}
