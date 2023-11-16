using AYweb.Core.Security;
using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AYweb.Web.Pages.AdminPanel.Product;

public class CreateModel : PageModel
{
    private readonly IProductService _service;
    private readonly IUserService _userService;

    public CreateModel(IProductService service, IUserService userService = null)
    {
        _service = service;
        _userService = userService;
    }

    [BindProperty]
    public Dal.Entities.Products.Product Product { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost(IFormFile? productPictureUp, List<int> cars, List<int> groups, List<int> customers, List<int> prices)
    {
        if (!ModelState.IsValid) return Page();

        _service.AddProduct(Product, productPictureUp);

        return RedirectToPage("Index");
    }
}
