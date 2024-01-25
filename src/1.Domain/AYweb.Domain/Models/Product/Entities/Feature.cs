using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;

namespace AYweb.Domain.Models.Product.Entities;

public class Feature : Entity<long>
{
    #region Properties
    public Title Title { get; private set; }

    public string Value { get; private set; }

    public int ProductId { get; private set; }

    public Product Product { get; private set; } 
    #endregion

    #region Constructors And Factories
    private Feature() { }
    public Feature(string title, string value)
    {
        Title = new Title(title);
        Value = value;
        CreateAt = DateTime.Now;
    }
    public static Feature Create(string title, string value)
    {
        return new Feature(title, value);
    }
    public static Feature Create()
    {
        return new Feature();
    }
    #endregion

    #region Command

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void ChangeTitle(string title)
    {
        Title = new Title(title);
        Modified();
    }

    public void ChangeValue(string value)
    {
        Value = value;
        Modified();
    }

    #endregion
}