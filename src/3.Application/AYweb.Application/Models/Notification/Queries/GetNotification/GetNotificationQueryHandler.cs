using AIPFramework.Queries;
using AutoMapper;
using AYweb.Application.Models.Notification.Queries.Common;
using AYweb.Domain.Models.Notification.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Notification.Queries.GetNotification
{
    public class GetNotificationQueryHandler : IQueryHandler<GetNotificationQuery, NotificationResult>
    {
        private readonly INotificationRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetNotificationQueryHandler(INotificationRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        Task<NotificationResult> IRequestHandler<GetNotificationQuery, NotificationResult>.Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<Domain.Models.Notification.Entities.Notification, NotificationResult>(_repository.GetById(request.NotificationId));

            return Task.FromResult(notification);
        }
    }
}
