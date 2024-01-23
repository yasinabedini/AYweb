using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Notification.Entities;
using AYweb.Domain.Models.Notification.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Notification.Repositories;

public class NotificationRepository : BaseRepository<Domain.Models.Notification.Entities.Notification>, INotificationRepository, IUserNotificationRepository
{
    private readonly AyWebDbContext _context;
    public NotificationRepository(AyWebDbContext context) : base(context)
    {
        _context = context;
    }

    public void Add(UserNotification entity)
    {
        _context.Add(entity);
    }

    public void Update(UserNotification entity)
    {
        _context.Update(entity);
    }

    UserNotification IRepository<UserNotification>.GetById(long id)
    {
        return _context.UserNotifications.Find(id);
    }

    List<UserNotification> IRepository<UserNotification>.GetList()
    {
        return _context.UserNotifications.ToList();
    }

    public void seenUserNotification(long id)
    {
        UserNotification notification = _context.UserNotifications.Find(id);
        notification.SeenNotification();

        Update(notification);        
    }

    public void SendNotificationByRole(long roleId, long notificationId)
    {
        var users = _context.Users.Where(t => t.RolesList.Any(r => r.RoleId == roleId)).ToList();
        foreach (var user in users)
        {
            _context.UserNotifications.Add(UserNotification.Create(notificationId, user.Id));
        }
    }

    public void SendNotification(long userId, long notificationId)
    {
        Add(UserNotification.Create(notificationId, userId));
    }

    public List<Domain.Models.Notification.Entities.Notification> GetAllUserNotifications(long userId)
    {
        return _context.UserNotifications.Include(x=>x.Notification).Where(t => t.UserId == userId).Select(r=>r.Notification).ToList();
    }

    public List<Domain.Models.Notification.Entities.Notification> GetAllUserUnSeenNotifications(long userId)
    {
        return _context.UserNotifications.Include(x => x.Notification).Where(t => t.UserId == userId&&!t.IsSeen).Select(r => r.Notification).ToList();
    }
}
