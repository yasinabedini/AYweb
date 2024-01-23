using AIPFramework.Queries;
using AYweb.Application.Models.Permission.Queries.Common;
using AYweb.Domain.Models.Permission.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Permission.Queries.GetPermissions
{
    public class GetPermissionsQueryHandler : IQueryHandler<GetPermissionsQuery, List<PermissionResult>>
    {
        private readonly IPermissionRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetPermissionsQueryHandler(IPermissionRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<PermissionResult>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<List<Domain.Models.Permission.Entities.Permission>, List<PermissionResult>>(_repository.GetList()));
        }
    }
}
