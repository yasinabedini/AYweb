using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Entities.User;

namespace AYweb.Core.Services;

public class NotificationService:INotificationService
{
    public void SendNotification(Role role, string text)
    {
    }

    public void SendAdminNotification(string text)
    {
    }

    public void SendUserNotification(string text)
    {
    }
}