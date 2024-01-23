using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Notification.Queries.Common
{
    public class NotificationResult
    {
        public required string Title { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
