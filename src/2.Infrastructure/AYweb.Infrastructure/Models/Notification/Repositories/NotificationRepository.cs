using AYweb.Domain.Models.Notification.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Notification.Repositories;

public class NotificationRepository : BaseRepository<Domain.Models.Notification.Entities.Notification>, INotificationRepository
{
    public NotificationRepository(AyWebDbContext context) : base(context)
    {
    }
}
