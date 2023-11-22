using AYweb.Core.Security;
using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Entities.Product;
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
    public Dal.Entities.Product.Product Product { get; set; }


    public void OnGet()
    {
    }

    public IActionResult OnPost(IFormFile? productPictureUp, List<Feature> featureList)
    {
        if (!ModelState.IsValid) return Page();

        _service.AddProduct(Product, productPictureUp);
        var features = featureList.Where(t => !string.IsNullOrEmpty(t.Title) && !string.IsNullOrEmpty(t.Value)).ToList();
        _service.AddFeatureToProduct(Product.Id, features);

        return RedirectToPage("Index");
    }
}
