using AYweb.Application.Models.User.Commands.ApprovePhoneNumber;
using AYweb.Presentation.Atteribute.PermissionChacker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.User
{
    [PermissionChecker(36)]
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
