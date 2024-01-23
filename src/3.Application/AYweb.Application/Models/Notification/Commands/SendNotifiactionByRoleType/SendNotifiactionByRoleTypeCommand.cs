using AIPFramework.Commands;

namespace AYweb.Application.Models.Notification.Commands.SendNotifiactionByRoleType
{
    public class SendNotifiactionByRoleTypeCommand:ICommand
    {
        public long RoleId { get; set; }
        public long NotificationId { get; set; }
    }
}
