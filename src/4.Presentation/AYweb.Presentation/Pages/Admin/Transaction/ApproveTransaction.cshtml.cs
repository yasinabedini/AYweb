using AYweb.Application.Models.Transaction.Commands.ApproveTransaction;
using AYweb.Presentation.Atteribute.PermissionChacker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Transaction
{
    [PermissionChecker(64)]
    public class ApproveTransactionModel : PageModel
    {
        private readonly ISender _sender;

        public ApproveTransactionModel(ISender sender)
        {
            _sender = sender;
        }

        public IActionResult OnGet(long id)
        {
            _sender.Send(new ApproveTransactionCommand { Id = id });

            return RedirectToPage("Index");
        }
    }
}
