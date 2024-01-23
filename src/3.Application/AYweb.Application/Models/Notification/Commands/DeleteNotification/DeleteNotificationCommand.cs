using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Notification.Commands.DeleteNotification
{
    public class DeleteNotificationCommand:ICommand
    {
        public long Id { get; set; }
    }
}
