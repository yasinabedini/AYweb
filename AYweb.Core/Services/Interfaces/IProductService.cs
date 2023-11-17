﻿using AYweb.Core.DTOs;
using AYweb.Dal.Entities.Products;
using Microsoft.AspNetCore.Http;

namespace AYweb.Core.Services.Interfaces;

public interface IProductService
{
    #region Product
    void AddProduct(Product product, IFormFile productImageUp);
    ShowProductForAdminViewModel GetProductsForAdmin(int pageId, string nameFilter);
    Tuple<List<ShowProductViewModel>, int> GetProducts(int pageId = 1, string filter = "", string orderBy = "", bool orderByCreateDate = true, int take = 12);
    #endregion

    #region Feature
    void AddFeatureToProduct(int productId, List<Feature> features);
    #endregion
}