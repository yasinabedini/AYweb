using AIPFramework.Queries;
using AYweb.Application.Models.Order.Queries.Common;
using AYweb.Application.Models.Order.Queries.GetOrders;
using AYweb.Presentation.Atteribute.PermissionChacker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Order
{
    [PermissionChecker(51)]
    public class IndexModel : PageModel
    {
        private readonly ISender _sender;

        public PagedData<OrderResult> Orders { get; set; }

        public IndexModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet()
        {
            Orders = _sender.Send(new GetOrdersQuery()).Result;
        }
    }
}
