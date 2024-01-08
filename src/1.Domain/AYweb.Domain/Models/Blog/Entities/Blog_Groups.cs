using AIPFramework.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace AYweb.Domain.Models.Blog.Entities;

public class Blog_Groups : Entity
{
    #region Properties
    public int BlogGroupId { get; private set; }

    public int BlogId { get; private set; }

    public BlogGroup BlogGroup { get; private set; }

    public Blog Blog { get; private set; }

    public bool IsDelete { get; private set; }
    #endregion

    #region Constructors And Factories
    private Blog_Groups() { }
    public Blog_Groups(int blogGroupId, int blogId)
    {
        BlogGroupId = blogGroupId;
        BlogId = blogId;
        CreateAt = DateTime.Now;
    }
    public static Blog_Groups Create(int blogGroupId, int blogId)
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