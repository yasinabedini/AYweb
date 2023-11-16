using AYweb.Core.DTOs;
using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Web.Pages.AdminPanel.Product;

public class IndexModel : PageModel
{

    private readonly IProductService _service;

    public IndexModel(IProductService service)
    {
        _service = service;
    }

    public ShowProductForAdminViewModel ShowProduct { get; set; }

    public void OnGet(int pageId = 1, string nameFilter = "", string groupNameFilter = "")
    {
        ShowProduct = _service.GetProductsForAdmin(pageId, nameFilter);
    }
}
