using System.Drawing.Text;
using AYweb.Core.DTOs;
using AYweb.Core.Generators;
using AYweb.Core.Security;
using AYweb.Core.Services.Interfaces;
using AYweb.Core.Tools;
using AYweb.Dal.Context;
using AYweb.Dal.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace AYweb.Core.Services;

public class ProductService : IProductService
{
    private readonly AYWebDbContext _context;

    public ProductService(AYWebDbContext context)
    {
        _context = context;
    }

    public void AddProduct(Product product, IFormFile productImageUp)
    {

        product.PictureName = "Defaul-Image.jpeg";
        if (productImageUp != null && productImageUp.IsImage())
        {
            string imageName = Generator.CreateUniqueText() + Path.GetExtension(productImageUp.FileName);
            product.PictureName = imageName;

            FileTools fileTools = new FileTools();
            fileTools.SaveImage(productImageUp, imageName, "shop-image", true);
        }

        product.CreateDate = DateTime.Now;
        product.IsActive = true;
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public ShowProductForAdminViewModel GetProductsForAdmin(int pageId, string nameFilter)
    {
        IQueryable<Product> products = _context.Products;

        if (!string.IsNullOrEmpty(nameFilter))
        {
            products = products.Where(t => t.Name.Contains(nameFilter));
        }

        int take = 20;
        int skip = (pageId - 1) * take;

        return new ShowProductForAdminViewModel
        {
            Products = products.Select(t => new ProductViewModel
            {
                Id = t.Id,
                Inventory = t.Inventory,
                Name = t.Name,
                Price = t.Price
            }).ToList(),

            CurrentPage = pageId,

            PageCount = products.Count() / take
        };
    }
}