using AYweb.Domain.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Notification.Repositories
{
    public interface INotificationRepository : IRepository<Notification.Entities.Notification>
    {
    }
}
