using AYweb.Application.Models.Product.Queries.Common;
using AYweb.Application.Models.Product.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Product
{
    public class DetailsModel : PageModel
    {
        private readonly ISender _sender;

        public ProductResult  Product { get; set; }

        public DetailsModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(long id)
        {
            Product = _sender.Send(new GetProductQuery() { Id = id }).Result;
        }
    }
}
