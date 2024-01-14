using AYweb.Domain.Models.Notification.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Notification.Repositories;

public class NotificationRepository : INotificationRepository
{
    public void Add(Domain.Models.Notification.Entities.Notification entity)
    {
        throw new NotImplementedException();
    }

    public Domain.Models.Notification.Entities.Notification GetById(long id)
    {
        throw new NotImplementedException();
    }

    public List<Domain.Models.Notification.Entities.Notification> GetList()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Update(Domain.Models.Notification.Entities.Notification entity)
    {
        throw new NotImplementedException();
    }
}
