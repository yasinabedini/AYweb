using AIPFramework.Queries;
using AYweb.Application.Models.Order.Queries.Common;
using AYweb.Domain.Models.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Order.Queries.GetOrders
{    
    public class GetOrdersQueryHandler:IQueryHandler<GetOrdersQuery,PagedData<OrderResult>>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetOrdersQueryHandler(IOrderRepository reopsitory, IMapperAdapter mapper)
        {
            _repository = reopsitory;
            _mapper = mapper;
        }

        public Task<PagedData<OrderResult>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orderList = _repository.GetList();
            var order = _mapper.Map<List<Domain.Models.Order.Entities.Order>, List<OrderResult>>(orderList);

            return Task.FromResult(new PagedData<OrderResult> { QueryResult = order, PageNumber = request.PageNumber, PageSize = request.PageSize, TotalCount = orderList.Count });
        }
    }
}
