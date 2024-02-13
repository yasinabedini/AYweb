using AYweb.Application.Models.Product.Commands.AddFeature;
using AYweb.Application.Models.Product.Commands.DeleteProductFeatures;
using AYweb.Application.Models.Product.Commands.UpdateProduct;
using AYweb.Application.Models.Product.Queries.GetProduct;
using AYweb.Application.Models.Product.Queries.GetProductFeatures;
using AYweb.Presentation.Atteribute.PermissionChacker;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Product
{
    [PermissionChecker(15)]
    public class EditModel : PageModel
    {

        private readonly ISender _sender;

        [BindProperty]
        public UpdateProductCommand Product { get; set; }

        public EditModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(long id)
        {
            ViewData["productFeature"] = _sender.Send(new GetProductFeaturesQuery { Id = id}).Result;
        
            var productModel = _sender.Send(new GetProductQuery { Id = id }).Result;

            Product = new UpdateProductCommand
            {                
                Id = productModel.Id,
                Name = productModel.Name,
                MainDescription = productModel.MainDescription,
                ShortDescription = productModel.ShortDescription,
                SeoDescription = productModel.SeoDescription,
                Inventory = productModel.Inventory,
                DiscountedPercent = productModel.DiscountedPercent,
                IsSpecial = productModel.IsSpecial,
                Price = productModel.Price,                
            };
        }

        public IActionResult OnPost(IFormFile? productPictureUp, List<AddFeatureCommand> featureList)
        {
            if (productPictureUp is not null) Product.Image = productPictureUp;

            _sender.Send(Product);

            _sender.Send(new DeleteProductFeaturesCommand { Id = Product.Id });

            foreach (var feature in featureList.Where(t => !string.IsNullOrEmpty(t.Value) && !string.IsNullOrEmpty(t.Title)))
            {
                _sender.Send(new AddFeatureCommand { ProductId = Product.Id, Title = feature.Title, Value = feature.Value });
            }

            return RedirectToPage("Index");
        }
    }
}
