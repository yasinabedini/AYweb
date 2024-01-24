using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Domain.Models.Product.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Product.Repositories
{
    public class ProductRepository : BaseRepository<Domain.Models.Product.Entities.Product>, IProductRepository, ICommentRepository, IFeatureRepository
    {
        private readonly AyWebDbContext _context;
        public ProductRepository(AyWebDbContext context) : base(context)
        {
            _context = context;
        }

        #region Comment
        public void Add(Comment entity)
        {
            _context.Comments.Add(entity);
        }

      

        public void Update(Comment entity)
        {
            _context.Update(entity);
        }
      
        Comment IRepository<Comment>.GetById(long id)
        {
            return _context.Comments.Find(id);
        }

        List<Comment> IRepository<Comment>.GetList()
        {
            return _context.Comments.ToList();
        }

        #endregion

        #region Feature

        public void Add(Feature entity)
        {
            _context.Features.Add(entity);
        }
        public void Update(Feature entity)
        {
            _context.Update(entity);
        }
        Feature IRepository<Feature>.GetById(long id)
        {
            return _context.Features.Find(id);
        }
        List<Feature> IRepository<Feature>.GetList()
        {
            return _context.Features.ToList();
        }

        public void ChangeDiscountedPercent(long productId, int amount)
        {
            var product = GetById(productId);
            product.ChangeDiscountedPercent(amount);
            Update(product);
        }

        public void ChangeImageName(long productId, string imageName)
        {
            var product = GetById(productId);
            product.ChangeImageName(imageName);
            Update(product);
        }

        public void ChangeInventory(long productId, int amount)
        {
            var product = GetById(productId);
            product.ChangeInventory(amount);
            Update(product);
        }

        public void ChangeMainDescription(long productId, string mainDescription)
        {
            var product = GetById(productId);
            product.ChangeMainDescription(mainDescription);
            Update(product);
        }

        public void ChangeName(long productId, string name)
        {
            var product = GetById(productId);
            product.ChangeName(name);
            Update(product);
        }

        public void ChangeSeoDescription(long productId, string seoDescription)
        {
            var product = GetById(productId);
            product.ChangeSeoDescription(seoDescription);
            Update(product);
        }

        public void ChangeShortDescription(long productId, string shortDescription)
        {
            var product = GetById(productId);
            product.ChangeShortDescription(shortDescription);
            Update(product);
        }

        public void DecreaseInventory(long productId, int amount)
        {
            var product = GetById(productId);
            product.DecreaseInventory(amount);
            Update(product);
        }

        public void EnableIsSpecial(long productId)
        {
            var product = GetById(productId);
            product.EnableIsSpecial();
            Update(product);
        }

        public void DisableIsSpecial(long productId)
        {
            var product = GetById(productId);
            product.DisableIsSpecial();
            Update(product);
        }

        public void IncreaseInventory(long productId, int amount)
        {
            var product = GetById(productId);
            product.IncreaseInventory(amount);
            Update(product);
        }

        #endregion

    }
}
