using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Notification.Commands.SeenNotification
{
    public class SeenNotificationCommand:ICommand
    {
        public long UserNotificationId { get; set; }
    }
}
