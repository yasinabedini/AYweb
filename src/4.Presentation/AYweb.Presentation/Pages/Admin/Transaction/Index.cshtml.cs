using AIPFramework.Queries;
using AYweb.Application.Models.Transaction.Queries.Common;
using AYweb.Application.Models.Transaction.Queries.GetTransactions;
using MediatR;
using AYweb.Presentation.Atteribute.PermissionChacker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Transaction
{
    [PermissionChecker(61)]
    public class IndexModel : PageModel
    {
        private readonly ISender _sender;

        public PagedData<TransactionResult> Transactions { get; set; }

        public IndexModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet()
        {
            Transactions = _sender.Send(new GetTransactionsQuery()).Result;
        }
    }
}
