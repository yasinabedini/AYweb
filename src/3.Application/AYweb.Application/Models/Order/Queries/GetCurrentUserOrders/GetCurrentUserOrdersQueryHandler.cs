using AIPFramework.Queries;
using AYweb.Application.Models.Order.Queries.Common;
using AYweb.Application.Models.Order.Queries.GetUserOrders;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Domain.Models.Order.Entities;
using AYweb.Domain.Models.Order.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Order.Queries.GetCurrentUserOrders
{
    public class GetCurrentUserOrdersQueryHandler : IQueryHandler<GetCurrentUserOrdersQuery, List<OrderResult>>
    {        
        private readonly ISender _sender;        

        public GetCurrentUserOrdersQueryHandler(ISender sender)
        {            
            _sender = sender;            
        }

        public Task<List<OrderResult>> Handle(GetCurrentUserOrdersQuery request, CancellationToken cancellationToken)
        {
            var user = _sender.Send(new GetAuthenticatedUserQuery()).Result;
            
            var orders = _sender.Send(new GetUserOrdersQuery { UserId = user.Id }).Result;
            
            return Task.FromResult(orders);
        }
    }
}
