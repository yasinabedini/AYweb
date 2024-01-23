using AIPFramework.Queries;
using AYweb.Application.Models.Notification.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Notification.Queries.GetNotification
{
    public class GetNotificationQuery:IQuery<NotificationResult>
    {
        public long NotificationId { get; set; }
    }
}
