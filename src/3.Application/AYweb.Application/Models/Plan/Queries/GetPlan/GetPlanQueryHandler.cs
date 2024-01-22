using AIPFramework.Queries;
using AYweb.Application.Models.Plan.Queries.Common;
using AYweb.Domain.Models.Plan.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Plan.Queries.GetPlan
{
    public class GetPlanQueryHandler : IQueryHandler<GetPlanQuery, PlanResult>
    {
        private readonly IPlanRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetPlanQueryHandler(IPlanRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PlanResult> Handle(GetPlanQuery request, CancellationToken cancellationToken)
        {
            var plan = _mapper.Map<Domain.Models.Plan.Entities.Plan, PlanResult>(_repository.GetById(request.Id));
            return Task.FromResult(plan);   
        }
    }
}
