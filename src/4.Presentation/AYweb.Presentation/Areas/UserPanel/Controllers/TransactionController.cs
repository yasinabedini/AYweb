using AYweb.Application.Models.Transaction.Commands.RequestForPayTransaction;
using AYweb.Application.Models.Transaction.Queries.GetCurrentUserTransactions;
using AYweb.Application.Models.Transaction.Queries.GetTransaction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Areas.UserPanel.Controllers
{
    [Area("userpanel")]
    [Authorize]
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

        [Route("Transaction/{id}")]
        public IActionResult TransactionDetails(int id)
        {
            return View(_sender.Send(new GetTransactionQuery { Id = id}).Result);
        }


        [Route("CheckOut/{id}")]
        public IActionResult CheckOut(int id)
        {
            ViewData["transaction"] = _sender.Send(new GetTransactionQuery { Id = id }).Result;

            return View();
        }

        [Route("CheckOut/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckOut(RequestForPayTransactionCommand transaction,IFormFile? screenshot)
        {
            if (screenshot is not null)
            {
                transaction.Image = screenshot;
            }

            _sender.Send(transaction);

            return RedirectToAction("Index");
        }
    }
}
