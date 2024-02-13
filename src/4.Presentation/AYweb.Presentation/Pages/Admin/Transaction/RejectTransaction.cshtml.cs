using AYweb.Application.Models.Transaction.Commands.RejectTransaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AYweb.Presentation.Atteribute.PermissionChacker;

namespace AYweb.Presentation.Pages.Admin.Transaction
{
    [PermissionChecker(65)]
    public class RejectTransactionModel : PageModel
    {
        private readonly ISender _sender;

        public RejectTransactionModel(ISender sender)
        {
            _sender = sender;
        }

        public IActionResult OnGet(long id)
        {
            _sender.Send(new RejectTransactionCommand { Id = id });

            return RedirectToPage("Index");
        }
    }
}
