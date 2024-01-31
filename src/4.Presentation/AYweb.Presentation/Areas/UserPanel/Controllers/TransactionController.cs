using AYweb.Application.Models.Transaction.Queries.GetCurrentUserTransactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class TransactionController : Controller
    {
        private readonly ISender _sender;

        public TransactionController(ISender sender)
        {
            _sender = sender;
        }

        [Route("Transactions")]
        public IActionResult Index()
        {
            return View(_sender.Send(new GetCurrentUserTransactionsQuery()).Result);
        }
    }
}
