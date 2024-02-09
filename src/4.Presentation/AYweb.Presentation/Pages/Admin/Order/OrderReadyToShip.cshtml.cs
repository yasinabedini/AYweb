using AYweb.Application.Models.Order.Queries.Common;
using AYweb.Application.Models.Order.Queries.GetOrderReadyToShip;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Order
{
    public class OrderReadyToShipModel : PageModel
    {
        private readonly ISender _sender;

        public List<ForwardResult>  Forwards { get; set; }

        public OrderReadyToShipModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet()
        {
            Forwards = _sender.Send(new GetOrderReadyToShipQuery()).Result;
        }
    }
}
