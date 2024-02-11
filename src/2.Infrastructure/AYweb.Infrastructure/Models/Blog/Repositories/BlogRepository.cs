using AYweb.Application.Convertors;
using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Blog.Entities;
using AYweb.Domain.Models.Blog.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

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
        _context.Blog_Groups.Add(Blog_Groups.Create(groupId, blogId));        
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
        return _context.Blogs.Include(t => t.Galleries).Include(t => t.Author).Include(t => t.Groups).Include(t=>t.Comments).FirstOrDefault(t => t.Id == id);
    }

    #endregion

    public List<string> GetTags()
    {
        var tagsStr = GetList().Select(t => t.Tags.Trim()).ToList();

        List<string> tags = new List<string>();
        foreach (var tag in tagsStr)
        {
            tags.AddRange(StringConvertToStringArray.CommaSeparator(tag).ToList());
        }
        tags.ForEach(t => t.Trim());

        return tags;
    }

    public List<Domain.Models.Blog.Entities.Blog> GetListWithRelations()
    {
        return _context.Blogs.Include(t => t.Author).Include(t=>t.Groups).ThenInclude(t=>t.BlogGroup).Include(t=>t.Comments).ToList();
    }

    public List<Domain.Models.Blog.Entities.Blog> Filter(List<Domain.Models.Blog.Entities.Blog> blogList, string search)
    {
        return blogList.Where(t => t.Tags.Contains(search) || t.Title.Value.Contains(search) || t.Text.Contains(search) || t.Introduction.Value.Contains(search) || t.Summary.Value.Contains(search) || (t.Author.FirstName + " " + t.Author.LastName).Contains(search)||t.Groups.Any(t=>t.BlogGroup.Title.Value.Contains(search))).ToList();
    }

    public List<BlogGroup> GetBlogGroupsByBlogId(long blogId)
    {
        return _context.Blog_Groups.Include(t => t.BlogGroup).Where(t => t.BlogId == blogId).Select(t => t.BlogGroup).ToList();
    }

    public void DeleteBlogsGroups(long blogId)
    {
        _context.Blog_Groups.RemoveRange(_context.Blog_Groups.Where(t => t.BlogId == blogId));
    }
}
