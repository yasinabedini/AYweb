using AIPFramework.Commands;
using AYweb.Domain.Models.Notification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Notification.Commands.SeenNotification
{
    public class SeenNotificationCommandHandler : ICommandHandler<SeenNotificationCommand>
    {
        private readonly IUserNotificationRepository _repository;

        public SeenNotificationCommandHandler(IUserNotificationRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(SeenNotificationCommand request, CancellationToken cancellationToken)
        {
            _repository.seenUserNotification(request.UserNotificationId);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
