using AIPFramework.Queries;
using AYweb.Application.Models.Role.Queries.Common;
using AYweb.Domain.Models.Role.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Role.Queries.GetRole
{
    public class GetRoleQueryHandler : IQueryHandler<GetRoleQuery, RoleResult>
    {
        private readonly IRoleRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetRoleQueryHandler(IRoleRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<RoleResult> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<Domain.Models.Role.Entities.Role, RoleResult>(_repository.GetById(request.Id)));
        }
    }
}
