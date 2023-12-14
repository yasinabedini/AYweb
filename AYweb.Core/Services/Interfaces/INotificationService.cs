using AYweb.Dal.Entities.User;

namespace AYweb.Core.Services.Interfaces;

public interface INotificationService
{
    void SendNotification(Role role, string text);
    void SendAdminNotification(string text);
    void SendUserNotification(string text);
}