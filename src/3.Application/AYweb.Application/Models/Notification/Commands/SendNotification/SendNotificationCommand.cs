using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Notification.Commands.SendNotification
{
    public class SendNotificationCommand:ICommand
    {
        public long UserId { get; set; }
        public long NotificationId { get; set; }
    }
}
