using AIPFramework.Queries;
using AYweb.Application.Models.Permission.Queries.Common;
using AYweb.Application.Models.Role.Queries.Common;
using AYweb.Domain.Models.Role.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Role.Queries.GetRolePermissions
{
    public class GetRolePermissionsQueryHandler : IQueryHandler<GetRolePermissionsQuery, List<PermissionResult>>
    {
        private readonly IRoleRepository _repository;
        private readonly IMapperAdapter _mapper;


        public GetRolePermissionsQueryHandler(IRoleRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<PermissionResult>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<List<Domain.Models.Permission.Entities.Permission>,List<PermissionResult>>(_repository.GetRolePermission(request.Id)));
        }
    }
}
