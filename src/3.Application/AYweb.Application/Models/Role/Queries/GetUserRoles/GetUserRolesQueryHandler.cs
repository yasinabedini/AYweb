using AIPFramework.Queries;
using AYweb.Application.Models.Role.Queries.Common;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Role.Queries.GetUserRoles
{
    public class GetUserRolesQueryHandler : IQueryHandler<GetUserRolesQuery, List<RoleResult>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetUserRolesQueryHandler(IUserRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<RoleResult>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<List<Domain.Models.Role.Entities.Role>, List<RoleResult>>(_repository.GetUserRoles(request.UserId)));
        }
    }
}
