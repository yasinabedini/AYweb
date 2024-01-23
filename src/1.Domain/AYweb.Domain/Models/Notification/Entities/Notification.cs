using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;

namespace AYweb.Domain.Models.Notification.Entities;

public class Notification : AggregateRoot
{
    #region Properties
    public Title Title { get; set; }

    public bool IsDelete { get; set; }
    #endregion

    #region Constructors And Factories
    private Notification() { }
    public Notification(string title)
    {
        Title = title;
        CreateAt = DateTime.Now;
    }
    public static Notification Create(string title)
    {
        return new Notification(title);
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
        Modified()
    }
    #endregion
}