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

        #endregion

    }
}
