using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Notification.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Notification.Repositories
{
    public interface IUserNotificationRepository:IRepository<UserNotification>
    {
        void seenUserNotification(long id);
        void SendNotificationByRole(long roleId, long notificationId);
        void SendNotification(long userId, long notificationId);
        List<Entities.Notification> GetAllUserNotifications(long userId);
        List<Entities.Notification> GetAllUserUnSeenNotifications(long userId);
    }
}
