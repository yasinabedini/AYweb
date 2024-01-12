using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Academy.Entities.Configs;
using AYweb.Domain.Models.Notification.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Domain.Models.Notification.Entities;

[EntityTypeConfiguration(typeof(NotificationConfig))]
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
}