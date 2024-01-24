using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;

namespace AYweb.Domain.Models.Service.Entities;

public class Service : AggregateRoot
{
    #region Properties
    public Title Title { get;private set; }

    public Description Description { get; private set; }

    public string Image { get; private set; }

    public int? ParentId { get; private set; }

    public Service? Parent { get; private set; }
    
    #endregion

    #region Constructor And Factories
    private Service() { }
    public Service(string title, string description, string imageName, int? parentId)
    {
        Title = title;
        Description = description;
        Image = imageName;
        if (parentId.HasValue) ParentId = parentId;
    }
    public static Service Create(string title, string description, string imageName, int? parentId)
    {
        return new Service(title, description, imageName, parentId);
    }
    #endregion

    #region Common

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void ChangeTitle(string title)
    {
        Title = title;
        Modified();
    }

    public void ChangeParent(int parentId)
    {
        ParentId = parentId;
        Modified();
    }

    public void ChangeDescription(string description)
    {
        Description = description;
        Modified();
    }


    public void ChangeImageName(string imageName)
    {
        Image = Gallery.Entities.Gallery.Create(imageName);
        Modified();
    }

    public void Delete()
    {
        IsDelete = true;
        Modified();
    }

    #endregion
}