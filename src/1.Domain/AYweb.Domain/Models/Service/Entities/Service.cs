using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Gallery.Entities;

namespace AYweb.Domain.Models.Service.Entities;

public class Service : AggregateRoot
{
    #region Properties
    public Title Title { get; set; }

    public Description Description { get; set; }

    public Gallery.Entities.Gallery Image { get; set; }

    public int? ParentId { get; set; }

    public Service? Parent { get; set; }

    public bool IsDelete { get; set; }
    #endregion

    #region Constructor And Factories
    private Service() { }
    public Service(string title, string description, string imageName, int? parentId)
    {
        Title = title;
        Description = description;
        Image = Gallery.Entities.Gallery.Create(imageName);
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