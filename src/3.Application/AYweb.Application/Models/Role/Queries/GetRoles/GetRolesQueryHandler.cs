using AIPFramework.Queries;
using AYweb.Application.Models.Role.Queries.Common;
using AYweb.Application.Models.Role.Queries.GetRole;
using AYweb.Domain.Models.Role.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Role.Queries.GetRoles
{
    public class GetRolesQueryHandler:IQueryHandler<GetRolesQuery,List<RoleResult>>
    {
        private readonly IRoleRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetRolesQueryHandler(IRoleRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<RoleResult>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<List<Domain.Models.Role.Entities.Role>, List<RoleResult>>(_repository.GetList()));
        }
    }
}
