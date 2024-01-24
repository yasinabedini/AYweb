using AIPFramework.Queries;
using AYweb.Application.Models.Notification.Queries.Common;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Domain.Models.Notification.Repositories;
using MediatR;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Notification.Queries.GetCurrentUserUnSeenNotification
{
    public class GetCurrentUserUnSeenNotificationQueryHandler : IQueryHandler<GetCurrentUserUnSeenNotificationQuery, List<NotificationResult>>
    {
        private readonly ISender _sender;
        private readonly IUserNotificationRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetCurrentUserUnSeenNotificationQueryHandler(ISender sender, IUserNotificationRepository repository, IMapperAdapter mapper)
        {
            _sender = sender;
            _repository = repository;
            _mapper = mapper;
        }

        Task<List<NotificationResult>> IRequestHandler<GetCurrentUserUnSeenNotificationQuery, List<NotificationResult>>.Handle(GetCurrentUserUnSeenNotificationQuery request, CancellationToken cancellationToken)
        {
            var user = _sender.Send(new GetAuthenticatedUserQuery()).Result;
            _repository.GetAllUserNotifications(user.Id);

            var notifications = _mapper.Map<List<Domain.Models.Notification.Entities.Notification>, List<NotificationResult>>(_repository.GetAllUserUnSeenNotifications(user.Id));

            return Task.FromResult(notifications);
        }
    }
}
