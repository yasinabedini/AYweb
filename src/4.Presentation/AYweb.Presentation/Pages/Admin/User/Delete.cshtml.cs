using AYweb.Application.Models.User.Commands.DeleteUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.User
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
            _sender.Send(new DeleteUserCommand { Id = id });

        }
    }
}
