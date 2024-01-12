using AIPFramework.Entities;
using AYweb.Domain.Models.Academy.Entities.Configs;
using AYweb.Domain.Models.Notification.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Domain.Models.Notification.Entities;

[EntityTypeConfiguration(typeof(UserNotificationConfig))]
public class UserNotification : Entity
{
    public bool IsSeen { get; private set; }

    public int NotificationId { get; private set; }

    public Notification Notification { get; private set; }

    public int UserId { get; private set; }

    public User.Entities.User User { get; private set; }

    public bool IsDelete { get; private set; }

    #region Constructors And Factories
    private UserNotification() { }
    public UserNotification(int notificationId, int userId)
    {
        NotificationId = notificationId;
        UserId = userId;
        CreateAt = DateTime.Now;
    }
    public static UserNotification Create(int notificationId, int userId)
    {
        return new UserNotification(notificationId, userId);
    }
    #endregion

    #region Common
    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void SeenNotification()
    {
        IsSeen = true;
        Modified();
    }

    public void Delete()
    {
        IsDelete = true;
        Modified();
    }
    #endregion


}