using AYweb.Application.Models.Role.Queries.Common;
using AYweb.Application.Models.Role.Queries.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Role
{
    public class IndexModel : PageModel
    {
        private readonly ISender _sender;

        public IndexModel(ISender sender)
        {
            _sender = sender;
        }

        public List<RoleResult> Roles { get; set; }
        public void OnGet()
        {
            Roles = _sender.Send(new GetRolesQuery()).Result;
        }
    }
}
