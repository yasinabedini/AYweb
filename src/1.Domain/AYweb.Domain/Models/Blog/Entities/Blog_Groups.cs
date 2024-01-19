using AIPFramework.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace AYweb.Domain.Models.Blog.Entities;

public class Blog_Groups : Entity<long>
{
    #region Properties
    public long BlogGroupId { get; private set; }

    public long BlogId { get; private set; }

    public BlogGroup BlogGroup { get; private set; }

    public Blog Blog { get; private set; }

    public bool IsDelete { get; private set; }
    #endregion

    #region Constructors And Factories
    private Blog_Groups() { }
    public Blog_Groups(long blogGroupId, long blogId)
    {
        BlogGroupId = blogGroupId;
        BlogId = blogId;
        CreateAt = DateTime.Now;
    }
    public static Blog_Groups Create(long blogGroupId, long blogId)
    {
        return new Blog_Groups(blogGroupId, blogId);
    }
    #endregion

    #region Command

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void Delete()
    {
        IsDelete = true;
        Modified();
    }

    #endregion
}