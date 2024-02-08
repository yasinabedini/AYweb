using AYweb.Application.Models.User.Commands.ApprovePhoneNumber;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.User
{
    public class ApprovePhoneNumberModel : PageModel
    {
        private readonly ISender _sender;

        public ApprovePhoneNumberModel(ISender sender)
        {
            _sender = sender;
        }

        public IActionResult OnGet(string phoneNumber)
        {
            _sender.Send(new ApprovePhoneNumberCommand { PhoneNumber = phoneNumber });

            return RedirectToPage("Index");
        }
    }
}
