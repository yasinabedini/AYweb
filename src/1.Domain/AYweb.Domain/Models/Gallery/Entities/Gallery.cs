using AIPFramework.Entities;

namespace AYweb.Domain.Models.Gallery.Entities;

public class Gallery : AggregateRoot
{
    #region Properties
    public string ImageName { get; private set; }
    
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