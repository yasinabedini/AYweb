using AIPFramework.Queries;
using AYweb.Application.Models.Notification.Queries.Common;
using AYweb.Domain.Models.Notification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Notification.Queries.GetNotifications
{
    public class GetNotificationsQueryHandler : IQueryHandler<GetNotificationsQuery, PagedData<NotificationResult>>
    {
        private readonly INotificationRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetNotificationsQueryHandler(INotificationRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PagedData<NotificationResult>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notifications= _repository.GetList();
            var notificationList = _mapper.Map<List<Domain.Models.Notification.Entities.Notification>, List<NotificationResult>>(notifications.Skip(request.SkipCount).Take(request.PageSize).ToList());

            return Task.FromResult(new PagedData<NotificationResult> { QueryResult = notificationList, PageNumber = request.PageNumber, PageSize = request.PageSize, TotalCount = notifications.Count });           
        }
    }
}
