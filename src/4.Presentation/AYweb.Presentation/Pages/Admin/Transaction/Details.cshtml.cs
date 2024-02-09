using AYweb.Application.Models.Transaction.Queries.Common;
using AYweb.Application.Models.Transaction.Queries.GetTransaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Transaction
{
    public class DetailsModel : PageModel
    {
        private readonly ISender _sender;

        public TransactionResult Transaction { get; set; }

        public DetailsModel(ISender sender)
        {
            _sender = sender;
        }

        public IActionResult OnGet(long id)
        {
            Transaction = _sender.Send(new GetTransactionQuery { Id = id }).Result;

            return Page();
        }
    }
}
