using AIPFramework.Queries;
using AYweb.Application.Models.Order.Queries.Common;
using AYweb.Application.Models.Order.Queries.GetCurrentUserOrders;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Domain.Models.Order.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Order.Queries.GetUserOrders
{
    public class GetUserOrdersQueryHandler : IQueryHandler<GetUserOrdersQuery, List<OrderResult>>
    {
        private readonly IOrderRepository _repository;        
        private readonly IMapperAdapter _mapper;

        public GetUserOrdersQueryHandler(IOrderRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;            
            _mapper = mapper;
        }

        public Task<List<OrderResult>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {            
            var orders = _mapper.Map<List<Domain.Models.Order.Entities.Order>, List<OrderResult>>(_repository.GetOrdersByUserId(request.UserId));

            return Task.FromResult(orders);
        }
    }
}
