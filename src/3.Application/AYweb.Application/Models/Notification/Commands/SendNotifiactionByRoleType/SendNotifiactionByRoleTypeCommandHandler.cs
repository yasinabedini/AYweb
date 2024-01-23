using AIPFramework.Commands;
using AYweb.Domain.Models.Notification.Repositories;

namespace AYweb.Application.Models.Notification.Commands.SendNotifiactionByRoleType;

public class SendNotifiactionByRoleTypeCommandHandler : ICommandHandler<SendNotifiactionByRoleTypeCommand>
{
    private readonly IUserNotificationRepository _repository;

    public SendNotifiactionByRoleTypeCommandHandler(IUserNotificationRepository repository)
    {
        _repository = repository;
    }

    public Task Handle(SendNotifiactionByRoleTypeCommand request, CancellationToken cancellationToken)
    {
        _repository.SendNotificationByRole(request.RoleId, request.NotificationId);
        _repository.Save();

        return Task.CompletedTask;
    }
}
