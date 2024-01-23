using AIPFramework.Entities;

namespace AYweb.Domain.Models.Notification.Entities;

public class UserNotification : Entity<long>
{
    public bool IsSeen { get; private set; }

    public long NotificationId { get; private set; }

    public Notification Notification { get; private set; }

    public long UserId { get; private set; }

    public User.Entities.User User { get; private set; }

    public bool IsDelete { get; private set; }

    #region Constructors And Factories
    private UserNotification() { }
    public UserNotification(long notificationId, long userId)
    {
        NotificationId = notificationId;
        UserId = userId;
        CreateAt = DateTime.Now;
    }
    public static UserNotification Create(long notificationId, long userId)
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