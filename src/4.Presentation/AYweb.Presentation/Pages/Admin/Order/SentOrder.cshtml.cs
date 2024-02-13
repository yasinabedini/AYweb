using AYweb.Application.Models.Order.Commands.SendOrder;
using AYweb.Domain.Models.Order.Repositories;
using AYweb.Presentation.Atteribute.PermissionChacker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Order
{
    [PermissionChecker(54)]
    public class SentOrderModel : PageModel
    {
        private readonly ISender _sender;

        [BindProperty]
        public SendOrderCommand Order { get; set; }

        public SentOrderModel(ISender sender)
        {
            _sender = sender;
        }
        

        public void OnGet(long id)
        {
            
        }

        public IActionResult OnPost()
        {                        
            _sender.Send(Order);
            return RedirectToPage("OrderReadyToShip");
        }
    }
}
