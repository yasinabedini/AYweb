
using AIPFramework.Queries;
using AYweb.Application.Models.Project.Queries.Common;
using AYweb.Domain.Models.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Project.Queries.GetProjects
{
    public class GetProjectsQueryHandler : IQueryHandler<GetProjectsQuery, List<ProjectResult>>
    {
        private readonly IProjectRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetProjectsQueryHandler(IProjectRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<ProjectResult>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _mapper.Map<List<Domain.Models.Project.Entities.Project>, List<ProjectResult>>(_repository.GetList());

            return Task.FromResult(projects);
        }
    }
}
