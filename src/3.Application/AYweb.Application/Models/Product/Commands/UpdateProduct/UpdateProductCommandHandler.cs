using AIPFramework.Commands;
using AYweb.Application.Generators;
using AYweb.Application.Tools;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _repository.GetById(request.Id);

            product.ChangeName(request.Name);
            product.ChangeShortDescription(request.ShortDescription);
            product.ChangeMainDescription(request.MainDescription);
            product.ChangeSeoDescription(request.SeoDescription);
            product.ChangePrice(request.Price);
            product.ChangeDiscountedPercent(request.DiscountedPercent);
            product.ChangeInventory(request.Inventory);
            product.ChangeIsSpecial(request.IsSpecial);            

            if (request.Image is not null)
            {
                FileTools.DeleteFile(Path.Combine(Directory.GetCurrentDirectory(), $"/img/shop-image/{product.ImageName}"));

                FileTools file = new FileTools();
                string imageName = Generator.CreateUniqueText(10) + Path.GetExtension(request.Image.FileName);
                file.SaveImage(request.Image, imageName, "shop-image", false);
                product.ChangeImageName(imageName);
            }
                

            _repository.Update(product);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
