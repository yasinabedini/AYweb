using AYweb.Dal.Entities.User;

namespace AYweb.Dal.Entities.Notification;

public class Notification
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<UserNotification> UserNotifications { get; set; }
}