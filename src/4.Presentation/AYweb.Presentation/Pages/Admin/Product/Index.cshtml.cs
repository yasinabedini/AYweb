using AIPFramework.Queries;
using AYweb.Application.Models.Product.Queries.Common;
using AYweb.Application.Models.Product.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Product
{
    public class IndexModel : PageModel
    {
        private readonly ISender _sender;

        public PagedData<ProductResult> Products { get; set; }

        public IndexModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(string filter="",int page = 1)
        {
            Products = _sender.Send(new GetProductsQuery() { Search = filter,PageNumber = page,PageSize = 50 }).Result;
        }
    }
}
