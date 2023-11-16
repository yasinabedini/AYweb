using AYweb.Core.DTOs;
using AYweb.Dal.Entities.Products;
using Microsoft.AspNetCore.Http;

namespace AYweb.Core.Services.Interfaces;

public interface IProductService
{
    void AddProduct(Product product, IFormFile productImageUp);
    ShowProductForAdminViewModel GetProductsForAdmin(int pageId, string nameFilter);
}