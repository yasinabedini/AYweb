using AYweb.Application.Models.Role.Commands.DeleteRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Role
{
    public class DeleteModel : PageModel
    {
        private readonly ISender _sender;

        public DeleteModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(long id)
        {
            _sender.Send(new DeleteRoleCommand { Id = id });
        }
    }
}
