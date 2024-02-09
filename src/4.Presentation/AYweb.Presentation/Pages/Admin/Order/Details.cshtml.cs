using AYweb.Application.Models.Order.Queries.Common;
using AYweb.Application.Models.Order.Queries.GetOrder;
using AYweb.Application.Models.Transaction.Queries.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Order
{
    public class DetailsModel : PageModel
    {
        private readonly ISender _sender;

        public OrderResult Order { get; set; }
        public DetailsModel(ISender sender)
        {
            _sender = sender;
        }

        public IActionResult OnGet(long id)
        {
            Order  = _sender.Send(new GetOrderQuery { Id = id }).Result;
            return Page();
        }
    }
}
