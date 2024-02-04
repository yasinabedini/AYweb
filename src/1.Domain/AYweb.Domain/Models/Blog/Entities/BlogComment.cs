using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;

namespace AYweb.Domain.Models.Blog.Entities;

public class BlogComment : Entity<long>
{
    #region Properties
    public string Text { get; private set; }

    public long BlogId { get; private set; }

    public string UserName { get; private set; }

    public PhoneNumber UserPhoneNumber { get; private set; }

    public Blog Blog { get; set; }        
    #endregion

    #region Contructor And Factories
    private BlogComment() { }
    public BlogComment(string text, long blogId, string userName, string userPhoneNumber)
    {
        Text = text;
        BlogId = blogId;
        UserName = userName;
        UserPhoneNumber = userPhoneNumber;
        CreateAt = DateTime.Now;
    }
    public static BlogComment Create(string text, long blogId, string userName, string userPhoneNumber)
    {
        return new BlogComment(text, blogId, userName, userPhoneNumber);
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