using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Blog.Entities;
using AYweb.Domain.Models.Blog.Repositories;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Blog.Repositories;

public class BlogRepository : BaseRepository<Domain.Models.Blog.Entities.Blog>, IBlogRepository, IBlogGroupRepository, IBlogCommentRepository
{
    private readonly AyWebDbContext _context;
    public BlogRepository(AyWebDbContext context) : base(context)
    {
        _context = context;
    }

    #region Blog Groups
    public void Add(BlogGroup entity)
    {
        _context.BlogGroups.Add(entity);
    }

    public void Update(BlogGroup entity)
    {
        _context.BlogGroups.Update(entity);
    }    

    BlogGroup IRepository<BlogGroup>.GetById(long id)
    {
        return _context.BlogGroups.Find(id);
    }
   
    List<BlogGroup> IRepository<BlogGroup>.GetList()
    {
        return _context.BlogGroups.ToList();
    }

    #endregion

    #region Blog Comment

    public void Add(BlogComment entity)
    {
        _context.BlogComments.Add(entity);
    }
    public void Update(BlogComment entity)
    {
        _context.BlogComments.Update(entity);
    }
    BlogComment IRepository<BlogComment>.GetById(long id)
    {
        return _context.BlogComments.Find(id);
    }
    List<BlogComment> IRepository<BlogComment>.GetList()
    {
        return _context.BlogComments.ToList();
    }

    public List<BlogComment> GetBlogComments(long blogId)
    {
        return _context.BlogComments.Where(t => t.BlogId == blogId).ToList();
    }

    #endregion
}
