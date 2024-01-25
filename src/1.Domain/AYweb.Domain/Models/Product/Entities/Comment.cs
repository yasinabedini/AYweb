using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;

namespace AYweb.Domain.Models.Product.Entities;

public class Comment : Entity<long>
{
    #region Properties
    public Title Title { get; private set; }

    public Description Text { get; private set; }

    public string UserName { get; private set; }

    public PhoneNumber UserPhoneNumber { get; private set; }

    public int ProductId { get; private set; }    

    public Product Product { get; private set; } 
    #endregion

    #region Constructors And Factories

    private Comment() { }
    public Comment(string title, string text, string userName, string phoneNumber, int productId)
    {
        Title = new Title(title);
        Text = new Description(text);
        UserName = userName;
        UserPhoneNumber = new PhoneNumber(phoneNumber);
        ProductId = productId;
        
    }
    public static Comment Create(string title, string text, string userName, string phoneNumber, int productId)
    {
        return new Comment(title, text, userName, phoneNumber, productId);
    }
    public static Comment Create()
    {
        return new Comment();
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