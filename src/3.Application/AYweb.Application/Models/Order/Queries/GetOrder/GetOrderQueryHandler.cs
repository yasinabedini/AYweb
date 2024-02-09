using AIPFramework.Queries;
using AYweb.Application.Models.Order.Queries.Common;
using AYweb.Domain.Models.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Order.Queries.GetOrder
{
    public class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, OrderResult>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetOrderQueryHandler(IOrderRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<OrderResult> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<Domain.Models.Order.Entities.Order, OrderResult>(_repository.GetByIdWithRelations(request.Id)));
        }
    }
}
