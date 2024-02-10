using AYweb.Application.Models.Role.Queries.Common;
using AYweb.Application.Models.Role.Queries.GetRole;
using AYweb.Application.Models.Role.Queries.GetRolePermissions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Role
{
    public class DetailsModel : PageModel
    {
        private readonly ISender _sender;

        public RoleResult Role { get; set; }

        public DetailsModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(long id)
        {
            Role = _sender.Send(new GetRoleQuery { Id = id }).Result;
            ViewData["permissions"] = _sender.Send(new GetRolePermissionsQuery { Id = id }).Result;
        }
    }
}
