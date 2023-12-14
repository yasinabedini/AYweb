namespace AYweb.Dal.Entities.Notification;

public class UserNotification
{
    public int Id { get; set; }
    public bool IsSeen { get; set; }
    public int NotificationId { get; set; }
    public Notification Notification { get; set; }
    public int UserId { get; set; }
    public User.User User { get; set; }

    public void SeenNotification()
    {
        IsSeen = true;
    }
}