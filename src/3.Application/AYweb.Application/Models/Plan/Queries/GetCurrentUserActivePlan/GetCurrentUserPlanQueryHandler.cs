using AIPFramework.Queries;
using AYweb.Application.Models.Plan.Queries.Common;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Domain.Models.User.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Plan.Queries.GetCurrentUserActivePlan
{
    public class GetCurrentUserActivePlanQueryHandler : IQueryHandler<GetCurrentUserActivePlanQuery, PlanResult>
    {

        private readonly ISender _sender;
        private readonly IUserRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetCurrentUserActivePlanQueryHandler(ISender sender, IUserRepository repository, IMapperAdapter mapper)
        {
            _sender = sender;
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PlanResult> Handle(GetCurrentUserActivePlanQuery request, CancellationToken cancellationToken)
        {
            var user = _sender.Send(new GetAuthenticatedUserQuery()).Result;

            var plan = _mapper.Map<Domain.Models.Plan.Entities.Plan, PlanResult>(_repository.GetUserActivePlan(user.Id));

            return Task.FromResult(plan);
        }
    }
}
