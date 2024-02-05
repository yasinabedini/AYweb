using AYweb.Application.Models.Product.Commands.AddFeature;
using AYweb.Application.Models.Product.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.Product
{
    public class CreateModel : PageModel
    {
        private readonly ISender _sender;

        public CreateModel(ISender sender)
        {
            _sender = sender;
        }

        [BindProperty]
        public CreateProductCommand Product { get; set; }

        public void OnGet()
        {
        }

        public void OnPost(IFormFile productPictureUp, List<AddFeatureCommand> featureList)
        {
            Product.Image = productPictureUp;
            long productId = _sender.Send(Product).Result;

            foreach (var feature in featureList.Where(t => !string.IsNullOrEmpty(t.Value)&&!string.IsNullOrEmpty(t.Title)))
            {
                _sender.Send(new AddFeatureCommand { ProductId = productId, Title = feature.Title, Value = feature.Value });
            }

        }
    }
}
