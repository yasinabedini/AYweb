using AIPFramework.Entities;
using AYweb.Domain.Models.Blog.Entities.Configs;
using AYweb.Domain.Models.Gallery.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Domain.Models.Gallery.Entities;

[EntityTypeConfiguration(typeof(GalleryConfig))]
public class Gallery : AggregateRoot
{
    #region Properties
    public string ImageName { get; private set; }

    public bool IsDelete { get; set; }
    #endregion

    #region Constructors And Factories
    private Gallery() { }
    public Gallery(string imageName)
    {
        ImageName = imageName;
    }
    public static Gallery Create(string imageName)
    {
        return new Gallery(imageName);
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

    public void ChangeImageName(string imageName)
    {
        ImageName = imageName;
        Modified();
    }
    #endregion
}