using AIPFramework.Commands;
using AYweb.Domain.Models.Notification.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Notification.Commands.DeleteNotification
{
    public class DeleteNotificationCommandHandler : ICommandHandler<DeleteNotificationCommand>
    {
        private readonly INotificationRepository _repository;

        public DeleteNotificationCommandHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
