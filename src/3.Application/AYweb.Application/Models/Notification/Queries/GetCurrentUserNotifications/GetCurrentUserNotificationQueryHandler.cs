using AIPFramework.Queries;
using AYweb.Application.Models.Notification.Queries.Common;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Domain.Models.Notification.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Notification.Queries.GetCurrentUserNotifications
{
    public class GetCurrentUserNotificationQueryHandler : IQueryHandler<GetCurrentUserNotificationQuery, List<NotificationResult>>
    {
        private readonly ISender _sender;
        private readonly IUserNotificationRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetCurrentUserNotificationQueryHandler(ISender sender, IUserNotificationRepository repository, IMapperAdapter mapper)
        {
            _sender = sender;
            _repository = repository;
            _mapper = mapper;
        }

        Task<List<NotificationResult>> IRequestHandler<GetCurrentUserNotificationQuery, List<NotificationResult>>.Handle(GetCurrentUserNotificationQuery request, CancellationToken cancellationToken)
        {
            var user = _sender.Send(new GetAuthenticatedUserQuery()).Result;
            _repository.GetAllUserNotifications(user.Id);

            var notifications = _mapper.Map<List<Domain.Models.Notification.Entities.Notification>, List<NotificationResult>>(_repository.GetAllUserNotifications(user.Id));

            return Task.FromResult(notifications);
        }
    }
}
