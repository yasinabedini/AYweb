using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Blog.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Domain.Models.Blog.Entities;

[EntityTypeConfiguration(typeof(BlogCommentConfig))]
public class BlogComment : Entity
{
    #region Properties
    public string Text { get; private set; }

    public int BlogId { get; private set; }

    public string UserName { get; private set; }

    public PhoneNumber UserPhoneNumber { get; private set; }

    public Blog Blog { get; set; }    

    public bool IsDelete { get; set; }
    #endregion

    #region Contructor And Factories
    private BlogComment() { }
    public BlogComment(string text, int blogId, string userName, string userPhoneNumber)
    {
        Text = text;
        BlogId = blogId;
        UserName = userName;
        UserPhoneNumber = userPhoneNumber;
        CreateAt = DateTime.Now;
    }
    public static BlogComment Create(string text, int blogId, string userName, string userPhoneNumber)
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