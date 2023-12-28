using System.Drawing.Text;
using AYweb.Core.DTOs;
using AYweb.Core.Generators;
using AYweb.Core.Security;
using AYweb.Core.Services.Interfaces;
using AYweb.Core.Tools;
using AYweb.Dal.Context;
using AYweb.Dal.Entities.Plan;
using AYweb.Dal.Entities.Product;
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
        string imageName = Generator.CreateUniqueText(20) + Path.GetExtension(productImageUp.FileName);
        product.PictureName = imageName;

        FileTools fileTools = new FileTools();
        fileTools.SaveImage(productImageUp, imageName, "shop-image", true);

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
    public Tuple<List<ShowProductViewModel>, int> GetProducts(int pageId = 1, string filter = "", string orderBy = "", bool orderByCreateDate = true, int take = 12)
    {
        var products = _context.Products.Include(t => t.OrderLines).ToList();

        if (!string.IsNullOrEmpty(filter))
        {
            products = products.Where(t => t.Name.Contains(filter)).ToList();
        }


        if (!string.IsNullOrEmpty(orderBy))
        {
            switch (orderBy)
            {

            }
        }

        if (orderByCreateDate)
        {
            products = products.OrderByDescending(t => t.CreateDate).ToList();
        }


        int skip = (pageId - 1) * take;

        var endProductList = products.Select(t => new ShowProductViewModel
        {
            Id = t.Id,
            Name = t.Name,
            PictureName = t.PictureName,
            Price = t.Price,
            CreateDate = t.CreateDate,
            DiscountedPrice = t.DiscountedPrice,
            IsSpecial = t.IsSpecial

        }).Skip(skip).Take(take).ToList();

        int pageCount = products.Count() / take;
        if (pageCount <= 1)
        {
            pageCount = 1;
            goto endProductList;
        }
        if ((pageCount % take) != 0)
        {
            pageCount++;
        }

    endProductList:
        return Tuple.Create(endProductList, pageCount);
    }
    public Product GetProductById(int id)
    {
        return _context.Products.Include(t => t.Features).Include(t => t.Comments).Include(t => t.OrderLines).First(t => t.Id == id);
    }
    public void AddFeatureToProduct(int productId, List<Feature> features)
    {
        foreach (var feature in features)
        {
            _context.Features.Add(new Feature()
            {
                Title = feature.Title,
                Value = feature.Value,
                ProductId = productId
            });
            _context.SaveChanges();
        }

    }

    public void UpdateProduct(Product product)
    {
        _context.Update(product);
        _context.SaveChanges();
    }
}