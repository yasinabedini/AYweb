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

namespace AYweb.Application.Models.Order.Queries.GetOrderReadyToShip
{
    public class GetOrderReadyToShipQueryHandler : IQueryHandler<GetOrderReadyToShipQuery, List<ForwardResult>>
    {
        private readonly IForwardRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetOrderReadyToShipQueryHandler(IForwardRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<ForwardResult>> Handle(GetOrderReadyToShipQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<List<Forward>, List<ForwardResult>>(_repository.GetUnSendForwards()));
        }
    }
}
