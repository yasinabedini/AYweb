using AutoMapper.Features;
using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Product.Entities;
using System.ComponentModel;

namespace AYweb.Domain.Models.Product.Repositories
{
    public interface IProductRepository : IRepository<Product.Entities.Product>
    {
        List<Product.Entities.Product> GetListWithRelations();
        Product.Entities.Product GetByIdWithRelations(long id);
        void ChangeDiscountedPercent(long productId, int amount);
        void ChangeImageName(long productId, string imageName);
        void ChangeInventory(long productId, int amount);
        void ChangeMainDescription(long productId, string mainDescription);
        void ChangeName(long productId, string name);
        void ChangeSeoDescription(long productId, string seoDescription);
        void ChangeShortDescription(long productId, string shortDescription);
        void DecreaseInventory(long productId, int amount);
        void EnableIsSpecial(long productId);
        void DisableIsSpecial(long productId);
        void IncreaseInventory(long productId, int amount);

        List<Feature> GetProductFeatures(long productId);
        void DeleteProductFeatures(long productId);
        
    }
}
