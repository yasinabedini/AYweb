using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Notification.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : ICommandHandler<CreateNotificationCommand>
    {
        public Task Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
