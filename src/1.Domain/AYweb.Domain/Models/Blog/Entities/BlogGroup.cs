using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;

namespace AYweb.Domain.Models.Blog.Entities;

public class BlogGroup : Entity<long>
{
    #region Properties
    public Title Title { get;private set; }

    public bool IsDelete { get; set; }
    #endregion

    #region Constructor And Factories
    private BlogGroup()
    {

    }
    public BlogGroup(string title)
    {
        Title = new Title(title);
        CreateAt = DateTime.Now;
    }
    public static BlogGroup Create(string title)
    {
        return new BlogGroup(title);
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

    public void ChangeTitle(string title)
    {
        Title = new Title(title);
        Modified();
    }

    #endregion
}