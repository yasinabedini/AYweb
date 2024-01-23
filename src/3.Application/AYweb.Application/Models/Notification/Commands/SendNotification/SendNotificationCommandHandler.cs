using AIPFramework.Commands;
using AYweb.Domain.Models.Notification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Notification.Commands.SendNotification
{
    public class SendNotificationCommandHandler : ICommandHandler<SendNotificationCommand>
    {
        private readonly IUserNotificationRepository _repository;

        public SendNotificationCommandHandler(IUserNotificationRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            _repository.SendNotification(request.UserId, request.NotificationId);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
