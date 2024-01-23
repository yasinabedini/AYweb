using AIPFramework.Commands;
using AYweb.Domain.Models.Notification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Notification.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : ICommandHandler<CreateNotificationCommand>
    {
        private readonly INotificationRepository _repository;

        public CreateNotificationCommandHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(Domain.Models.Notification.Entities.Notification.Create(request.Title));
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
