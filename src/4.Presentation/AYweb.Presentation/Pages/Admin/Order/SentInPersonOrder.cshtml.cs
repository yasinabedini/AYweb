using AYweb.Application.Models.Order.Commands.SendOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Order
{
    public class SentInPersonOrderModel : PageModel
    {
        private readonly ISender _sender;

        public SentInPersonOrderModel(ISender sender)
        {
            _sender = sender;
        }

        public IActionResult OnGet(long id)
        {
            _sender.Send(new SendOrderCommand { OrderId = id, TrackingCode = "" });

            return RedirectToPage("Index");
        }
    }
}
