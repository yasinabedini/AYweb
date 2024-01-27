using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Blog.Entities;
using AYweb.Domain.Models.Blog.Repositories;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

    public void AddGroupToBlog(long blogId, long groupId)
    {
        var blog = GetById(blogId);
        blog.AddGroup(groupId);
        Update(blog);
    }

    public void AddTagToBlog(long blogId, string tag)
    {
        var blog = GetById(blogId);
        blog.AddTags(tag);
        Update(blog);
    }

    public void ChangeImage(long blogId, string imageName)
    {
        var blog = GetById(blogId);
        blog.ChangeImageName(imageName);
        Update(blog);
    }

    public void ChangeIntroduction(long blogId, string introduction)
    {
        var blog = GetById(blogId);
        blog.ChangeIntroduction(introduction);
        Update(blog);
    }

    public void ChangeSummery(long blogId, string summery)
    {
        var blog = GetById(blogId);
        blog.ChangeSummary(summery);
        Update(blog);
    }

    public void ChangeText(long blogId, string text)
    {
        var blog = GetById(blogId);
        blog.ChangeText(text);
        Update(blog);
    }

    public void ChangeTitle(long blogId, string title)
    {
        var blog = GetById(blogId);
        blog.ChangeTitle(title);
        Update(blog);
    }

    public Domain.Models.Blog.Entities.Blog GetByIdWithRelations(long id)
    {
        return _context.Blogs.Include(t => t.Galleries).Include(t => t.Author).Include(t => t.Groups).First(t => t.Id == id);
    }

    #endregion
}
