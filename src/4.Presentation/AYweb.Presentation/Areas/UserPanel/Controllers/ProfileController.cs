using AYweb.Application.Models.Plan.Commands.AddPlanToUser;
using AYweb.Application.Models.Plan.Queries.GetPlan;
using AYweb.Application.Models.Transaction.Commands.AddTransactionLine;
using AYweb.Application.Models.Transaction.Commands.CreateTransaction;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Areas.UserPanel.Controllers
{
    [Area("userpanel")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ISender _sender;

        public ProfileController(ISender sender)
        {
            _sender = sender;
        }

        [Route("Profile")]
        public IActionResult Profile()
        {
            return View(_sender.Send(new GetAuthenticatedUserQuery()).Result);
        }

        [Route("BuyPlan")]
        public IActionResult BuyPlan(long id)
        {
            var user = _sender.Send(new GetAuthenticatedUserQuery()).Result;

            var plan = _sender.Send(new GetPlanQuery() { Id = id }).Result;

            long transactionId = _sender.Send(new CreateTransactionCommand() { UserId = user.Id, Price = plan.Price, Type = Domain.Models.Transaction.Enums._TransactionType.PaymentPlan, Description = $"Buy {plan.Title} Plan By User By This PhoneNumber: {user.PhoneNumber} " }).Result;
            _sender.Send(new AddTransactionLineCommand { TransactionId = transactionId, Amount = 1, Commodity = plan.Title, UnitPrice = plan.Price });

            _sender.Send(new AddPlanToUserCommand { PlanId = plan.Id, UserId = user.Id, TransactionId = transactionId });

            return RedirectToAction("CheckOut", "Transaction", new { area = "UserPanel", id = transactionId });
        }
    }
}
