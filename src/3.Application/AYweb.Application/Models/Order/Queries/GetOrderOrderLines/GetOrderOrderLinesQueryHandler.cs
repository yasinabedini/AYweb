using AIPFramework.Queries;
using AYweb.Application.Models.Order.Queries.Common;
using AYweb.Domain.Models.Order.Entities;
using AYweb.Domain.Models.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Order.Queries.GetOrderOrderLines
{
    public class GetOrderOrderLinesQueryHandler : IQueryHandler<GetOrderOrderLinesQuery, List<OrderLinesResult>>
    {
        private readonly IOrderLineRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetOrderOrderLinesQueryHandler(IOrderLineRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<OrderLinesResult>> Handle(GetOrderOrderLinesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<List<OrderLine>,List<OrderLinesResult>>(_repository.GetOrderOrderLines(request.Id)));   
        }
    }
}
