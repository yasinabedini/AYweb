using AYweb.Application.Models.Transaction.Commands.ApproveTransaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Transaction
{
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
