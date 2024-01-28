using AIPFramework.Queries;
using AYweb.Application.Models.Plan.Queries.Common;
using AYweb.Domain.Models.Plan.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Plan.Queries.GetPlans
{
    public class GetPlansQueryHandler : IQueryHandler<GetPlansQuery, List<PlanResult>>
    {
        private readonly IPlanRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetPlansQueryHandler(IPlanRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<PlanResult>> Handle(GetPlansQuery request, CancellationToken cancellationToken)
        {
            var plans = _mapper.Map<List<Domain.Models.Plan.Entities.Plan>, List<PlanResult>>(_repository.GetListWithRelations());
            return Task.FromResult(plans);
        }
    }
}
